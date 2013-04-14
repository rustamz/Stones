using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PictureDBManager
{
    public partial class AddImageForm : Form
    {
        public AddImageForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Файлы изображений (*.bmp, *.jpg, *.png)|*.bmp;*.jpg;*.png";
            if (ofd.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                pictureBox1.Load(ofd.FileName);
                textBox1.Text = ofd.FileName;
                if (textBox2.Text.Length == 0)
                {
                    textBox2.Text = System.IO.Path.GetFileNameWithoutExtension(ofd.FileName);
                }
            }
        }

        public string PictureName 
        {
            get { return textBox2.Text; }
            set { textBox2.Text = value; }
        }

        public Image PictureImage 
        {
            get { return pictureBox1.Image; }
            set { pictureBox1.Image = value; }
        }

        public byte[] GetPngImage()
        {
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            pictureBox1.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);

            byte[] Result = new byte[stream.Length];
            int ByteWrited = 0;
            stream.Position = 0;
            ByteWrited = stream.Read(Result, 0, (int)stream.Length);
            if (ByteWrited != stream.Length)
            {
                throw new Exception("Невозможно преобразовать картинку в бинарный поток. Записано " 
                    + ByteWrited.ToString() + " байт из " + stream.Length.ToString());
            }
            return Result;
        }
    }
}
