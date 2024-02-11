namespace OpenFuryKMS
{
    partial class WindowsControl
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.serverDrop = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.LicenseStatusLbl = new System.Windows.Forms.Label();
            this.VersionLbl = new System.Windows.Forms.Label();
            this.ProductNameLbl = new System.Windows.Forms.Label();
            this.DeactivateButton = new System.Windows.Forms.Button();
            this.ActivateButton = new System.Windows.Forms.Button();
            this.ShellBox = new System.Windows.Forms.TextBox();
            this.InfoButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.productDrop = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.licenseDrop = new System.Windows.Forms.ComboBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.methodDrop = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.productLogo = new FontAwesome.Sharp.IconPictureBox();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.serverDrop);
            this.panel3.Location = new System.Drawing.Point(20, 250);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(695, 50);
            this.panel3.TabIndex = 29;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(10, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "KMS Server";
            // 
            // serverDrop
            // 
            this.serverDrop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.serverDrop.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serverDrop.FormattingEnabled = true;
            this.serverDrop.Items.AddRange(new object[] {
            "Auto (Recomended)",
            "kms.digiboy.ir",
            "kms.chinancce.com",
            "kms.ddns.net",
            "xykz.f3322.org",
            "dimanyakms.sytes.net",
            "kms.03k.org",
            "ms8.us.to",
            "s8.uk.to",
            "s9.us.to",
            "kms9.msguides.com (UNSTABLE)",
            "kms8.msguides.com (UNSTABLE)"});
            this.serverDrop.Location = new System.Drawing.Point(360, 10);
            this.serverDrop.Name = "serverDrop";
            this.serverDrop.Size = new System.Drawing.Size(324, 28);
            this.serverDrop.TabIndex = 12;
            this.serverDrop.Text = "Select your KMS Server";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(15, 375);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 20);
            this.label5.TabIndex = 31;
            this.label5.Text = "Console";
            // 
            // LicenseStatusLbl
            // 
            this.LicenseStatusLbl.AutoSize = true;
            this.LicenseStatusLbl.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LicenseStatusLbl.ForeColor = System.Drawing.Color.White;
            this.LicenseStatusLbl.Location = new System.Drawing.Point(15, 70);
            this.LicenseStatusLbl.Name = "LicenseStatusLbl";
            this.LicenseStatusLbl.Size = new System.Drawing.Size(104, 20);
            this.LicenseStatusLbl.TabIndex = 25;
            this.LicenseStatusLbl.Text = "License Status:";
            // 
            // VersionLbl
            // 
            this.VersionLbl.AutoSize = true;
            this.VersionLbl.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VersionLbl.ForeColor = System.Drawing.Color.White;
            this.VersionLbl.Location = new System.Drawing.Point(15, 50);
            this.VersionLbl.Name = "VersionLbl";
            this.VersionLbl.Size = new System.Drawing.Size(81, 20);
            this.VersionLbl.TabIndex = 24;
            this.VersionLbl.Text = "Version: 1X";
            // 
            // ProductNameLbl
            // 
            this.ProductNameLbl.AutoSize = true;
            this.ProductNameLbl.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductNameLbl.ForeColor = System.Drawing.Color.White;
            this.ProductNameLbl.Location = new System.Drawing.Point(15, 30);
            this.ProductNameLbl.Name = "ProductNameLbl";
            this.ProductNameLbl.Size = new System.Drawing.Size(137, 20);
            this.ProductNameLbl.TabIndex = 23;
            this.ProductNameLbl.Text = "Microsoft Windows";
            // 
            // DeactivateButton
            // 
            this.DeactivateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DeactivateButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(90)))), ((int)(((byte)(25)))));
            this.DeactivateButton.FlatAppearance.BorderSize = 0;
            this.DeactivateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeactivateButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeactivateButton.ForeColor = System.Drawing.Color.White;
            this.DeactivateButton.Location = new System.Drawing.Point(600, 513);
            this.DeactivateButton.Name = "DeactivateButton";
            this.DeactivateButton.Size = new System.Drawing.Size(120, 40);
            this.DeactivateButton.TabIndex = 22;
            this.DeactivateButton.Text = "Remove License";
            this.DeactivateButton.UseVisualStyleBackColor = false;
            // 
            // ActivateButton
            // 
            this.ActivateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ActivateButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(230)))), ((int)(((byte)(160)))));
            this.ActivateButton.FlatAppearance.BorderSize = 0;
            this.ActivateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ActivateButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ActivateButton.Location = new System.Drawing.Point(20, 513);
            this.ActivateButton.Name = "ActivateButton";
            this.ActivateButton.Size = new System.Drawing.Size(120, 40);
            this.ActivateButton.TabIndex = 21;
            this.ActivateButton.Text = "Activate!";
            this.ActivateButton.UseVisualStyleBackColor = false;
            this.ActivateButton.Click += new System.EventHandler(this.ActivateButton_Click);
            // 
            // ShellBox
            // 
            this.ShellBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ShellBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ShellBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ShellBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShellBox.ForeColor = System.Drawing.Color.White;
            this.ShellBox.Location = new System.Drawing.Point(20, 400);
            this.ShellBox.Multiline = true;
            this.ShellBox.Name = "ShellBox";
            this.ShellBox.ReadOnly = true;
            this.ShellBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ShellBox.Size = new System.Drawing.Size(540, 105);
            this.ShellBox.TabIndex = 20;
            // 
            // InfoButton
            // 
            this.InfoButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.InfoButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(65)))), ((int)(((byte)(230)))));
            this.InfoButton.FlatAppearance.BorderSize = 0;
            this.InfoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InfoButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InfoButton.ForeColor = System.Drawing.Color.White;
            this.InfoButton.Location = new System.Drawing.Point(315, 513);
            this.InfoButton.Name = "InfoButton";
            this.InfoButton.Size = new System.Drawing.Size(120, 40);
            this.InfoButton.TabIndex = 19;
            this.InfoButton.Text = "Information";
            this.InfoButton.UseVisualStyleBackColor = false;
            this.InfoButton.Click += new System.EventHandler(this.InfoButton_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panel1.Controls.Add(this.productDrop);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(20, 140);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(695, 50);
            this.panel1.TabIndex = 27;
            // 
            // productDrop
            // 
            this.productDrop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.productDrop.BackColor = System.Drawing.Color.White;
            this.productDrop.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productDrop.ForeColor = System.Drawing.Color.Black;
            this.productDrop.FormattingEnabled = true;
            this.productDrop.Items.AddRange(new object[] {
            "Windows 10 - 11 Home",
            "Windows 10 - 11 Pro",
            "Windows 10 - 11 Education",
            "Windows 10 - 11 Enterprise"});
            this.productDrop.Location = new System.Drawing.Point(360, 10);
            this.productDrop.Name = "productDrop";
            this.productDrop.Size = new System.Drawing.Size(325, 28);
            this.productDrop.TabIndex = 11;
            this.productDrop.Text = "Select your Windows version";
            this.productDrop.SelectedIndexChanged += new System.EventHandler(this.productDrop_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(10, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Product";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.licenseDrop);
            this.panel2.Location = new System.Drawing.Point(20, 195);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(695, 50);
            this.panel2.TabIndex = 28;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(10, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "License";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // licenseDrop
            // 
            this.licenseDrop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.licenseDrop.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.licenseDrop.FormattingEnabled = true;
            this.licenseDrop.Location = new System.Drawing.Point(360, 10);
            this.licenseDrop.Name = "licenseDrop";
            this.licenseDrop.Size = new System.Drawing.Size(324, 28);
            this.licenseDrop.TabIndex = 12;
            this.licenseDrop.Text = "Select your License Key";
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.methodDrop);
            this.panel4.Location = new System.Drawing.Point(20, 305);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(695, 50);
            this.panel4.TabIndex = 30;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(10, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(132, 20);
            this.label7.TabIndex = 10;
            this.label7.Text = "Activation Method";
            // 
            // methodDrop
            // 
            this.methodDrop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.methodDrop.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.methodDrop.FormattingEnabled = true;
            this.methodDrop.Items.AddRange(new object[] {
            "First Activation",
            "Manual Renew",
            "Rearm"});
            this.methodDrop.Location = new System.Drawing.Point(360, 10);
            this.methodDrop.Name = "methodDrop";
            this.methodDrop.Size = new System.Drawing.Size(324, 28);
            this.methodDrop.TabIndex = 12;
            this.methodDrop.Text = "Select your Activation Method";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(15, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(172, 25);
            this.label4.TabIndex = 30;
            this.label4.Text = "Product Activation";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(15, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(187, 25);
            this.label3.TabIndex = 26;
            this.label3.Text = "Product Information";
            // 
            // productLogo
            // 
            this.productLogo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.productLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.productLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.productLogo.IconChar = FontAwesome.Sharp.IconChar.Microsoft;
            this.productLogo.IconColor = System.Drawing.Color.White;
            this.productLogo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.productLogo.IconSize = 105;
            this.productLogo.Location = new System.Drawing.Point(566, 400);
            this.productLogo.Name = "productLogo";
            this.productLogo.Size = new System.Drawing.Size(154, 105);
            this.productLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.productLogo.TabIndex = 32;
            this.productLogo.TabStop = false;
            // 
            // WindowsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.Controls.Add(this.productLogo);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LicenseStatusLbl);
            this.Controls.Add(this.VersionLbl);
            this.Controls.Add(this.ProductNameLbl);
            this.Controls.Add(this.DeactivateButton);
            this.Controls.Add(this.ActivateButton);
            this.Controls.Add(this.ShellBox);
            this.Controls.Add(this.InfoButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "WindowsControl";
            this.Size = new System.Drawing.Size(740, 560);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox serverDrop;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label LicenseStatusLbl;
        private System.Windows.Forms.Label VersionLbl;
        private System.Windows.Forms.Label ProductNameLbl;
        private System.Windows.Forms.Button DeactivateButton;
        private System.Windows.Forms.Button ActivateButton;
        private System.Windows.Forms.TextBox ShellBox;
        private System.Windows.Forms.Button InfoButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox productDrop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox licenseDrop;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox methodDrop;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private FontAwesome.Sharp.IconPictureBox productLogo;
    }
}
