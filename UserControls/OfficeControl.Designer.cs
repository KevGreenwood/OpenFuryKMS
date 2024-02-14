namespace OpenFuryKMS
{
    partial class OfficeControl
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
            this.infoBtn = new System.Windows.Forms.Button();
            this.shellBox = new System.Windows.Forms.TextBox();
            this.activateBtn = new System.Windows.Forms.Button();
            this.removeBtn = new System.Windows.Forms.Button();
            this.productName_Lbl = new System.Windows.Forms.Label();
            this.versionLbl = new System.Windows.Forms.Label();
            this.statusLbl = new System.Windows.Forms.Label();
            this.productLbl = new System.Windows.Forms.Label();
            this.serverLbl = new System.Windows.Forms.Label();
            this.productDrop = new System.Windows.Forms.ComboBox();
            this.serverDrop = new System.Windows.Forms.ComboBox();
            this.infoTitle_Lbl = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.actTitle_Lbl = new System.Windows.Forms.Label();
            this.consoleLbl = new System.Windows.Forms.Label();
            this.productLogo = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.methodLbl = new System.Windows.Forms.Label();
            this.methodDrop = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productLogo)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // infoBtn
            // 
            this.infoBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.infoBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(65)))), ((int)(((byte)(230)))));
            this.infoBtn.FlatAppearance.BorderSize = 0;
            this.infoBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.infoBtn.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoBtn.ForeColor = System.Drawing.Color.White;
            this.infoBtn.Location = new System.Drawing.Point(310, 510);
            this.infoBtn.Name = "infoBtn";
            this.infoBtn.Size = new System.Drawing.Size(120, 40);
            this.infoBtn.TabIndex = 0;
            this.infoBtn.Text = "Information";
            this.infoBtn.UseVisualStyleBackColor = false;
            this.infoBtn.Click += new System.EventHandler(this.infoBtn_Click);
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
            this.shellBox.Location = new System.Drawing.Point(20, 345);
            this.shellBox.Multiline = true;
            this.shellBox.Name = "shellBox";
            this.shellBox.ReadOnly = true;
            this.shellBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.shellBox.Size = new System.Drawing.Size(540, 155);
            this.shellBox.TabIndex = 1;
            // 
            // activateBtn
            // 
            this.activateBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.activateBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(230)))), ((int)(((byte)(160)))));
            this.activateBtn.FlatAppearance.BorderSize = 0;
            this.activateBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.activateBtn.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.activateBtn.Location = new System.Drawing.Point(20, 510);
            this.activateBtn.Name = "activateBtn";
            this.activateBtn.Size = new System.Drawing.Size(120, 40);
            this.activateBtn.TabIndex = 2;
            this.activateBtn.Text = "Activate!";
            this.activateBtn.UseVisualStyleBackColor = false;
            this.activateBtn.Click += new System.EventHandler(this.activateBtn_Click);
            // 
            // removeBtn
            // 
            this.removeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.removeBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(90)))), ((int)(((byte)(25)))));
            this.removeBtn.FlatAppearance.BorderSize = 0;
            this.removeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.removeBtn.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeBtn.ForeColor = System.Drawing.Color.White;
            this.removeBtn.Location = new System.Drawing.Point(595, 510);
            this.removeBtn.Name = "removeBtn";
            this.removeBtn.Size = new System.Drawing.Size(120, 40);
            this.removeBtn.TabIndex = 3;
            this.removeBtn.Text = "Remove License";
            this.removeBtn.UseVisualStyleBackColor = false;
            this.removeBtn.Click += new System.EventHandler(this.removeBtn_Click);
            // 
            // productName_Lbl
            // 
            this.productName_Lbl.AutoSize = true;
            this.productName_Lbl.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productName_Lbl.ForeColor = System.Drawing.Color.White;
            this.productName_Lbl.Location = new System.Drawing.Point(15, 30);
            this.productName_Lbl.Name = "productName_Lbl";
            this.productName_Lbl.Size = new System.Drawing.Size(116, 20);
            this.productName_Lbl.TabIndex = 4;
            this.productName_Lbl.Text = "Microsoft Office";
            // 
            // versionLbl
            // 
            this.versionLbl.AutoSize = true;
            this.versionLbl.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.versionLbl.ForeColor = System.Drawing.Color.White;
            this.versionLbl.Location = new System.Drawing.Point(15, 50);
            this.versionLbl.Name = "versionLbl";
            this.versionLbl.Size = new System.Drawing.Size(81, 20);
            this.versionLbl.TabIndex = 6;
            this.versionLbl.Text = "Version: 1X";
            // 
            // statusLbl
            // 
            this.statusLbl.AutoSize = true;
            this.statusLbl.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLbl.ForeColor = System.Drawing.Color.White;
            this.statusLbl.Location = new System.Drawing.Point(15, 70);
            this.statusLbl.Name = "statusLbl";
            this.statusLbl.Size = new System.Drawing.Size(104, 20);
            this.statusLbl.TabIndex = 7;
            this.statusLbl.Text = "License Status:";
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
            // serverLbl
            // 
            this.serverLbl.AutoSize = true;
            this.serverLbl.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serverLbl.ForeColor = System.Drawing.Color.White;
            this.serverLbl.Location = new System.Drawing.Point(10, 13);
            this.serverLbl.Name = "serverLbl";
            this.serverLbl.Size = new System.Drawing.Size(84, 20);
            this.serverLbl.TabIndex = 10;
            this.serverLbl.Text = "KMS Server";
            // 
            // productDrop
            // 
            this.productDrop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.productDrop.BackColor = System.Drawing.Color.White;
            this.productDrop.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productDrop.ForeColor = System.Drawing.Color.Black;
            this.productDrop.FormattingEnabled = true;
            this.productDrop.Items.AddRange(new object[] {
            "Microsoft 365",
            "Microsoft Office Profesional Plus 2021",
            "Microsoft Office Profesional Plus 2019",
            "Microsoft Office Profesional Plus 2016",
            "Microsoft Office Profesional Plus 2013"});
            this.productDrop.Location = new System.Drawing.Point(360, 10);
            this.productDrop.Name = "productDrop";
            this.productDrop.Size = new System.Drawing.Size(325, 28);
            this.productDrop.TabIndex = 11;
            this.productDrop.Text = "Select your Office version";
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
            "kms8.msguides.com (UNSTABLE)",
            "kms7.msguides.com (UNSTABLE)"});
            this.serverDrop.Location = new System.Drawing.Point(360, 10);
            this.serverDrop.Name = "serverDrop";
            this.serverDrop.Size = new System.Drawing.Size(324, 28);
            this.serverDrop.TabIndex = 12;
            this.serverDrop.Text = "Select your KMS Server";
            this.serverDrop.SelectedIndexChanged += new System.EventHandler(this.serverDrop_SelectedIndexChanged);
            // 
            // infoTitle_Lbl
            // 
            this.infoTitle_Lbl.AutoSize = true;
            this.infoTitle_Lbl.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoTitle_Lbl.ForeColor = System.Drawing.Color.White;
            this.infoTitle_Lbl.Location = new System.Drawing.Point(15, 5);
            this.infoTitle_Lbl.Name = "infoTitle_Lbl";
            this.infoTitle_Lbl.Size = new System.Drawing.Size(187, 25);
            this.infoTitle_Lbl.TabIndex = 13;
            this.infoTitle_Lbl.Text = "Product Information";
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
            this.panel1.TabIndex = 14;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panel2.Controls.Add(this.serverLbl);
            this.panel2.Controls.Add(this.serverDrop);
            this.panel2.Location = new System.Drawing.Point(20, 195);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(695, 50);
            this.panel2.TabIndex = 15;
            // 
            // actTitle_Lbl
            // 
            this.actTitle_Lbl.AutoSize = true;
            this.actTitle_Lbl.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.actTitle_Lbl.ForeColor = System.Drawing.Color.White;
            this.actTitle_Lbl.Location = new System.Drawing.Point(15, 110);
            this.actTitle_Lbl.Name = "actTitle_Lbl";
            this.actTitle_Lbl.Size = new System.Drawing.Size(172, 25);
            this.actTitle_Lbl.TabIndex = 16;
            this.actTitle_Lbl.Text = "Product Activation";
            // 
            // consoleLbl
            // 
            this.consoleLbl.AutoSize = true;
            this.consoleLbl.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.consoleLbl.ForeColor = System.Drawing.Color.White;
            this.consoleLbl.Location = new System.Drawing.Point(15, 320);
            this.consoleLbl.Name = "consoleLbl";
            this.consoleLbl.Size = new System.Drawing.Size(62, 20);
            this.consoleLbl.TabIndex = 17;
            this.consoleLbl.Text = "Console";
            // 
            // productLogo
            // 
            this.productLogo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.productLogo.Image = global::OpenFuryKMS.Properties.Resources.microsoft365;
            this.productLogo.Location = new System.Drawing.Point(570, 345);
            this.productLogo.Name = "productLogo";
            this.productLogo.Size = new System.Drawing.Size(145, 155);
            this.productLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.productLogo.TabIndex = 18;
            this.productLogo.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panel3.Controls.Add(this.methodLbl);
            this.panel3.Controls.Add(this.methodDrop);
            this.panel3.Location = new System.Drawing.Point(20, 250);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(695, 50);
            this.panel3.TabIndex = 16;
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
            "First Activation",
            "Manual Renew",
            "Rearm"});
            this.methodDrop.Location = new System.Drawing.Point(360, 10);
            this.methodDrop.Name = "methodDrop";
            this.methodDrop.Size = new System.Drawing.Size(324, 28);
            this.methodDrop.TabIndex = 12;
            this.methodDrop.Text = "Select your Activation Method";
            this.methodDrop.SelectedIndexChanged += new System.EventHandler(this.methodDrop_SelectedIndexChanged);
            // 
            // OfficeControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.productLogo);
            this.Controls.Add(this.consoleLbl);
            this.Controls.Add(this.actTitle_Lbl);
            this.Controls.Add(this.infoTitle_Lbl);
            this.Controls.Add(this.statusLbl);
            this.Controls.Add(this.versionLbl);
            this.Controls.Add(this.productName_Lbl);
            this.Controls.Add(this.removeBtn);
            this.Controls.Add(this.activateBtn);
            this.Controls.Add(this.shellBox);
            this.Controls.Add(this.infoBtn);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "OfficeControl";
            this.Size = new System.Drawing.Size(740, 560);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productLogo)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button infoBtn;
        private System.Windows.Forms.TextBox shellBox;
        private System.Windows.Forms.Button activateBtn;
        private System.Windows.Forms.Button removeBtn;
        private System.Windows.Forms.Label productName_Lbl;
        private System.Windows.Forms.Label versionLbl;
        private System.Windows.Forms.Label statusLbl;
        private System.Windows.Forms.Label productLbl;
        private System.Windows.Forms.Label serverLbl;
        private System.Windows.Forms.ComboBox productDrop;
        private System.Windows.Forms.ComboBox serverDrop;
        private System.Windows.Forms.Label infoTitle_Lbl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label actTitle_Lbl;
        private System.Windows.Forms.Label consoleLbl;
        private System.Windows.Forms.PictureBox productLogo;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label methodLbl;
        private System.Windows.Forms.ComboBox methodDrop;
    }
}
