namespace Stones
{
    partial class ViewTemplateForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewTemplateForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.TemplateList = new System.Windows.Forms.ListView();
            this.lvcImageName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ImageContainer = new System.Windows.Forms.Panel();
            this.MainImage = new System.Windows.Forms.PictureBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbAddImg = new System.Windows.Forms.ToolStripButton();
            this.tsbDeleteImg = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.ImageContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainImage)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 28);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.TemplateList);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ImageContainer);
            this.splitContainer1.Size = new System.Drawing.Size(607, 187);
            this.splitContainer1.SplitterDistance = 401;
            this.splitContainer1.TabIndex = 2;
            // 
            // TemplateList
            // 
            this.TemplateList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lvcImageName,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.TemplateList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TemplateList.FullRowSelect = true;
            this.TemplateList.Location = new System.Drawing.Point(0, 0);
            this.TemplateList.Name = "TemplateList";
            this.TemplateList.Size = new System.Drawing.Size(401, 187);
            this.TemplateList.TabIndex = 1;
            this.TemplateList.UseCompatibleStateImageBehavior = false;
            this.TemplateList.View = System.Windows.Forms.View.Details;
            this.TemplateList.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // lvcImageName
            // 
            this.lvcImageName.Text = "Описание";
            this.lvcImageName.Width = 133;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Ширина";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Высота";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Дата создания";
            this.columnHeader3.Width = 100;
            // 
            // ImageContainer
            // 
            this.ImageContainer.AutoScroll = true;
            this.ImageContainer.Controls.Add(this.MainImage);
            this.ImageContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ImageContainer.Location = new System.Drawing.Point(0, 0);
            this.ImageContainer.Name = "ImageContainer";
            this.ImageContainer.Size = new System.Drawing.Size(202, 187);
            this.ImageContainer.TabIndex = 0;
            // 
            // MainImage
            // 
            this.MainImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainImage.Location = new System.Drawing.Point(0, 0);
            this.MainImage.Name = "MainImage";
            this.MainImage.Size = new System.Drawing.Size(202, 187);
            this.MainImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.MainImage.TabIndex = 3;
            this.MainImage.TabStop = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAddImg,
            this.tsbDeleteImg});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(631, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbAddImg
            // 
            this.tsbAddImg.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAddImg.Image = ((System.Drawing.Image)(resources.GetObject("tsbAddImg.Image")));
            this.tsbAddImg.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAddImg.Name = "tsbAddImg";
            this.tsbAddImg.Size = new System.Drawing.Size(23, 22);
            this.tsbAddImg.Text = "toolStripButton1";
            this.tsbAddImg.Click += new System.EventHandler(this.tsbAddImg_Click);
            // 
            // tsbDeleteImg
            // 
            this.tsbDeleteImg.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDeleteImg.Image = ((System.Drawing.Image)(resources.GetObject("tsbDeleteImg.Image")));
            this.tsbDeleteImg.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDeleteImg.Name = "tsbDeleteImg";
            this.tsbDeleteImg.Size = new System.Drawing.Size(23, 22);
            this.tsbDeleteImg.Text = "Удалить изображение";
            this.tsbDeleteImg.Click += new System.EventHandler(this.tsbDeleteImg_Click);
            // 
            // ViewTemplateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 223);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.splitContainer1);
            this.Name = "ViewTemplateForm";
            this.Text = "Редактировать БД";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DBManagerUIForm_FormClosed);
            this.Load += new System.EventHandler(this.DBManagerUIForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ImageContainer.ResumeLayout(false);
            this.ImageContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainImage)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView TemplateList;
        private System.Windows.Forms.ColumnHeader lvcImageName;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbAddImg;
        private System.Windows.Forms.ToolStripButton tsbDeleteImg;
        private System.Windows.Forms.Panel ImageContainer;
        private System.Windows.Forms.PictureBox MainImage;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}