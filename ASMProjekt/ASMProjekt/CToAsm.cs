using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace ASMProjekt
{
    internal class CToAsm
    {
        [DllImport(@"D:\c#\ASMProjekt\x64\Debug\ASMDLL.dll")]
        public static extern void MyProc1(int[] pixels, int length, int[] matrix, int[] asmRes);


        public Bitmap ToAsm(string image, string Matrix,int tasksCount)
        {

            Bitmap bmp = new Bitmap(image); // Bitmapa

            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            BitmapData newBmpData = bmp.LockBits(rect, ImageLockMode.WriteOnly, bmp.PixelFormat);


            int bytesPerPixel = System.Drawing.Image.GetPixelFormatSize(bmp.PixelFormat) / 8;

            int byteCount = newBmpData.Stride * bmp.Height;
            byte[] OldPixels = new byte[byteCount];
            byte[] Newpixels = new byte[byteCount];

            Marshal.Copy(newBmpData.Scan0, OldPixels, 0, OldPixels.Length);

            // int st = newBmpData.Stride;

            int heightInPixels = newBmpData.Height;
            int widthInPixels = newBmpData.Stride;





            int MY = 3, MX = 3; // Wielkości Matrycy

            // Macierz filtru Laplace'a
            int[] Matrix1 = new int[]
            {
    -1, -1, -1,-1,  8, -1, -1, -1, -1
            };


            int[] Matrix2 = new int[]
           {

      0,  0, -1,  0,  0 ,
      0, -1, -2, -1,  0 ,
     -1, -2, 16, -2, -1 ,
      0, -1, -2, -1,  0 ,
      0,  0, -1,  0,  0 
           };
            int[] Matrix3 = new int[]
           {
      0,  0, -1, -1, -1,  0,  0 ,
      0, -1, -3, -3, -3, -1,  0 ,
     -1, -3,  0,  7,  0, -3, -1 ,
     -1, -3,  7, 24,  7, -3, -1 ,
     -1, -3,  0,  7,  0, -3, -1 ,
      0, -1, -3, -3, -3, -1,  0 ,
      0,  0, -1, -1, -1,  0,  0 

           };

           
            
                            int[] laplaceMatrix;
                            if (Matrix == "Matrix1")
                            {
                                MY = 3;
                                MX = 3;
                                laplaceMatrix = Matrix1;
                            }
                            else if (Matrix == "Matrix2")
                            {
                                laplaceMatrix = Matrix2;
                                MY = 5;
                                MX = 5;
                            }
                            else
                            {
                                MY = 7;
                                MX = 7;
                                laplaceMatrix = Matrix3;

                           }
            


            int LenghtOfPixel = (MY * MX * bytesPerPixel);

            int partHeight = heightInPixels / tasksCount; // Wysokość części przetwarzanej przez jeden wątek
            Task[] tasks = new Task[tasksCount];
           
            for (int taskNumber = 0; taskNumber < tasksCount; taskNumber++)
            {
                int taskNumberCopy = taskNumber;
                tasks[taskNumber] = Task.Run(() =>
               {
                   int startHeight = partHeight * taskNumberCopy;
                    int endHeight = (taskNumberCopy == tasksCount - 1) ? heightInPixels : startHeight + partHeight;// To jest takie świtne

                    for (int y = 0; y < heightInPixels; y++)
                    {

                        for (int x = 0; x < widthInPixels - bytesPerPixel; x += bytesPerPixel)
                        {
                            int[] pixelsToAsm = new int[MY*MX*bytesPerPixel];
                            int pixelArreySpot=0;
                            int[] asmResults = new int[4];

                  //  int checkBit = 0;
                 //   int incre = 0;




                            for (int filterY = 0; filterY < MY; filterY++)
                            {
                                for (int filterX = 0; filterX < MX; filterX++)
                                {


                                    int offsetX = (x - bytesPerPixel + filterX * bytesPerPixel + widthInPixels) % widthInPixels;
                                    int offsetY = (y - 1 + filterY + heightInPixels) % heightInPixels;



                                    int pixelIndex = offsetY * widthInPixels + offsetX;


                                    if (pixelIndex >= 0 && pixelIndex <= OldPixels.Length - bytesPerPixel)
                                    {
                                pixelsToAsm[pixelArreySpot] =   OldPixels[pixelIndex];
                                pixelsToAsm[pixelArreySpot+1] = OldPixels[pixelIndex + 1];
                                pixelsToAsm[pixelArreySpot+2] = OldPixels[pixelIndex + 2];

                                    }

                                 pixelArreySpot += bytesPerPixel;

                                }
                            }

                    // implementacja kodu asm 
                    MyProc1(pixelsToAsm, LenghtOfPixel, laplaceMatrix, asmResults);

                    int currentPixel = (y * newBmpData.Stride + x) - newBmpData.Stride;
                    if (currentPixel >= 0 && currentPixel + 2 < OldPixels.Length)
                    {
                               // redakcja szumu
                               if (Math.Abs(asmResults[0] - asmResults[1]) <= 30 && Math.Abs(asmResults[0] - asmResults[2]) <= 30 && Math.Abs(asmResults[1] - asmResults[2]) <= 30)
                               {
                                   Newpixels[currentPixel] = (byte)asmResults[0];
                                   Newpixels[currentPixel + 1] = (byte)asmResults[1];
                                   Newpixels[currentPixel + 2] = (byte)asmResults[2];
                               }

                    }


                }

                    }
                });
            }

           Task.WaitAll(tasks);
            Marshal.Copy(Newpixels, 0, newBmpData.Scan0, Newpixels.Length);
            bmp.UnlockBits(newBmpData);

            return bmp;
        }


    }

}

