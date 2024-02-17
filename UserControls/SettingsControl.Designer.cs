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
            this.removeWin_Btn = new System.Windows.Forms.Button();
            this.langDrop = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // removeWin_Btn
            // 
            this.removeWin_Btn.Location = new System.Drawing.Point(37, 434);
            this.removeWin_Btn.Name = "removeWin_Btn";
            this.removeWin_Btn.Size = new System.Drawing.Size(75, 23);
            this.removeWin_Btn.TabIndex = 0;
            this.removeWin_Btn.Text = "button1";
            this.removeWin_Btn.UseVisualStyleBackColor = true;
            this.removeWin_Btn.Click += new System.EventHandler(this.removeWin_Btn_Click);
            // 
            // langDrop
            // 
            this.langDrop.FormattingEnabled = true;
            this.langDrop.Items.AddRange(new object[] {
            "English (EN)",
            "Español (ES)",
            "Русский язык"});
            this.langDrop.Location = new System.Drawing.Point(37, 52);
            this.langDrop.Name = "langDrop";
            this.langDrop.Size = new System.Drawing.Size(121, 21);
            this.langDrop.TabIndex = 1;
            this.langDrop.SelectedIndexChanged += new System.EventHandler(this.langDrop_SelectedIndexChanged);
            // 
            // SettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.langDrop);
            this.Controls.Add(this.removeWin_Btn);
            this.Name = "SettingsControl";
            this.Size = new System.Drawing.Size(740, 560);
            this.Load += new System.EventHandler(this.SettingsControl_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button removeWin_Btn;
        private System.Windows.Forms.ComboBox langDrop;
    }
}
