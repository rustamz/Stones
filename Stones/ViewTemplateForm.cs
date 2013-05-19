using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlServerCe;

namespace Stones
{
    public partial class ViewTemplateForm : Form
    {
        private SqlCeConnection mainDBConnection = null;

        public ViewTemplateForm()
        {
            InitializeComponent();
        }

        private void DBManagerUIForm_Load(object sender, EventArgs e)
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

            LoadTemplates();
        }

        private void LoadTemplates()
        {
            ListView WorkedListView = TemplateList;

            if (mainDBConnection == null)
                return;
            SqlCeCommand scc = new SqlCeCommand();
            scc.Connection = mainDBConnection;

            scc.CommandText = "SELECT TemplateId, Description, CreationDate, DataWidth, DataHeight, TemplateCategoryId FROM Template;";

            WorkedListView.BeginUpdate();
            WorkedListView.Items.Clear();
            try
            {
                SqlCeDataReader scedr = scc.ExecuteReader();

                if (scedr != null)
                {
                    while (scedr.Read())
                    {
                        ListViewItem lvi = new ListViewItem(scedr["Description"].ToString());
                        lvi.Tag = System.Convert.ToInt32(scedr["TemplateId"].ToString());
                        lvi.SubItems.Add(scedr["DataWidth"].ToString());
                        lvi.SubItems.Add(scedr["DataHeight"].ToString());
                        lvi.SubItems.Add(DateTime.Parse(scedr["CreationDate"].ToString()).ToString());

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
            if (TemplateList.SelectedItems != null)
            {
                if (TemplateList.SelectedItems.Count == 0)
                    return;

                int TemplateId = (int)TemplateList.SelectedItems[0].Tag;

                SqlCeCommand scc = new SqlCeCommand();
                scc.Connection = mainDBConnection;

                scc.CommandText = "SELECT TemplateId, Data FROM Template WHERE TemplateId = @TemplateId;";
                scc.Parameters.Add("@TemplateId", SqlDbType.Int).Value = TemplateId;

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

                        Program.dlp.FromBinary(ImageBuffer);
                        MainImage.Image = Program.dlp.BitmapFromFirstLayer();

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
            if ((new TrainingForm()).ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                LoadTemplates();
            }
        }

        private void tsbDeleteImg_Click(object sender, EventArgs e)
        {
            ListView WorkListView = TemplateList;

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
                scc.Parameters.Add("@TemplateId", SqlDbType.Int);

                foreach (ListViewItem Item in SelectedItems)
                {
                    int TemplateId = (int)Item.Tag;
                    scc.CommandText = "DELETE FROM Template WHERE TemplateId = @TemplateId;";
                    scc.Parameters["@TemplateId"].Value = TemplateId;
                    scc.ExecuteNonQuery();

                    WorkListView.Items.Remove(Item);
                    MainImage.Image = null;
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
