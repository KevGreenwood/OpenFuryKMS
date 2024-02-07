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
            this.WindowsButton = new FontAwesome.Sharp.IconButton();
            this.HomeButton = new FontAwesome.Sharp.IconButton();
            this.ChildPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SettingsButton = new FontAwesome.Sharp.IconButton();
            this.panel6 = new System.Windows.Forms.Panel();
            this.OfficeButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // WindowsButton
            // 
            this.WindowsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.WindowsButton.FlatAppearance.BorderSize = 0;
            this.WindowsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.WindowsButton.ForeColor = System.Drawing.Color.White;
            this.WindowsButton.IconChar = FontAwesome.Sharp.IconChar.Windows;
            this.WindowsButton.IconColor = System.Drawing.Color.White;
            this.WindowsButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.WindowsButton.IconSize = 30;
            this.WindowsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.WindowsButton.Location = new System.Drawing.Point(10, 55);
            this.WindowsButton.Name = "WindowsButton";
            this.WindowsButton.Size = new System.Drawing.Size(140, 40);
            this.WindowsButton.TabIndex = 0;
            this.WindowsButton.Text = "Windows";
            this.WindowsButton.UseVisualStyleBackColor = false;
            this.WindowsButton.Click += new System.EventHandler(this.WindowsButton_Click);
            // 
            // HomeButton
            // 
            this.HomeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.HomeButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.HomeButton.FlatAppearance.BorderSize = 0;
            this.HomeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HomeButton.ForeColor = System.Drawing.Color.White;
            this.HomeButton.IconChar = FontAwesome.Sharp.IconChar.House;
            this.HomeButton.IconColor = System.Drawing.Color.White;
            this.HomeButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.HomeButton.IconSize = 30;
            this.HomeButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.HomeButton.Location = new System.Drawing.Point(10, 12);
            this.HomeButton.Name = "HomeButton";
            this.HomeButton.Size = new System.Drawing.Size(140, 40);
            this.HomeButton.TabIndex = 1;
            this.HomeButton.Text = "Home";
            this.HomeButton.UseVisualStyleBackColor = false;
            this.HomeButton.Click += new System.EventHandler(this.HomeButton_Click);
            // 
            // ChildPanel
            // 
            this.ChildPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChildPanel.Location = new System.Drawing.Point(150, 0);
            this.ChildPanel.Name = "ChildPanel";
            this.ChildPanel.Size = new System.Drawing.Size(740, 560);
            this.ChildPanel.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.panel1.Controls.Add(this.SettingsButton);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.OfficeButton);
            this.panel1.Controls.Add(this.WindowsButton);
            this.panel1.Controls.Add(this.HomeButton);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(150, 560);
            this.panel1.TabIndex = 3;
            // 
            // SettingsButton
            // 
            this.SettingsButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SettingsButton.FlatAppearance.BorderSize = 0;
            this.SettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SettingsButton.ForeColor = System.Drawing.Color.White;
            this.SettingsButton.IconChar = FontAwesome.Sharp.IconChar.Gear;
            this.SettingsButton.IconColor = System.Drawing.Color.White;
            this.SettingsButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.SettingsButton.IconSize = 30;
            this.SettingsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SettingsButton.Location = new System.Drawing.Point(10, 510);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Size = new System.Drawing.Size(140, 40);
            this.SettingsButton.TabIndex = 0;
            this.SettingsButton.Text = "Settings";
            this.SettingsButton.UseVisualStyleBackColor = true;
            this.SettingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
            // 
            // panel6
            // 
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(10, 550);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(140, 10);
            this.panel6.TabIndex = 1;
            // 
            // OfficeButton
            // 
            this.OfficeButton.FlatAppearance.BorderSize = 0;
            this.OfficeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OfficeButton.ForeColor = System.Drawing.Color.White;
            this.OfficeButton.Location = new System.Drawing.Point(10, 100);
            this.OfficeButton.Name = "OfficeButton";
            this.OfficeButton.Size = new System.Drawing.Size(140, 40);
            this.OfficeButton.TabIndex = 0;
            this.OfficeButton.Text = "Office";
            this.OfficeButton.UseVisualStyleBackColor = true;
            this.OfficeButton.Click += new System.EventHandler(this.OfficeButton_Click);
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(10, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(140, 12);
            this.panel3.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(10, 560);
            this.panel2.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(890, 560);
            this.Controls.Add(this.ChildPanel);
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private FontAwesome.Sharp.IconButton WindowsButton;
        private FontAwesome.Sharp.IconButton HomeButton;
        private System.Windows.Forms.Panel ChildPanel;
        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton SettingsButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button OfficeButton;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel6;
    }
}

