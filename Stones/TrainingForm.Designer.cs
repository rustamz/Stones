namespace Stones
{
    partial class TrainingForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pbOriginImage = new System.Windows.Forms.PictureBox();
            this.btnLoadOrigin = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbImagesPath = new System.Windows.Forms.TextBox();
            this.btnChangeImagesPath = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.pbResultBox = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbOriginImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbResultBox)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnLoadOrigin);
            this.panel1.Controls.Add(this.pbOriginImage);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(206, 260);
            this.panel1.TabIndex = 0;
            // 
            // pbOriginImage
            // 
            this.pbOriginImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbOriginImage.Location = new System.Drawing.Point(3, 26);
            this.pbOriginImage.Name = "pbOriginImage";
            this.pbOriginImage.Size = new System.Drawing.Size(200, 200);
            this.pbOriginImage.TabIndex = 0;
            this.pbOriginImage.TabStop = false;
            // 
            // btnLoadOrigin
            // 
            this.btnLoadOrigin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadOrigin.Location = new System.Drawing.Point(126, 232);
            this.btnLoadOrigin.Name = "btnLoadOrigin";
            this.btnLoadOrigin.Size = new System.Drawing.Size(75, 23);
            this.btnLoadOrigin.TabIndex = 1;
            this.btnLoadOrigin.Text = "Загрузить";
            this.btnLoadOrigin.UseVisualStyleBackColor = true;
            this.btnLoadOrigin.Click += new System.EventHandler(this.btnLoadOrigin_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Эталон";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(224, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Папка с образцами для обчения:";
            // 
            // tbImagesPath
            // 
            this.tbImagesPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbImagesPath.Location = new System.Drawing.Point(227, 28);
            this.tbImagesPath.Name = "tbImagesPath";
            this.tbImagesPath.Size = new System.Drawing.Size(281, 20);
            this.tbImagesPath.TabIndex = 2;
            // 
            // btnChangeImagesPath
            // 
            this.btnChangeImagesPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChangeImagesPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnChangeImagesPath.Location = new System.Drawing.Point(486, 30);
            this.btnChangeImagesPath.Name = "btnChangeImagesPath";
            this.btnChangeImagesPath.Size = new System.Drawing.Size(20, 16);
            this.btnChangeImagesPath.TabIndex = 4;
            this.btnChangeImagesPath.Text = "...";
            this.btnChangeImagesPath.UseVisualStyleBackColor = true;
            this.btnChangeImagesPath.Click += new System.EventHandler(this.btnChangeImagesPath_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(433, 249);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 5;
            this.btnStart.Text = "Старт";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // pbResultBox
            // 
            this.pbResultBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbResultBox.Location = new System.Drawing.Point(227, 79);
            this.pbResultBox.Name = "pbResultBox";
            this.pbResultBox.Size = new System.Drawing.Size(150, 150);
            this.pbResultBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbResultBox.TabIndex = 6;
            this.pbResultBox.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(224, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Результирующая матрица:";
            // 
            // TrainingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 284);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pbResultBox);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnChangeImagesPath);
            this.Controls.Add(this.tbImagesPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(536, 323);
            this.Name = "TrainingForm";
            this.Text = "Обучение нейросети";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbOriginImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbResultBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pbOriginImage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLoadOrigin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbImagesPath;
        private System.Windows.Forms.Button btnChangeImagesPath;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.PictureBox pbResultBox;
        private System.Windows.Forms.Label label3;
    }
}