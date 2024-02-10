using System;
using System.IO;
using System.Windows.Forms;

namespace OpenFuryKMS
{
    public partial class WindowsControl : UserControl
    {
        WindowsHandler Win = new WindowsHandler();
        PowershellHandler Pwsh = new PowershellHandler();
        public WindowsControl()
        {
            InitializeComponent();
            Directory.SetCurrentDirectory(@"C:\Windows\system32");
            ProductNameLbl.Text = $"Operating System: {Win.GetAllInfo()}";
            VersionLbl.Text = $"Version: {Win.Version}";
        }

        private void InfoButton_Click(object sender, EventArgs e)
        {
            ShellBox.Text = Pwsh.ExecuteCommand("cscript //nologo slmgr.vbs /dli; cscript //nologo slmgr.vbs /xpr");
        }
        private void ActivateButton_Click(object sender, EventArgs e)
        {

        }
        private void DeactivateButton_Click(object sender, EventArgs e)
        {
            ShellBox.Text = Pwsh.ExecuteCommand("cscript //nologo slmgr.vbs /upk; cscript //nologo slmgr.vbs /cpky; cscript //nologo slmgr.vbs /ckms");
        }
    }
}