namespace OpenFuryKMS.UserControls
{
    partial class HomeControl
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
            this.WinLbl = new System.Windows.Forms.Label();
            this.PwshLbl = new System.Windows.Forms.Label();
            this.versionLbl = new System.Windows.Forms.Label();
            this.sysInfoLbl = new System.Windows.Forms.Label();
            this.OfficeLbl = new System.Windows.Forms.Label();
            this.insTitleLbl = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.insLbl = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // WinLbl
            // 
            this.WinLbl.AutoSize = true;
            this.WinLbl.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WinLbl.ForeColor = System.Drawing.Color.White;
            this.WinLbl.Location = new System.Drawing.Point(15, 125);
            this.WinLbl.Name = "WinLbl";
            this.WinLbl.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.WinLbl.Size = new System.Drawing.Size(144, 20);
            this.WinLbl.TabIndex = 0;
            this.WinLbl.Text = "Windows XX Version";
            this.WinLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PwshLbl
            // 
            this.PwshLbl.AutoSize = true;
            this.PwshLbl.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.PwshLbl.ForeColor = System.Drawing.Color.White;
            this.PwshLbl.Location = new System.Drawing.Point(15, 165);
            this.PwshLbl.Name = "PwshLbl";
            this.PwshLbl.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.PwshLbl.Size = new System.Drawing.Size(79, 20);
            this.PwshLbl.TabIndex = 2;
            this.PwshLbl.Text = "Powershell";
            // 
            // versionLbl
            // 
            this.versionLbl.AutoSize = true;
            this.versionLbl.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.versionLbl.ForeColor = System.Drawing.Color.White;
            this.versionLbl.Location = new System.Drawing.Point(15, 60);
            this.versionLbl.Name = "versionLbl";
            this.versionLbl.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.versionLbl.Size = new System.Drawing.Size(91, 20);
            this.versionLbl.TabIndex = 4;
            this.versionLbl.Text = "Version: x.x.x";
            this.versionLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sysInfoLbl
            // 
            this.sysInfoLbl.AutoSize = true;
            this.sysInfoLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold);
            this.sysInfoLbl.ForeColor = System.Drawing.Color.White;
            this.sysInfoLbl.Location = new System.Drawing.Point(15, 100);
            this.sysInfoLbl.Name = "sysInfoLbl";
            this.sysInfoLbl.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.sysInfoLbl.Size = new System.Drawing.Size(182, 25);
            this.sysInfoLbl.TabIndex = 5;
            this.sysInfoLbl.Text = "System Information";
            this.sysInfoLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // OfficeLbl
            // 
            this.OfficeLbl.AutoSize = true;
            this.OfficeLbl.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.OfficeLbl.ForeColor = System.Drawing.Color.White;
            this.OfficeLbl.Location = new System.Drawing.Point(15, 145);
            this.OfficeLbl.Name = "OfficeLbl";
            this.OfficeLbl.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.OfficeLbl.Size = new System.Drawing.Size(180, 20);
            this.OfficeLbl.TabIndex = 6;
            this.OfficeLbl.Text = "Office Status: No Installed";
            // 
            // insTitleLbl
            // 
            this.insTitleLbl.AutoSize = true;
            this.insTitleLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold);
            this.insTitleLbl.ForeColor = System.Drawing.Color.White;
            this.insTitleLbl.Location = new System.Drawing.Point(15, 205);
            this.insTitleLbl.Name = "insTitleLbl";
            this.insTitleLbl.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.insTitleLbl.Size = new System.Drawing.Size(113, 25);
            this.insTitleLbl.TabIndex = 7;
            this.insTitleLbl.Text = "Instructions";
            this.insTitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::OpenFuryKMS.Properties.Resources.TitleLogo;
            this.pictureBox1.Location = new System.Drawing.Point(15, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(347, 54);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // insLbl
            // 
            this.insLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.insLbl.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.insLbl.ForeColor = System.Drawing.Color.White;
            this.insLbl.Location = new System.Drawing.Point(0, 0);
            this.insLbl.Name = "insLbl";
            this.insLbl.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.insLbl.Size = new System.Drawing.Size(725, 330);
            this.insLbl.TabIndex = 8;
            this.insLbl.Text = "Instructions Here";
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(15, 560);
            this.panel1.TabIndex = 10;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.insLbl);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(15, 230);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(725, 330);
            this.panel3.TabIndex = 13;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(15, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(725, 230);
            this.panel4.TabIndex = 9;
            // 
            // HomeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.Controls.Add(this.insTitleLbl);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.OfficeLbl);
            this.Controls.Add(this.sysInfoLbl);
            this.Controls.Add(this.versionLbl);
            this.Controls.Add(this.PwshLbl);
            this.Controls.Add(this.WinLbl);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Name = "HomeControl";
            this.Size = new System.Drawing.Size(740, 560);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label WinLbl;
        private System.Windows.Forms.Label PwshLbl;
        private System.Windows.Forms.Label versionLbl;
        private System.Windows.Forms.Label sysInfoLbl;
        private System.Windows.Forms.Label OfficeLbl;
        private System.Windows.Forms.Label insTitleLbl;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label insLbl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
    }
}
