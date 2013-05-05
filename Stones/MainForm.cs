using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using PictureDBManager;
using System.Data.SqlServerCe;
using System.Collections.Generic;

namespace Stones
{
    public partial class MainForm : Form
    {
        class TemplateResultItem
        {
            public int TemplateId { get; set; }
            public double Result { get; set; }
            public string Description {get; set;}

            public TemplateResultItem()
            {
 
            }
        }

        private SqlCeConnection mainDBConnection = null;
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
            (new ViewTemplateForm()).ShowDialog(this);
        }

        private void tsmiShowTraining_Click(object sender, EventArgs e)
        {
            (new TrainingForm()).ShowDialog(this);
        }

        private void опознатьToolStripMenuItem_Click(object sender, EventArgs e)
        {

            // Обесцвечиваем входное изображение
            bufferImage.MakeMonochrome(127);

            // Преобразуем входное изображение в численное представление
            // и передаём его в качестве исходных сигналов для распознавания
            byte[,] InputSignalByte = bufferImage.RedSource();
            for (int i = 0; i < InputSignalByte.GetLength(0); i++)
            {
                for (int j = 0; j < InputSignalByte.GetLength(1); j++)
                {
                    Program.dlp[i, j] = InputSignalByte[i, j];
                }
            }

            // Храним тут результат распознавания в формате (идентификатор шаблона, результат)
            List <TemplateResultItem> OutPutResult = new List <TemplateResultItem>(); 
 
            SqlCeCommand scc = new SqlCeCommand();
            scc.Connection = mainDBConnection;
            scc.CommandText = "SELECT TemplateId, Data, Description FROM Template";
            SqlCeDataReader scedr = scc.ExecuteReader();

            if (scedr != null)
            {
                while (scedr.Read())
                {

                    // Подгружаем шаблон
                    if (scedr.IsDBNull(1))
                        return;
                    int ImageBufferSize = (int)scedr.GetBytes(1, 0, null, 0, int.MaxValue);
                    byte[] ImageBuffer = new byte[ImageBufferSize];
                    scedr.GetBytes(1, 0, ImageBuffer, 0, ImageBufferSize);

                    Program.dlp.FromBinary(ImageBuffer);

                    double OutPutResultItem = Program.dlp.Output();

                    OutPutResult.Add( new TemplateResultItem() 
                      { TemplateId = scedr.GetInt32(0), Result = OutPutResultItem, Description = scedr.GetString(2) });

                }
            }

            //Выбираем реузьтат с наибольшим значением индекса
            int MaxResultIndex = 0;
            bool MaxResultSet = false;
            for (int i = 0; i < OutPutResult.Count; i++)
            {
                if (MaxResultSet)
                {
                    if (OutPutResult[MaxResultIndex].Result < OutPutResult[i].Result)
                    {
                        MaxResultIndex = i;
                    }
                }
                else
                {
                    MaxResultSet = true;
                    MaxResultIndex = i;
                }
            }

            if (MaxResultSet)
            {
                if (OutPutResult[MaxResultIndex].Result > 0)
                {
                    MessageBox.Show(this, "Скорее всего на изображении: " + OutPutResult[MaxResultIndex].Description, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(this, "Изображение не опознано", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                mainDBConnection = new SqlCeConnection("Data Source = \"" + Program.MainDataBaseName + "\"");
                mainDBConnection.Open();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
