﻿namespace Stones
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiClose = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiService = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMakeGray = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMonochrome = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSobel = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiContour = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiDBManager = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiShowTraining = new System.Windows.Forms.ToolStripMenuItem();
            this.опознатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sbStatusBar = new System.Windows.Forms.StatusStrip();
            this.tsslFileName = new System.Windows.Forms.ToolStripStatusLabel();
            this.MainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.pnlImageContainer = new System.Windows.Forms.Panel();
            this.pbMainImage = new System.Windows.Forms.PictureBox();
            this.lvFoundedImages = new System.Windows.Forms.ListView();
            this.menuStrip1.SuspendLayout();
            this.sbStatusBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).BeginInit();
            this.MainSplitContainer.Panel1.SuspendLayout();
            this.MainSplitContainer.Panel2.SuspendLayout();
            this.MainSplitContainer.SuspendLayout();
            this.pnlImageContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMainImage)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFile,
            this.tsmiService});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(632, 24);
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
            this.tsmiSobel,
            this.tsmiContour,
            this.toolStripMenuItem2,
            this.tsmiDBManager,
            this.tsmiShowTraining,
            this.опознатьToolStripMenuItem});
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
            // tsmiSobel
            // 
            this.tsmiSobel.Name = "tsmiSobel";
            this.tsmiSobel.Size = new System.Drawing.Size(172, 22);
            this.tsmiSobel.Text = "Оператор Cобеля";
            this.tsmiSobel.Click += new System.EventHandler(this.tsmiSobel_Click);
            // 
            // tsmiContour
            // 
            this.tsmiContour.Name = "tsmiContour";
            this.tsmiContour.Size = new System.Drawing.Size(172, 22);
            this.tsmiContour.Text = "Поиск контура";
            this.tsmiContour.Click += new System.EventHandler(this.tsmiContour_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(169, 6);
            // 
            // tsmiDBManager
            // 
            this.tsmiDBManager.Name = "tsmiDBManager";
            this.tsmiDBManager.Size = new System.Drawing.Size(172, 22);
            this.tsmiDBManager.Text = "Редактировать БД";
            this.tsmiDBManager.Click += new System.EventHandler(this.tsmiDBManager_Click);
            // 
            // tsmiShowTraining
            // 
            this.tsmiShowTraining.Name = "tsmiShowTraining";
            this.tsmiShowTraining.Size = new System.Drawing.Size(172, 22);
            this.tsmiShowTraining.Text = "Обучение";
            this.tsmiShowTraining.Click += new System.EventHandler(this.tsmiShowTraining_Click);
            // 
            // опознатьToolStripMenuItem
            // 
            this.опознатьToolStripMenuItem.Name = "опознатьToolStripMenuItem";
            this.опознатьToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.опознатьToolStripMenuItem.Text = "Опознать";
            this.опознатьToolStripMenuItem.Click += new System.EventHandler(this.опознатьToolStripMenuItem_Click);
            // 
            // sbStatusBar
            // 
            this.sbStatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslFileName});
            this.sbStatusBar.Location = new System.Drawing.Point(0, 370);
            this.sbStatusBar.Name = "sbStatusBar";
            this.sbStatusBar.Size = new System.Drawing.Size(632, 22);
            this.sbStatusBar.TabIndex = 2;
            this.sbStatusBar.Text = "statusStrip1";
            // 
            // tsslFileName
            // 
            this.tsslFileName.Name = "tsslFileName";
            this.tsslFileName.Size = new System.Drawing.Size(69, 17);
            this.tsslFileName.Text = "Имя файла";
            // 
            // MainSplitContainer
            // 
            this.MainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainSplitContainer.Location = new System.Drawing.Point(0, 24);
            this.MainSplitContainer.Name = "MainSplitContainer";
            // 
            // MainSplitContainer.Panel1
            // 
            this.MainSplitContainer.Panel1.Controls.Add(this.pnlImageContainer);
            // 
            // MainSplitContainer.Panel2
            // 
            this.MainSplitContainer.Panel2.Controls.Add(this.lvFoundedImages);
            this.MainSplitContainer.Size = new System.Drawing.Size(632, 346);
            this.MainSplitContainer.SplitterDistance = 464;
            this.MainSplitContainer.TabIndex = 3;
            // 
            // pnlImageContainer
            // 
            this.pnlImageContainer.AutoScroll = true;
            this.pnlImageContainer.Controls.Add(this.pbMainImage);
            this.pnlImageContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlImageContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlImageContainer.Name = "pnlImageContainer";
            this.pnlImageContainer.Size = new System.Drawing.Size(464, 346);
            this.pnlImageContainer.TabIndex = 1;
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
            // lvFoundedImages
            // 
            this.lvFoundedImages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvFoundedImages.Location = new System.Drawing.Point(0, 0);
            this.lvFoundedImages.Name = "lvFoundedImages";
            this.lvFoundedImages.Size = new System.Drawing.Size(164, 346);
            this.lvFoundedImages.TabIndex = 0;
            this.lvFoundedImages.UseCompatibleStateImageBehavior = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 392);
            this.Controls.Add(this.MainSplitContainer);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.sbStatusBar);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Stones";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.sbStatusBar.ResumeLayout(false);
            this.sbStatusBar.PerformLayout();
            this.MainSplitContainer.Panel1.ResumeLayout(false);
            this.MainSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).EndInit();
            this.MainSplitContainer.ResumeLayout(false);
            this.pnlImageContainer.ResumeLayout(false);
            this.pnlImageContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMainImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tsmiClose;
        private System.Windows.Forms.StatusStrip sbStatusBar;
        private System.Windows.Forms.ToolStripStatusLabel tsslFileName;
        private System.Windows.Forms.ToolStripMenuItem tsmiService;
        private System.Windows.Forms.ToolStripMenuItem tsmiMakeGray;
        private System.Windows.Forms.ToolStripMenuItem tsmiMonochrome;
        private System.Windows.Forms.ToolStripMenuItem tsmiSobel;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem tsmiDBManager;
        private System.Windows.Forms.ToolStripMenuItem tsmiShowTraining;
        private System.Windows.Forms.ToolStripMenuItem опознатьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiContour;
        private System.Windows.Forms.SplitContainer MainSplitContainer;
        private System.Windows.Forms.Panel pnlImageContainer;
        private System.Windows.Forms.PictureBox pbMainImage;
        private System.Windows.Forms.ListView lvFoundedImages;
    }
}

