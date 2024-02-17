namespace OpenFuryKMS.UserControls
{
    partial class SettingsControl
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.removeOfficeBtn = new System.Windows.Forms.Button();
            this.infoTitleLbl = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.langDrop = new System.Windows.Forms.ComboBox();
            this.productLbl = new System.Windows.Forms.Label();
            this.removeWindowsBtn = new FontAwesome.Sharp.IconButton();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.WinLbl = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // removeOfficeBtn
            // 
            this.removeOfficeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.removeOfficeBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(60)))), ((int)(((byte)(0)))));
            this.removeOfficeBtn.FlatAppearance.BorderSize = 0;
            this.removeOfficeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.removeOfficeBtn.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.removeOfficeBtn.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.removeOfficeBtn.Image = global::OpenFuryKMS.Properties.Resources.whiteIcon;
            this.removeOfficeBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.removeOfficeBtn.Location = new System.Drawing.Point(535, 3);
            this.removeOfficeBtn.Name = "removeOfficeBtn";
            this.removeOfficeBtn.Size = new System.Drawing.Size(150, 40);
            this.removeOfficeBtn.TabIndex = 0;
            this.removeOfficeBtn.Text = "Office";
            this.removeOfficeBtn.UseVisualStyleBackColor = false;
            this.removeOfficeBtn.Click += new System.EventHandler(this.removeOfficeBtn_Click);
            // 
            // infoTitleLbl
            // 
            this.infoTitleLbl.AutoSize = true;
            this.infoTitleLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoTitleLbl.ForeColor = System.Drawing.Color.White;
            this.infoTitleLbl.Location = new System.Drawing.Point(15, 5);
            this.infoTitleLbl.Name = "infoTitleLbl";
            this.infoTitleLbl.Size = new System.Drawing.Size(81, 25);
            this.infoTitleLbl.TabIndex = 27;
            this.infoTitleLbl.Text = "Settings";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panel1.Controls.Add(this.langDrop);
            this.panel1.Controls.Add(this.productLbl);
            this.panel1.Location = new System.Drawing.Point(20, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(695, 50);
            this.panel1.TabIndex = 28;
            // 
            // langDrop
            // 
            this.langDrop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.langDrop.BackColor = System.Drawing.Color.White;
            this.langDrop.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.langDrop.ForeColor = System.Drawing.Color.Black;
            this.langDrop.FormattingEnabled = true;
            this.langDrop.Items.AddRange(new object[] {
            "English (EN)",
            "Español (ES)",
            "Русский язык (RU)"});
            this.langDrop.Location = new System.Drawing.Point(275, 10);
            this.langDrop.Name = "langDrop";
            this.langDrop.Size = new System.Drawing.Size(410, 28);
            this.langDrop.TabIndex = 11;
            this.langDrop.Text = "Select your Language";
            this.langDrop.SelectedIndexChanged += new System.EventHandler(this.langDrop_SelectedIndexChanged);
            // 
            // productLbl
            // 
            this.productLbl.AutoSize = true;
            this.productLbl.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productLbl.ForeColor = System.Drawing.Color.White;
            this.productLbl.Location = new System.Drawing.Point(10, 13);
            this.productLbl.Name = "productLbl";
            this.productLbl.Size = new System.Drawing.Size(74, 20);
            this.productLbl.TabIndex = 9;
            this.productLbl.Text = "Language";
            // 
            // removeWindowsBtn
            // 
            this.removeWindowsBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.removeWindowsBtn.BackColor = System.Drawing.Color.DodgerBlue;
            this.removeWindowsBtn.FlatAppearance.BorderSize = 0;
            this.removeWindowsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.removeWindowsBtn.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.removeWindowsBtn.ForeColor = System.Drawing.Color.White;
            this.removeWindowsBtn.IconChar = FontAwesome.Sharp.IconChar.Windows;
            this.removeWindowsBtn.IconColor = System.Drawing.Color.White;
            this.removeWindowsBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.removeWindowsBtn.IconSize = 40;
            this.removeWindowsBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.removeWindowsBtn.Location = new System.Drawing.Point(275, 3);
            this.removeWindowsBtn.Name = "removeWindowsBtn";
            this.removeWindowsBtn.Size = new System.Drawing.Size(150, 40);
            this.removeWindowsBtn.TabIndex = 29;
            this.removeWindowsBtn.Text = "Windows";
            this.removeWindowsBtn.UseVisualStyleBackColor = false;
            this.removeWindowsBtn.Click += new System.EventHandler(this.removeWindowsBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(15, 225);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 25);
            this.label1.TabIndex = 30;
            this.label1.Text = "About";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.removeWindowsBtn);
            this.panel2.Controls.Add(this.removeOfficeBtn);
            this.panel2.Location = new System.Drawing.Point(20, 90);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(695, 50);
            this.panel2.TabIndex = 29;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(10, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Remove Auto Renew";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panel3.Controls.Add(this.iconButton1);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(20, 145);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(695, 50);
            this.panel3.TabIndex = 29;
            // 
            // iconButton1
            // 
            this.iconButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconButton1.BackColor = System.Drawing.Color.Indigo;
            this.iconButton1.FlatAppearance.BorderSize = 0;
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.iconButton1.ForeColor = System.Drawing.Color.White;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.Download;
            this.iconButton1.IconColor = System.Drawing.Color.White;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.IconSize = 40;
            this.iconButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton1.Location = new System.Drawing.Point(535, 3);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(150, 40);
            this.iconButton1.TabIndex = 30;
            this.iconButton1.Text = "Download";
            this.iconButton1.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(10, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Check Updates";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::OpenFuryKMS.Properties.Resources.Logo;
            this.pictureBox1.Location = new System.Drawing.Point(20, 255);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(695, 142);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 31;
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(230)))), ((int)(((byte)(160)))));
            this.label4.Location = new System.Drawing.Point(15, 400);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label4.Size = new System.Drawing.Size(225, 25);
            this.label4.TabIndex = 32;
            this.label4.Text = "Kevin Greenwood - 2024";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // WinLbl
            // 
            this.WinLbl.AutoSize = true;
            this.WinLbl.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WinLbl.ForeColor = System.Drawing.Color.White;
            this.WinLbl.Location = new System.Drawing.Point(15, 425);
            this.WinLbl.Name = "WinLbl";
            this.WinLbl.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.WinLbl.Size = new System.Drawing.Size(144, 20);
            this.WinLbl.TabIndex = 33;
            this.WinLbl.Text = "Windows XX Version";
            this.WinLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.Controls.Add(this.WinLbl);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.infoTitleLbl);
            this.Name = "SettingsControl";
            this.Size = new System.Drawing.Size(740, 560);
            this.Load += new System.EventHandler(this.SettingsControl_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button removeOfficeBtn;
        private System.Windows.Forms.Label infoTitleLbl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox langDrop;
        private System.Windows.Forms.Label productLbl;
        private FontAwesome.Sharp.IconButton removeWindowsBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private FontAwesome.Sharp.IconButton iconButton1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label WinLbl;
    }
}
