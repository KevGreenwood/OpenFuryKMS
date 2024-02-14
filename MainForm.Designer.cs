namespace OpenFuryKMS
{
    partial class MainForm
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

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.windowsBtn = new FontAwesome.Sharp.IconButton();
            this.homeBtn = new FontAwesome.Sharp.IconButton();
            this.childPnl = new System.Windows.Forms.Panel();
            this.menuPnl = new System.Windows.Forms.Panel();
            this.settingsBtn = new FontAwesome.Sharp.IconButton();
            this.panel6 = new System.Windows.Forms.Panel();
            this.officeBtn = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.leftPnl = new System.Windows.Forms.Panel();
            this.menuPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // windowsBtn
            // 
            this.windowsBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.windowsBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.windowsBtn.FlatAppearance.BorderSize = 0;
            this.windowsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.windowsBtn.ForeColor = System.Drawing.Color.White;
            this.windowsBtn.IconChar = FontAwesome.Sharp.IconChar.Windows;
            this.windowsBtn.IconColor = System.Drawing.Color.White;
            this.windowsBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.windowsBtn.IconSize = 30;
            this.windowsBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.windowsBtn.Location = new System.Drawing.Point(10, 52);
            this.windowsBtn.Name = "windowsBtn";
            this.windowsBtn.Size = new System.Drawing.Size(140, 40);
            this.windowsBtn.TabIndex = 0;
            this.windowsBtn.Text = "Windows";
            this.windowsBtn.UseVisualStyleBackColor = false;
            this.windowsBtn.Click += new System.EventHandler(this.windowsBtn_Click);
            // 
            // homeBtn
            // 
            this.homeBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.homeBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.homeBtn.FlatAppearance.BorderSize = 0;
            this.homeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.homeBtn.ForeColor = System.Drawing.Color.White;
            this.homeBtn.IconChar = FontAwesome.Sharp.IconChar.House;
            this.homeBtn.IconColor = System.Drawing.Color.White;
            this.homeBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.homeBtn.IconSize = 30;
            this.homeBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.homeBtn.Location = new System.Drawing.Point(10, 12);
            this.homeBtn.Name = "homeBtn";
            this.homeBtn.Size = new System.Drawing.Size(140, 40);
            this.homeBtn.TabIndex = 1;
            this.homeBtn.Text = "Home";
            this.homeBtn.UseVisualStyleBackColor = false;
            this.homeBtn.Click += new System.EventHandler(this.homeBtn_Click);
            // 
            // childPnl
            // 
            this.childPnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.childPnl.Location = new System.Drawing.Point(150, 0);
            this.childPnl.Name = "childPnl";
            this.childPnl.Size = new System.Drawing.Size(740, 560);
            this.childPnl.TabIndex = 2;
            // 
            // menuPnl
            // 
            this.menuPnl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.menuPnl.Controls.Add(this.settingsBtn);
            this.menuPnl.Controls.Add(this.panel6);
            this.menuPnl.Controls.Add(this.officeBtn);
            this.menuPnl.Controls.Add(this.windowsBtn);
            this.menuPnl.Controls.Add(this.homeBtn);
            this.menuPnl.Controls.Add(this.panel3);
            this.menuPnl.Controls.Add(this.leftPnl);
            this.menuPnl.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuPnl.Location = new System.Drawing.Point(0, 0);
            this.menuPnl.Name = "menuPnl";
            this.menuPnl.Size = new System.Drawing.Size(150, 560);
            this.menuPnl.TabIndex = 3;
            // 
            // settingsBtn
            // 
            this.settingsBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.settingsBtn.FlatAppearance.BorderSize = 0;
            this.settingsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.settingsBtn.ForeColor = System.Drawing.Color.White;
            this.settingsBtn.IconChar = FontAwesome.Sharp.IconChar.Gear;
            this.settingsBtn.IconColor = System.Drawing.Color.White;
            this.settingsBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.settingsBtn.IconSize = 30;
            this.settingsBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.settingsBtn.Location = new System.Drawing.Point(10, 510);
            this.settingsBtn.Name = "settingsBtn";
            this.settingsBtn.Size = new System.Drawing.Size(140, 40);
            this.settingsBtn.TabIndex = 0;
            this.settingsBtn.Text = "Settings";
            this.settingsBtn.UseVisualStyleBackColor = true;
            this.settingsBtn.Click += new System.EventHandler(this.settingsBtn_Click);
            // 
            // panel6
            // 
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(10, 550);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(140, 10);
            this.panel6.TabIndex = 1;
            // 
            // officeBtn
            // 
            this.officeBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.officeBtn.FlatAppearance.BorderSize = 0;
            this.officeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.officeBtn.ForeColor = System.Drawing.Color.White;
            this.officeBtn.Image = global::OpenFuryKMS.Properties.Resources.whiteIcon;
            this.officeBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.officeBtn.Location = new System.Drawing.Point(10, 92);
            this.officeBtn.Name = "officeBtn";
            this.officeBtn.Size = new System.Drawing.Size(140, 40);
            this.officeBtn.TabIndex = 0;
            this.officeBtn.Text = "Office";
            this.officeBtn.UseVisualStyleBackColor = true;
            this.officeBtn.Click += new System.EventHandler(this.officeBtn_Click);
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(10, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(140, 12);
            this.panel3.TabIndex = 0;
            // 
            // leftPnl
            // 
            this.leftPnl.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftPnl.Location = new System.Drawing.Point(0, 0);
            this.leftPnl.Name = "leftPnl";
            this.leftPnl.Size = new System.Drawing.Size(10, 560);
            this.leftPnl.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(890, 560);
            this.Controls.Add(this.childPnl);
            this.Controls.Add(this.menuPnl);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuPnl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private FontAwesome.Sharp.IconButton windowsBtn;
        private FontAwesome.Sharp.IconButton homeBtn;
        private System.Windows.Forms.Panel childPnl;
        private System.Windows.Forms.Panel menuPnl;
        private FontAwesome.Sharp.IconButton settingsBtn;
        private System.Windows.Forms.Button officeBtn;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel leftPnl;
    }
}

