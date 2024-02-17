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
            this.label6 = new System.Windows.Forms.Label();
            this.OfficeLbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(15, 100);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label6.Size = new System.Drawing.Size(182, 25);
            this.label6.TabIndex = 5;
            this.label6.Text = "System Information";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(15, 205);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(113, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "Instructions";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(15, 230);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(120, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Instructions Here";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            // HomeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OfficeLbl);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.versionLbl);
            this.Controls.Add(this.PwshLbl);
            this.Controls.Add(this.WinLbl);
            this.Name = "HomeControl";
            this.Size = new System.Drawing.Size(740, 560);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label WinLbl;
        private System.Windows.Forms.Label PwshLbl;
        private System.Windows.Forms.Label versionLbl;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label OfficeLbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
