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
            this.kmsLbl = new System.Windows.Forms.Label();
            this.serverDrop = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.statusLbl = new System.Windows.Forms.Label();
            this.versionLbl = new System.Windows.Forms.Label();
            this.osLbl = new System.Windows.Forms.Label();
            this.removeBtn = new System.Windows.Forms.Button();
            this.activateBtn = new System.Windows.Forms.Button();
            this.shellBox = new System.Windows.Forms.TextBox();
            this.infoBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.productDrop = new System.Windows.Forms.ComboBox();
            this.productLbl = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.licenseLbl = new System.Windows.Forms.Label();
            this.licenseDrop = new System.Windows.Forms.ComboBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.methodLbl = new System.Windows.Forms.Label();
            this.methodDrop = new System.Windows.Forms.ComboBox();
            this.actTitleLbl = new System.Windows.Forms.Label();
            this.infoTitleLbl = new System.Windows.Forms.Label();
            this.productLogo = new System.Windows.Forms.PictureBox();
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
            this.panel3.Controls.Add(this.kmsLbl);
            this.panel3.Controls.Add(this.serverDrop);
            this.panel3.Location = new System.Drawing.Point(20, 250);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(695, 50);
            this.panel3.TabIndex = 29;
            // 
            // kmsLbl
            // 
            this.kmsLbl.AutoSize = true;
            this.kmsLbl.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kmsLbl.ForeColor = System.Drawing.Color.White;
            this.kmsLbl.Location = new System.Drawing.Point(10, 13);
            this.kmsLbl.Name = "kmsLbl";
            this.kmsLbl.Size = new System.Drawing.Size(84, 20);
            this.kmsLbl.TabIndex = 10;
            this.kmsLbl.Text = "KMS Server";
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
            this.serverDrop.Location = new System.Drawing.Point(275, 10);
            this.serverDrop.Name = "serverDrop";
            this.serverDrop.Size = new System.Drawing.Size(409, 28);
            this.serverDrop.TabIndex = 12;
            this.serverDrop.Text = "Select your KMS Server";
            this.serverDrop.SelectedIndexChanged += new System.EventHandler(this.serverDrop_SelectedIndexChanged);
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
            // statusLbl
            // 
            this.statusLbl.AutoSize = true;
            this.statusLbl.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLbl.ForeColor = System.Drawing.Color.White;
            this.statusLbl.Location = new System.Drawing.Point(15, 70);
            this.statusLbl.Name = "statusLbl";
            this.statusLbl.Size = new System.Drawing.Size(104, 20);
            this.statusLbl.TabIndex = 25;
            this.statusLbl.Text = "License Status:";
            // 
            // versionLbl
            // 
            this.versionLbl.AutoSize = true;
            this.versionLbl.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.versionLbl.ForeColor = System.Drawing.Color.White;
            this.versionLbl.Location = new System.Drawing.Point(15, 50);
            this.versionLbl.Name = "versionLbl";
            this.versionLbl.Size = new System.Drawing.Size(81, 20);
            this.versionLbl.TabIndex = 24;
            this.versionLbl.Text = "Version: 1X";
            // 
            // osLbl
            // 
            this.osLbl.AutoSize = true;
            this.osLbl.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.osLbl.ForeColor = System.Drawing.Color.White;
            this.osLbl.Location = new System.Drawing.Point(15, 30);
            this.osLbl.Name = "osLbl";
            this.osLbl.Size = new System.Drawing.Size(137, 20);
            this.osLbl.TabIndex = 23;
            this.osLbl.Text = "Microsoft Windows";
            // 
            // removeBtn
            // 
            this.removeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.removeBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(90)))), ((int)(((byte)(25)))));
            this.removeBtn.FlatAppearance.BorderSize = 0;
            this.removeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.removeBtn.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeBtn.ForeColor = System.Drawing.Color.White;
            this.removeBtn.Location = new System.Drawing.Point(600, 513);
            this.removeBtn.Name = "removeBtn";
            this.removeBtn.Size = new System.Drawing.Size(120, 40);
            this.removeBtn.TabIndex = 22;
            this.removeBtn.Text = "Remove License";
            this.removeBtn.UseVisualStyleBackColor = false;
            this.removeBtn.Click += new System.EventHandler(this.removeBtn_Click);
            // 
            // activateBtn
            // 
            this.activateBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.activateBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(230)))), ((int)(((byte)(160)))));
            this.activateBtn.FlatAppearance.BorderSize = 0;
            this.activateBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.activateBtn.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.activateBtn.Location = new System.Drawing.Point(20, 513);
            this.activateBtn.Name = "activateBtn";
            this.activateBtn.Size = new System.Drawing.Size(120, 40);
            this.activateBtn.TabIndex = 21;
            this.activateBtn.Text = "Activate!";
            this.activateBtn.UseVisualStyleBackColor = false;
            this.activateBtn.Click += new System.EventHandler(this.activateBtn_Click);
            // 
            // shellBox
            // 
            this.shellBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.shellBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.shellBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.shellBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shellBox.ForeColor = System.Drawing.Color.White;
            this.shellBox.Location = new System.Drawing.Point(20, 400);
            this.shellBox.Multiline = true;
            this.shellBox.Name = "shellBox";
            this.shellBox.ReadOnly = true;
            this.shellBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.shellBox.Size = new System.Drawing.Size(540, 105);
            this.shellBox.TabIndex = 20;
            // 
            // infoBtn
            // 
            this.infoBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.infoBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(65)))), ((int)(((byte)(230)))));
            this.infoBtn.FlatAppearance.BorderSize = 0;
            this.infoBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.infoBtn.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoBtn.ForeColor = System.Drawing.Color.White;
            this.infoBtn.Location = new System.Drawing.Point(315, 513);
            this.infoBtn.Name = "infoBtn";
            this.infoBtn.Size = new System.Drawing.Size(120, 40);
            this.infoBtn.TabIndex = 19;
            this.infoBtn.Text = "Information";
            this.infoBtn.UseVisualStyleBackColor = false;
            this.infoBtn.Click += new System.EventHandler(this.infoBtn_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panel1.Controls.Add(this.productDrop);
            this.panel1.Controls.Add(this.productLbl);
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
            this.productDrop.Location = new System.Drawing.Point(275, 10);
            this.productDrop.Name = "productDrop";
            this.productDrop.Size = new System.Drawing.Size(410, 28);
            this.productDrop.TabIndex = 11;
            this.productDrop.Text = "Select your Windows version";
            this.productDrop.SelectedIndexChanged += new System.EventHandler(this.productDrop_SelectedIndexChanged);
            // 
            // productLbl
            // 
            this.productLbl.AutoSize = true;
            this.productLbl.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productLbl.ForeColor = System.Drawing.Color.White;
            this.productLbl.Location = new System.Drawing.Point(10, 13);
            this.productLbl.Name = "productLbl";
            this.productLbl.Size = new System.Drawing.Size(60, 20);
            this.productLbl.TabIndex = 9;
            this.productLbl.Text = "Product";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panel2.Controls.Add(this.licenseLbl);
            this.panel2.Controls.Add(this.licenseDrop);
            this.panel2.Location = new System.Drawing.Point(20, 195);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(695, 50);
            this.panel2.TabIndex = 28;
            // 
            // licenseLbl
            // 
            this.licenseLbl.AutoSize = true;
            this.licenseLbl.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.licenseLbl.ForeColor = System.Drawing.Color.White;
            this.licenseLbl.Location = new System.Drawing.Point(10, 13);
            this.licenseLbl.Name = "licenseLbl";
            this.licenseLbl.Size = new System.Drawing.Size(57, 20);
            this.licenseLbl.TabIndex = 10;
            this.licenseLbl.Text = "License";
            this.licenseLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // licenseDrop
            // 
            this.licenseDrop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.licenseDrop.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.licenseDrop.FormattingEnabled = true;
            this.licenseDrop.Location = new System.Drawing.Point(275, 10);
            this.licenseDrop.Name = "licenseDrop";
            this.licenseDrop.Size = new System.Drawing.Size(409, 28);
            this.licenseDrop.TabIndex = 12;
            this.licenseDrop.Text = "Select your License Key";
            this.licenseDrop.SelectedIndexChanged += new System.EventHandler(this.licenseDrop_SelectedIndexChanged);
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panel4.Controls.Add(this.methodLbl);
            this.panel4.Controls.Add(this.methodDrop);
            this.panel4.Location = new System.Drawing.Point(20, 305);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(695, 50);
            this.panel4.TabIndex = 30;
            // 
            // methodLbl
            // 
            this.methodLbl.AutoSize = true;
            this.methodLbl.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.methodLbl.ForeColor = System.Drawing.Color.White;
            this.methodLbl.Location = new System.Drawing.Point(10, 13);
            this.methodLbl.Name = "methodLbl";
            this.methodLbl.Size = new System.Drawing.Size(132, 20);
            this.methodLbl.TabIndex = 10;
            this.methodLbl.Text = "Activation Method";
            // 
            // methodDrop
            // 
            this.methodDrop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.methodDrop.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.methodDrop.FormattingEnabled = true;
            this.methodDrop.Items.AddRange(new object[] {
            "KMS Activation",
            "Renew",
            "Rearm"});
            this.methodDrop.Location = new System.Drawing.Point(275, 10);
            this.methodDrop.Name = "methodDrop";
            this.methodDrop.Size = new System.Drawing.Size(409, 28);
            this.methodDrop.TabIndex = 12;
            this.methodDrop.Text = "Select your Activation Method";
            this.methodDrop.SelectedIndexChanged += new System.EventHandler(this.methodDrop_SelectedIndexChanged);
            // 
            // actTitleLbl
            // 
            this.actTitleLbl.AutoSize = true;
            this.actTitleLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.actTitleLbl.ForeColor = System.Drawing.Color.White;
            this.actTitleLbl.Location = new System.Drawing.Point(15, 110);
            this.actTitleLbl.Name = "actTitleLbl";
            this.actTitleLbl.Size = new System.Drawing.Size(172, 25);
            this.actTitleLbl.TabIndex = 30;
            this.actTitleLbl.Text = "Product Activation";
            // 
            // infoTitleLbl
            // 
            this.infoTitleLbl.AutoSize = true;
            this.infoTitleLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoTitleLbl.ForeColor = System.Drawing.Color.White;
            this.infoTitleLbl.Location = new System.Drawing.Point(15, 5);
            this.infoTitleLbl.Name = "infoTitleLbl";
            this.infoTitleLbl.Size = new System.Drawing.Size(187, 25);
            this.infoTitleLbl.TabIndex = 26;
            this.infoTitleLbl.Text = "Product Information";
            // 
            // productLogo
            // 
            this.productLogo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.productLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.productLogo.Image = global::OpenFuryKMS.Properties.Resources.Windows11;
            this.productLogo.Location = new System.Drawing.Point(566, 402);
            this.productLogo.Name = "productLogo";
            this.productLogo.Size = new System.Drawing.Size(155, 105);
            this.productLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
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
            this.Controls.Add(this.actTitleLbl);
            this.Controls.Add(this.infoTitleLbl);
            this.Controls.Add(this.statusLbl);
            this.Controls.Add(this.versionLbl);
            this.Controls.Add(this.osLbl);
            this.Controls.Add(this.removeBtn);
            this.Controls.Add(this.activateBtn);
            this.Controls.Add(this.shellBox);
            this.Controls.Add(this.infoBtn);
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
        private System.Windows.Forms.Label statusLbl;
        private System.Windows.Forms.Label versionLbl;
        private System.Windows.Forms.Label osLbl;
        private System.Windows.Forms.Button removeBtn;
        private System.Windows.Forms.Button activateBtn;
        private System.Windows.Forms.TextBox shellBox;
        private System.Windows.Forms.Button infoBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox productDrop;
        private System.Windows.Forms.Label productLbl;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label licenseLbl;
        private System.Windows.Forms.ComboBox licenseDrop;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label methodLbl;
        private System.Windows.Forms.ComboBox methodDrop;
        private System.Windows.Forms.Label kmsLbl;
        private System.Windows.Forms.Label actTitleLbl;
        private System.Windows.Forms.Label infoTitleLbl;
        private System.Windows.Forms.PictureBox productLogo;
    }
}
