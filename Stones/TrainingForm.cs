using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Stones
{
    public partial class TrainingForm : Form
    {
        private ImageShell bufferImage = new ImageShell();

        public TrainingForm()
        {
            InitializeComponent();
        }

        private void btnLoadOrigin_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Файлы изображений (*.bmp, *.jpg, *.png)|*.bmp;*.jpg;*.png";
            if (ofd.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                // загружаем выбранную картинку
                try
                {
                    Bitmap bm = new Bitmap(ofd.FileName);
                    if (bm.Width != Program.NeuronSize || bm.Height != Program.NeuronSize)
                    {
                        MessageBox.Show(this, "Возможно выбрать изображение только с размером " + Program.NeuronSize.ToString() + "*" + Program.NeuronSize.ToString() + "\n\rВ дальнейшем нужно запилить автообрезатель.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    bufferImage.Image = new Bitmap(ofd.FileName);
                    if (bufferImage.Image != null)
                    {
                        bufferImage.MakeMonochrome(127);
                        pbOriginImage.Image = bufferImage.Image;
                    }
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(this, Ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnChangeImagesPath_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    tbImagesPath.Text = dialog.SelectedPath;
                }
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (pbOriginImage.Image == null)
            {
                MessageBox.Show(this, "Установите эталонное изображение!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!System.IO.Directory.Exists(tbImagesPath.Text))
            {
                MessageBox.Show(this, "Директория \"" + tbImagesPath.Text + "\" не существует!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            string[] Files = System.IO.Directory.GetFiles(tbImagesPath.Text);
            List<string> ImageFiles = new List<string>();

            // отбираем только файлы, содержащие изображения
            for (int i = 0; i < Files.Length; i++)
            {
                System.IO.FileInfo fi = new System.IO.FileInfo(Files[i]);
                string ext = fi.Extension;
                if (ext == ".bmp" || ext == ".png" || ext == ".jpg")
                {
                    ImageFiles.Add(Files[i]);
                }
            }

            // Преобразовываем эталонное изображение в массив чисел от 0 до 255
            // так как изображение монохромное, то достаточно извлеч только один цвет
            byte[,] Etalon = bufferImage.RedSource();
            // преобразуем в double
            double[,] EtalonOutput = new double[Etalon.GetLength(0), Etalon.GetLength(1)];
            for (int i = 0; i < Etalon.GetLength(0); i++)
            {
                for (int j = 0; j < Etalon.GetLength(1); j++)
                {
                    EtalonOutput[i, j] = Etalon[i, j] > 127 ? 1 : 0;
                }
            }

            // Начинаем обучение
            Program.dlp.ClearWeight();
            for (int i_files = 0; i_files < ImageFiles.Count; i_files++)
            {
                // загружаем изображение
                Bitmap ImageBitmap = new Bitmap(ImageFiles[i_files]);
                if (ImageBitmap.Width != Program.NeuronSize || ImageBitmap.Height != Program.NeuronSize)
                {
                    continue; // пропускаем картинки, которые не по размеру
                }
                
                ImageShell ishell = new ImageShell(ImageBitmap);
                
                // создаем контур изображения
                //ishell.Soble();
                ishell.MakeMonochrome(127);

                byte[,] InputSignalByte = ishell.RedSource();
                // преобразуем в double
                double[,] InputSignal = new double[InputSignalByte.GetLength(0), InputSignalByte.GetLength(1)];
                for (int i = 0; i < InputSignal.GetLength(0); i++)
                {
                    for (int j = 0; j < InputSignal.GetLength(1); j++)
                    {
                        InputSignal[i, j] = InputSignalByte[i, j];
                    }
                }

                // записываем входные параметры
                for (int i = 0; i < Program.dlp.Width; i++)
                {
                    for (int j = 0; j < Program.dlp.Height; j++)
                    {
                        Program.dlp[i, j] = InputSignal[i, j];
                    }
                }
                

                Program.dlp.Training(EtalonOutput);

            }

            pbResultBox.Image = Program.dlp.BitmapFromFirstLayer();
            //Program.dlp.SaveFirstLayerToFile("WeightMatrix.txt");    
        }
    }
}
