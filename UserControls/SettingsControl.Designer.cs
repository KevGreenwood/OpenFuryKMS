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
            this.settingsLbl = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.langDrop = new System.Windows.Forms.ComboBox();
            this.langLbl = new System.Windows.Forms.Label();
            this.removeWindowsBtn = new FontAwesome.Sharp.IconButton();
            this.aboutLbl = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.renewLbl = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.downloadBtn = new FontAwesome.Sharp.IconButton();
            this.updatesLbl = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.finalLbl = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
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
            // settingsLbl
            // 
            this.settingsLbl.AutoSize = true;
            this.settingsLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settingsLbl.ForeColor = System.Drawing.Color.White;
            this.settingsLbl.Location = new System.Drawing.Point(15, 5);
            this.settingsLbl.Name = "settingsLbl";
            this.settingsLbl.Size = new System.Drawing.Size(81, 25);
            this.settingsLbl.TabIndex = 27;
            this.settingsLbl.Text = "Settings";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panel1.Controls.Add(this.langDrop);
            this.panel1.Controls.Add(this.langLbl);
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
            this.langDrop.Location = new System.Drawing.Point(340, 10);
            this.langDrop.Name = "langDrop";
            this.langDrop.Size = new System.Drawing.Size(345, 28);
            this.langDrop.TabIndex = 11;
            this.langDrop.Text = "Select your Language";
            this.langDrop.SelectedIndexChanged += new System.EventHandler(this.langDrop_SelectedIndexChanged);
            // 
            // langLbl
            // 
            this.langLbl.AutoSize = true;
            this.langLbl.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.langLbl.ForeColor = System.Drawing.Color.White;
            this.langLbl.Location = new System.Drawing.Point(10, 13);
            this.langLbl.Name = "langLbl";
            this.langLbl.Size = new System.Drawing.Size(74, 20);
            this.langLbl.TabIndex = 9;
            this.langLbl.Text = "Language";
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
            this.removeWindowsBtn.Location = new System.Drawing.Point(340, 3);
            this.removeWindowsBtn.Name = "removeWindowsBtn";
            this.removeWindowsBtn.Size = new System.Drawing.Size(150, 40);
            this.removeWindowsBtn.TabIndex = 29;
            this.removeWindowsBtn.Text = "Windows";
            this.removeWindowsBtn.UseVisualStyleBackColor = false;
            this.removeWindowsBtn.Click += new System.EventHandler(this.removeWindowsBtn_Click);
            // 
            // aboutLbl
            // 
            this.aboutLbl.AutoSize = true;
            this.aboutLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aboutLbl.ForeColor = System.Drawing.Color.White;
            this.aboutLbl.Location = new System.Drawing.Point(15, 225);
            this.aboutLbl.Name = "aboutLbl";
            this.aboutLbl.Size = new System.Drawing.Size(65, 25);
            this.aboutLbl.TabIndex = 30;
            this.aboutLbl.Text = "About";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panel2.Controls.Add(this.renewLbl);
            this.panel2.Controls.Add(this.removeWindowsBtn);
            this.panel2.Controls.Add(this.removeOfficeBtn);
            this.panel2.Location = new System.Drawing.Point(20, 90);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(695, 50);
            this.panel2.TabIndex = 29;
            // 
            // renewLbl
            // 
            this.renewLbl.AutoSize = true;
            this.renewLbl.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.renewLbl.ForeColor = System.Drawing.Color.White;
            this.renewLbl.Location = new System.Drawing.Point(10, 13);
            this.renewLbl.Name = "renewLbl";
            this.renewLbl.Size = new System.Drawing.Size(147, 20);
            this.renewLbl.TabIndex = 9;
            this.renewLbl.Text = "Remove Auto Renew";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panel3.Controls.Add(this.downloadBtn);
            this.panel3.Controls.Add(this.updatesLbl);
            this.panel3.Location = new System.Drawing.Point(20, 145);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(695, 50);
            this.panel3.TabIndex = 29;
            // 
            // downloadBtn
            // 
            this.downloadBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.downloadBtn.BackColor = System.Drawing.Color.Indigo;
            this.downloadBtn.FlatAppearance.BorderSize = 0;
            this.downloadBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.downloadBtn.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.downloadBtn.ForeColor = System.Drawing.Color.White;
            this.downloadBtn.IconChar = FontAwesome.Sharp.IconChar.Download;
            this.downloadBtn.IconColor = System.Drawing.Color.White;
            this.downloadBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.downloadBtn.IconSize = 40;
            this.downloadBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.downloadBtn.Location = new System.Drawing.Point(340, 3);
            this.downloadBtn.Name = "downloadBtn";
            this.downloadBtn.Size = new System.Drawing.Size(345, 40);
            this.downloadBtn.TabIndex = 30;
            this.downloadBtn.Text = "Download";
            this.downloadBtn.UseVisualStyleBackColor = false;
            // 
            // updatesLbl
            // 
            this.updatesLbl.AutoSize = true;
            this.updatesLbl.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updatesLbl.ForeColor = System.Drawing.Color.White;
            this.updatesLbl.Location = new System.Drawing.Point(10, 13);
            this.updatesLbl.Name = "updatesLbl";
            this.updatesLbl.Size = new System.Drawing.Size(107, 20);
            this.updatesLbl.TabIndex = 9;
            this.updatesLbl.Text = "Check Updates";
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
            // finalLbl
            // 
            this.finalLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.finalLbl.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.finalLbl.ForeColor = System.Drawing.Color.White;
            this.finalLbl.Location = new System.Drawing.Point(15, 422);
            this.finalLbl.Name = "finalLbl";
            this.finalLbl.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.finalLbl.Size = new System.Drawing.Size(725, 138);
            this.finalLbl.TabIndex = 33;
            this.finalLbl.Text = "Windows XX Version";
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(15, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(725, 422);
            this.panel4.TabIndex = 36;
            // 
            // panel5
            // 
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(15, 560);
            this.panel5.TabIndex = 37;
            // 
            // SettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.Controls.Add(this.finalLbl);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.aboutLbl);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.settingsLbl);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel5);
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
        private System.Windows.Forms.Label settingsLbl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox langDrop;
        private System.Windows.Forms.Label langLbl;
        private FontAwesome.Sharp.IconButton removeWindowsBtn;
        private System.Windows.Forms.Label aboutLbl;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label renewLbl;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label updatesLbl;
        private FontAwesome.Sharp.IconButton downloadBtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label finalLbl;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
    }
}
