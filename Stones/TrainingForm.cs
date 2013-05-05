using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data.SqlServerCe;

namespace Stones
{
    
    public partial class TrainingForm : Form
    {
        // Хранения названия и идентификатора категории в Combobox -е
        private class CategoryCBItem
        {
            public int Id { get; set; }
            public string Description { get; set; }

            public CategoryCBItem(int Id, string Description)
            {
                this.Id = Id;
                this.Description = Description;
            }

            public override string ToString()
            {
                return Description;
            }
        }

        // Соединение для работы с БД
        SqlCeConnection mainDBConnection = null;
        
        private ImageShell bufferImage = new ImageShell();

        public TrainingForm()
        {
            InitializeComponent();
        }

        private void LoadCategory()
        {
            if (mainDBConnection == null)
            {
                return;
            }

            SqlCeCommand scc = new SqlCeCommand();
            scc.Connection = mainDBConnection;

            scc.CommandText = "SELECT TemplateCategoryId, Description FROM TemplateCategory";

            SqlCeDataReader scedr = scc.ExecuteReader();

            while (scedr.Read())
            {
                CBCategory.Items.Add(new CategoryCBItem((int)scedr["TemplateCategoryId"], scedr["Description"].ToString()));
            }
        }

        private void btnChangeImagesPath_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                if (System.IO.Directory.Exists(tbImagesPath.Text))
                {
                    dialog.SelectedPath = tbImagesPath.Text;
                }

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    tbImagesPath.Text = dialog.SelectedPath;
                }
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            // Проверка на правильность указания директории с эталонами
            if (!System.IO.Directory.Exists(tbImagesPath.Text))
            {
                MessageBox.Show(this, "Директория \"" + tbImagesPath.Text + "\" не существует!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            // получаем все файлы из директории с эталонами
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

            int ImageCount = 0;
            int GoodImageCount = 0;

            // Начинаем обучение
            Program.dlp.ClearWeight();
            ImageCount = ImageFiles.Count;
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
                

                Program.dlp.Training();
                GoodImageCount++;
            }

            pbResultBox.Image = Program.dlp.BitmapFromFirstLayer();

            label6.Text = ImageCount.ToString();
            label7.Text = GoodImageCount.ToString();
            label8.Text = (ImageCount - GoodImageCount).ToString();
            
            tbDescription.Enabled = true;
            btnSave.Enabled = true;
            CBCategory.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Размеры матрицы
            int WeightMatrixWidth = Program.dlp.Width;
            int WeightMatrixHeight = Program.dlp.Height;

            // Описание шаблона
            string Description = tbDescription.Text;

            // Категория к которой относится шаблон
            int CategoryId = -1;
            if (CBCategory.SelectedItem != null)
            {
                CategoryId = ((CategoryCBItem)CBCategory.SelectedItem).Id;
            }

            // Текущая дата и время
            DateTime CurrentTime = DateTime.Now;

            // Бинарный поток матрицы весов
            byte[] WeightMatrix = Program.dlp.GetBinary();

            if (Description.Length == 0)
            {
                MessageBox.Show(this, "Установите описание для записи в БД", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (CategoryId == -1)
            {
                MessageBox.Show(this, "Выберите категорию для записи в БД", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SqlCeCommand scc = new SqlCeCommand();
            scc.Connection = mainDBConnection;

            scc.CommandText = "INSERT INTO Template (Description, TemplateCategoryId, CreationDate, Data, DataWidth, DataHeight) \n\r" +
            "  VALUES(@Description, @TemplateCategoryId, @CreationDate, @Data, @DataWidth, @DataHeight)";


            scc.Parameters.Add("@Description", System.Data.SqlDbType.NVarChar).Value = Description;
            scc.Parameters.Add("@TemplateCategoryId", System.Data.SqlDbType.Int).Value = CategoryId;
            scc.Parameters.Add("@CreationDate", System.Data.SqlDbType.DateTime).Value = CurrentTime;
            scc.Parameters.Add("@Data", System.Data.SqlDbType.Image).Value = WeightMatrix;
            scc.Parameters.Add("@DataWidth", System.Data.SqlDbType.Int).Value = WeightMatrixWidth;
            scc.Parameters.Add("@DataHeight", System.Data.SqlDbType.Int).Value = WeightMatrixHeight;
           
            try
            {
                scc.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void TrainingForm_Load(object sender, EventArgs e)
        {
            try
            {
                mainDBConnection = new SqlCeConnection("Data Source = \"" + Program.MainDataBaseName + "\"");
                mainDBConnection.Open();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                mainDBConnection = null;
            }

            LoadCategory();
        }
    }
}
