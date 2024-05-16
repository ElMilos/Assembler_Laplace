using System;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;



namespace CSharpLibrary
{
    public class PictureMod
    {

        public Bitmap DoLaplaca(string imagePath, string Matrix,int tasksCount)
        {
            Bitmap bmp = new Bitmap(imagePath); // Bitmapa

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

            int MY, MX; // Wielkości Matrycy



            // Macierz filtru Laplace'a
            int[,] Matrix1 = new int[,]
            {
                { -1, -1, -1 },
                { -1,  8, -1 },
                { -1, -1, -1 }
            };
            int[,] Matrix2 = new int[,]
           {

    {  0,  0, -1,  0,  0 },
    {  0, -1, -2, -1,  0 },
    { -1, -2, 16, -2, -1 },
    {  0, -1, -2, -1,  0 },
    {  0,  0, -1,  0,  0 }
           };
            int[,] Matrix3 = new int[,]
           {
    {  0,  0, -1, -1, -1,  0,  0 },
    {  0, -1, -3, -3, -3, -1,  0 },
    { -1, -3,  0,  7,  0, -3, -1 },
    { -1, -3,  7, 24,  7, -3, -1 },
    { -1, -3,  0,  7,  0, -3, -1 },
    {  0, -1, -3, -3, -3, -1,  0 },
    {  0,  0, -1, -1, -1,  0,  0 }

           };

            int[,] laplaceMatrix;
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

                        for (int x = 0; x < widthInPixels- bytesPerPixel; x += bytesPerPixel)
                {
                    int red = 0, green = 0, blue = 0;

                    // Zastosowanie filtra Laplace'a
                    for (int filterY = 0; filterY < MY; filterY++)
                    {
                        for (int filterX = 0; filterX < MX; filterX++)
                        {


                            int offsetX = (x - bytesPerPixel + filterX * bytesPerPixel + widthInPixels) % widthInPixels;
                            int offsetY = (y - 1 + filterY + heightInPixels) % heightInPixels;



                            int pixelIndex = offsetY * widthInPixels + offsetX;


                            if (pixelIndex >= 0 && pixelIndex <= OldPixels.Length - bytesPerPixel)
                            {
                                red += OldPixels[pixelIndex + 2] * laplaceMatrix[filterY, filterX];
                                green += OldPixels[pixelIndex + 1] * laplaceMatrix[filterY, filterX];
                                blue += OldPixels[pixelIndex] * laplaceMatrix[filterY, filterX];
                            }



                        }
                    }

                   int r = Math.Min(Math.Max(red, 0), 255);
                   int g = Math.Min(Math.Max(green, 0), 255);
                   int b = Math.Min(Math.Max(blue, 0), 255);

                    int currentPixel = (y * newBmpData.Stride + x)- newBmpData.Stride;
                    if (currentPixel >= 0 && currentPixel + 2 < OldPixels.Length)
                    {
                                if (Math.Abs(r - g) <= 30 && Math.Abs(r - b) <= 30 && Math.Abs(g - b) <= 30)//filtr koloru
                                {
                                    Newpixels[currentPixel] = (byte)b;
                                    Newpixels[currentPixel + 1] = (byte)g;
                                    Newpixels[currentPixel + 2] = (byte)r;
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