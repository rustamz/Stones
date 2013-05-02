using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using PictureDBManager;


namespace Stones
{
    public partial class MainForm : Form
    {
        private ImageShell bufferImage = new ImageShell();

        public MainForm()
        {
            InitializeComponent();
        }

        private void tsmiClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsmiOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Файлы изображений (*.bmp, *.jpg, *.png)|*.bmp;*.jpg;*.png";
            if (ofd.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                bufferImage.Image = new Bitmap(ofd.FileName);
                if (bufferImage.Image != null)
                {
                    tsslFileName.Text = System.IO.Path.GetFileName(ofd.FileName);
                    pbMainImage.Image = bufferImage.Image;
                }
                else
                {
                    MessageBox.Show("Невозможно прочитать файл!");
                }
            }
        }

        private void tsmiMakeGray_Click(object sender, EventArgs e)
        {
            if (bufferImage.Image != null)
            {
                bufferImage.MakeGray();
                pbMainImage.Image = bufferImage.Image;
            }
        }

        private void tsmiMonochrome_Click(object sender, EventArgs e)
        {
            if (bufferImage.Image != null)
            {
                bufferImage.MakeMonochrome(127);
                pbMainImage.Image = bufferImage.Image;
            }
        }

        private void tsmiSobel_Click(object sender, EventArgs e)
        {
            if (bufferImage.Image != null)
            {
                bufferImage.Soble();
                pbMainImage.Image = bufferImage.Image;
            }
        }

        private void tsmiDBManager_Click(object sender, EventArgs e)
        {
            (new DBManagerUIForm()).ShowDialog(this);
        }

        private void tsmiShowTraining_Click(object sender, EventArgs e)
        {
            (new TrainingForm()).ShowDialog(this);
        }
    }
}
