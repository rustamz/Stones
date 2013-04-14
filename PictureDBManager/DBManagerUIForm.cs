using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlServerCe;

namespace PictureDBManager
{
    public partial class DBManagerUIForm : Form
    {
        private SqlCeConnection mainDBConnection = null;
        private int CurrentRecordID = -1;

        public DBManagerUIForm()
        {
            InitializeComponent();
        }

        private void DBManagerUIForm_Load(object sender, EventArgs e)
        {
            try
            {
                mainDBConnection = new SqlCeConnection("Data Source = PicturesDB.sdf");
                mainDBConnection.Open();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            LoadImages();
        }

        private void LoadImages()
        {
            ListView WorkedListView = listView1;

            if (mainDBConnection == null)
                return;
            SqlCeCommand scc = new SqlCeCommand();
            scc.Connection = mainDBConnection;

            scc.CommandText = "SELECT ImageId, ImageName FROM Image;";

            WorkedListView.BeginUpdate();
            WorkedListView.Items.Clear();
            try
            {
                SqlCeDataReader scedr = scc.ExecuteReader();

                if (scedr != null)
                {
                    while (scedr.Read())
                    {
                        ListViewItem lvi = new ListViewItem(scedr["ImageName"].ToString());
                        lvi.Tag = System.Convert.ToInt32(scedr["ImageId"].ToString());
                        WorkedListView.Items.Add(lvi);
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            WorkedListView.EndUpdate();
        }

        private void DBManagerUIForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (mainDBConnection != null)
                mainDBConnection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems != null)
            {
                if (listView1.SelectedItems.Count == 0)
                    return;

                int ImageId = (int)listView1.SelectedItems[0].Tag;

                SqlCeCommand scc = new SqlCeCommand();
                scc.Connection = mainDBConnection;

                scc.CommandText = "SELECT ImageId, ImageData FROM Image WHERE ImageId = @ImageId;";
                scc.Parameters.Add("@ImageId", SqlDbType.Int).Value = ImageId;

                SqlCeDataReader scedr = scc.ExecuteReader();

                if (scedr != null)
                {
                    if (scedr.Read())
                    {
                        if (scedr.IsDBNull(1))
                            return;

                        int ImageBufferSize = (int)scedr.GetBytes(1, 0, null, 0, int.MaxValue);
                        byte[] ImageBuffer = new byte[ImageBufferSize];
                        scedr.GetBytes(1, 0, ImageBuffer, 0, ImageBufferSize);
                        System.IO.MemoryStream ms = new System.IO.MemoryStream(ImageBuffer);
                        try
                        {
                            MainImage.Image = new Bitmap(ms);
                        }
                        catch (Exception Ex)
                        {
                            MessageBox.Show(this, Ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        ms.Close();
                        CurrentRecordID = ImageId; 
                    }
                }
            }
            else
            {
                MainImage.Image = null;
            }
        }

        private void tsbAddImg_Click(object sender, EventArgs e)
        {
            AddImageForm dlg = new AddImageForm();
            if (dlg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                byte[] Png = null;
                try
                {
                    Png = dlg.GetPngImage();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }

                string PngName = dlg.PictureName;
                SqlCeCommand scc = new SqlCeCommand();
                scc.Connection = mainDBConnection;

                scc.CommandText = "INSERT INTO Image (ImageName, ImageData) VALUES(@ImageName, @ImageData)";

                scc.Parameters.Add("@ImageName", SqlDbType.NVarChar, 100).Value = PngName;
                scc.Parameters.Add("@ImageData", SqlDbType.Image, Png.Length).Value = Png;

                try
                {
                    scc.ExecuteNonQuery();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(this, Ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                LoadImages();

            }
        }

        private void tsbDeleteImg_Click(object sender, EventArgs e)
        {
            ListView WorkListView = listView1;

            ListView.SelectedListViewItemCollection SelectedItems =
                WorkListView.SelectedItems;

            if (SelectedItems == null)
                return;

            if (SelectedItems.Count == 0)
                return;

            WorkListView.BeginUpdate();
            try
            {
                SqlCeCommand scc = new SqlCeCommand();
                scc.Connection = mainDBConnection;
                scc.Parameters.Add("@ImageId", SqlDbType.Int);

                foreach (ListViewItem Item in SelectedItems)
                {
                    int ImageId = (int)Item.Tag;
                    scc.CommandText = "DELETE FROM Image WHERE ImageId = @ImageId;";
                    scc.Parameters["@ImageId"].Value = ImageId;
                    scc.ExecuteNonQuery();

                    WorkListView.Items.Remove(Item);

                    if (ImageId == CurrentRecordID)
                    {
                        MainImage.Image = null;
                        CurrentRecordID = -1;
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            WorkListView.EndUpdate();
        }
    }
}
