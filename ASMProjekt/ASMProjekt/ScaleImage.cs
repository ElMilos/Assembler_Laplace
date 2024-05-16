using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASMProjekt
{
    internal class ScaleImage
    {
        public void ResizeImageAndSetPictureBox(Image imagePath, PictureBox pictureBox)
        {
            // Wymiary pictureBoxa
            int pictureBoxWidth = pictureBox.Width;
            int pictureBoxHeight = pictureBox.Height;

            // Wczytaj obraz z pliku
            Image originalImage = imagePath;

            // Przeskaluj obraz do wymiarów pictureBoxa
            Image resizedImage = ResizeImage(originalImage, pictureBoxWidth, pictureBoxHeight);

            // Ustaw przeskalowany obraz w pictureBoxie
            pictureBox.Image = resizedImage;
        }

        private Image ResizeImage(Image originalImage, int width, int height)
        {
            // Utwórz nowy obraz o podanych wymiarach
            Bitmap resizedImage = new Bitmap(width, height);

            // Utwórz obiekt Graphics do rysowania na nowym obrazie
            using (Graphics graphics = Graphics.FromImage(resizedImage))
            {
                // Ustaw jakość przeskalowywania
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                // Narysuj przeskalowany obraz
                graphics.DrawImage(originalImage, 0, 0, width, height);
            }

            return resizedImage;
        }
    }
}
