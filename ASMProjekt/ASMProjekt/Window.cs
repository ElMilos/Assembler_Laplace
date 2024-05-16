using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CSharpLibrary;

namespace ASMProjekt
{
    public partial class Window : Form
    {




        private CSharpLibrary.PictureMod pictureMod = new CSharpLibrary.PictureMod();
        string imagePath;
        int currentValue;
        int threds=Environment.ProcessorCount;

        public Window()
        {
            InitializeComponent();
            imagePath = "D:\\c#\\ASMProjekt\\city.jpg";
            Image obraz = Image.FromFile(imagePath);

            ScaleImage A = new ScaleImage();
            A.ResizeImageAndSetPictureBox(obraz, OrginalPic);
            // OrginalPic.Image = obraz;
        }

        private void Modify_Click(object sender, EventArgs e)
        {
            


            Bitmap ModifiedPic;
            pictureMod = new PictureMod();
            var checkedButton = MatrixBox.Controls.OfType<RadioButton>()
                                      .FirstOrDefault(r => r.Checked);

            if (checkedButton != null)
            {

                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                string name;

                if (checkedButton.Text == "3x3")
                { name = "Matrix1"; }
                else if (checkedButton.Text == "5x5")
                { name = "Matrix2"; }
                else { name = "Matrix3"; }

                ModifiedPic = pictureMod.DoLaplaca(imagePath, name, threds);

                Image a = ModifiedPic;
                ScaleImage A = new ScaleImage();
                A.ResizeImageAndSetPictureBox(a, ModedPic);

                stopwatch.Stop();
                TimeCounter.Text=""+stopwatch.ElapsedMilliseconds+" ms";
            }

        }

        private void OrginalPic_Click(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Filtr33_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }


        private void Asm_Click(object sender, EventArgs e)
        {
   
            Bitmap ModifiedPic;
            CToAsm pictureMod = new CToAsm();
            var checkedButton = MatrixBox.Controls.OfType<RadioButton>()
                                      .FirstOrDefault(r => r.Checked);
            if (checkedButton != null)
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                string name;

                if (checkedButton.Text == "3x3")
                { name = "Matrix1"; }
                else if (checkedButton.Text == "5x5")
                { name = "Matrix2"; }
                else { name = "Matrix3"; }

                ModifiedPic = pictureMod.ToAsm(imagePath, name, threds);

                Image a = ModifiedPic;
                ScaleImage A = new ScaleImage();
                A.ResizeImageAndSetPictureBox(a, ModedPic);

                stopwatch.Stop();
                TimeCounter.Text = "" + stopwatch.ElapsedMilliseconds + " ms";
            }

        }
        private void ChosePic_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "jpg files (*.jpg)|*.jpg|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    imagePath = openFileDialog.FileName;
                    UpdatePictureBox(imagePath, OrginalPic);
                }
            }
        }

        private void UpdatePictureBox(string imagePath, PictureBox pictureBox)
        {
            try
            {
                Image image = Image.FromFile(imagePath);
                ScaleImage scaler = new ScaleImage();
                scaler.ResizeImageAndSetPictureBox(image, pictureBox);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nie można wczytać obrazu: " + ex.Message);
            }
        }

        private void TrackBar_Scroll(object sender, EventArgs e)
        {
            // Metoda wywoływana przy każdym przesunięciu TrackBar
            TrackBar trackBar = (TrackBar)sender;
            currentValue = trackBar.Value;

            // Tutaj możesz umieścić kod, który ma być wykonany po przesunięciu TrackBar
            // Na przykład:

                threds = (int)Math.Pow(2, currentValue);
                ThredNumber.Text = "Ilość Wątków:" + threds;


        }

        private void ThredNumber_Click(object sender, EventArgs e)
        {

        }
    }
    
}
