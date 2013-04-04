namespace Stones
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlImageContainer = new System.Windows.Forms.Panel();
            this.pbMainImage = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiClose = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiService = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMakeGray = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMonochrome = new System.Windows.Forms.ToolStripMenuItem();
            this.sbStatusBar = new System.Windows.Forms.StatusStrip();
            this.tsslFileName = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsmiSobel = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlImageContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMainImage)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.sbStatusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlImageContainer
            // 
            this.pnlImageContainer.AutoScroll = true;
            this.pnlImageContainer.Controls.Add(this.pbMainImage);
            this.pnlImageContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlImageContainer.Location = new System.Drawing.Point(0, 24);
            this.pnlImageContainer.Name = "pnlImageContainer";
            this.pnlImageContainer.Size = new System.Drawing.Size(494, 337);
            this.pnlImageContainer.TabIndex = 0;
            // 
            // pbMainImage
            // 
            this.pbMainImage.Location = new System.Drawing.Point(0, 0);
            this.pbMainImage.Name = "pbMainImage";
            this.pbMainImage.Size = new System.Drawing.Size(414, 264);
            this.pbMainImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbMainImage.TabIndex = 0;
            this.pbMainImage.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFile,
            this.tsmiService});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(494, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmiFile
            // 
            this.tsmiFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiOpen,
            this.toolStripMenuItem1,
            this.tsmiClose});
            this.tsmiFile.Name = "tsmiFile";
            this.tsmiFile.Size = new System.Drawing.Size(48, 20);
            this.tsmiFile.Text = "Файл";
            // 
            // tsmiOpen
            // 
            this.tsmiOpen.Name = "tsmiOpen";
            this.tsmiOpen.Size = new System.Drawing.Size(121, 22);
            this.tsmiOpen.Text = "Открыть";
            this.tsmiOpen.Click += new System.EventHandler(this.tsmiOpen_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(118, 6);
            // 
            // tsmiClose
            // 
            this.tsmiClose.Name = "tsmiClose";
            this.tsmiClose.Size = new System.Drawing.Size(121, 22);
            this.tsmiClose.Text = "Закрыть";
            this.tsmiClose.Click += new System.EventHandler(this.tsmiClose_Click);
            // 
            // tsmiService
            // 
            this.tsmiService.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiMakeGray,
            this.tsmiMonochrome,
            this.tsmiSobel});
            this.tsmiService.Name = "tsmiService";
            this.tsmiService.Size = new System.Drawing.Size(59, 20);
            this.tsmiService.Text = "Сервис";
            // 
            // tsmiMakeGray
            // 
            this.tsmiMakeGray.Name = "tsmiMakeGray";
            this.tsmiMakeGray.Size = new System.Drawing.Size(172, 22);
            this.tsmiMakeGray.Text = "Обесцветить";
            this.tsmiMakeGray.Click += new System.EventHandler(this.tsmiMakeGray_Click);
            // 
            // tsmiMonochrome
            // 
            this.tsmiMonochrome.Name = "tsmiMonochrome";
            this.tsmiMonochrome.Size = new System.Drawing.Size(172, 22);
            this.tsmiMonochrome.Text = "В монохром";
            this.tsmiMonochrome.Click += new System.EventHandler(this.tsmiMonochrome_Click);
            // 
            // sbStatusBar
            // 
            this.sbStatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslFileName});
            this.sbStatusBar.Location = new System.Drawing.Point(0, 339);
            this.sbStatusBar.Name = "sbStatusBar";
            this.sbStatusBar.Size = new System.Drawing.Size(494, 22);
            this.sbStatusBar.TabIndex = 2;
            this.sbStatusBar.Text = "statusStrip1";
            // 
            // tsslFileName
            // 
            this.tsslFileName.Name = "tsslFileName";
            this.tsslFileName.Size = new System.Drawing.Size(69, 17);
            this.tsslFileName.Text = "Имя файла";
            // 
            // tsmiSobel
            // 
            this.tsmiSobel.Name = "tsmiSobel";
            this.tsmiSobel.Size = new System.Drawing.Size(172, 22);
            this.tsmiSobel.Text = "Оператор Cобеля";
            this.tsmiSobel.Click += new System.EventHandler(this.tsmiSobel_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 361);
            this.Controls.Add(this.sbStatusBar);
            this.Controls.Add(this.pnlImageContainer);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Stones";
            this.pnlImageContainer.ResumeLayout(false);
            this.pnlImageContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMainImage)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.sbStatusBar.ResumeLayout(false);
            this.sbStatusBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlImageContainer;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tsmiClose;
        private System.Windows.Forms.PictureBox pbMainImage;
        private System.Windows.Forms.StatusStrip sbStatusBar;
        private System.Windows.Forms.ToolStripStatusLabel tsslFileName;
        private System.Windows.Forms.ToolStripMenuItem tsmiService;
        private System.Windows.Forms.ToolStripMenuItem tsmiMakeGray;
        private System.Windows.Forms.ToolStripMenuItem tsmiMonochrome;
        private System.Windows.Forms.ToolStripMenuItem tsmiSobel;
    }
}

