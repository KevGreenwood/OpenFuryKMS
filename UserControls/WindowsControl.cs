using System;
using System.IO;
using System.Linq;
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
            ProductNameLbl.Text = $"Operating System: {Win.GetAllInfo}";
            VersionLbl.Text = $"Version: {Win.Version}";

            if (Win.ProductName.Contains("Windows 11"))
            {
                productLogo.IconChar = FontAwesome.Sharp.IconChar.Microsoft;
            }
            else
            {
                productLogo.IconChar = FontAwesome.Sharp.IconChar.Windows;
            }
        }

        private void InstallLicense()
        {
            string license = string.Empty;
            switch (productDrop.SelectedIndex)
            {
                case 0:
                    license = Win.Home_Licenses[licenseDrop.SelectedIndex].License;
                    break;

                case 1:
                    license = Win.Pro_Licenses[licenseDrop.SelectedIndex].License;
                    break;

                case 2:
                    license = Win.Education_Licenses[licenseDrop.SelectedIndex].License;
                    break;

                case 3:
                    license = Win.Enterprise_Licenses[licenseDrop.SelectedIndex].License;
                    break;
            }
            ShellBox.Text = Pwsh.ExecuteCommand($"cscript //nologo slmgr.vbs /ipk {license}");
        }

        private void SetKMS_Server()
        {
            if (serverDrop.SelectedIndex == 0)
            {
                ShellBox.Text = Pwsh.AutoKMS(windows: true);
            }
            else
            {
                string server = Pwsh.KmsServers[serverDrop.SelectedIndex - 1];
                ShellBox.Text = Pwsh.ExecuteCommand($"cscript //nologo slmgr.vbs /skms {server}; cscript //nologo slmgr.vbs /ato");
            }
        }

        private void InfoButton_Click(object sender, EventArgs e)
        {
            ShellBox.Text = Pwsh.ExecuteCommand("cscript //nologo slmgr.vbs /dli; cscript //nologo slmgr.vbs /xpr");
        }
        private void ActivateButton_Click(object sender, EventArgs e)
        {
            switch (methodDrop.SelectedIndex)
            {
                case 0:
                    InstallLicense();
                    break;

                case 1:
                case 2:
                    string command = methodDrop.SelectedIndex == 1 ? "/ato" : "/rearm";
                    ShellBox.Text = Pwsh.ExecuteCommand($"cscript //nologo slmgr.vbs {command}");
                    break;
            }
        }
        private void DeactivateButton_Click(object sender, EventArgs e)
        {
            ShellBox.Text = Pwsh.ExecuteCommand("cscript //nologo slmgr.vbs /upk; cscript //nologo slmgr.vbs /cpky; cscript //nologo slmgr.vbs /ckms");
        }

        private void productDrop_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(productDrop.SelectedIndex)
            {
                case 0:
                    licenseDrop.DataSource = Win.Home_Licenses.Select(x => x.License + x.Description).ToList();
                    break;

                case 1:
                    licenseDrop.DataSource = Win.Pro_Licenses.Select(x => x.License + x.Description).ToList();
                    break;

                case 2:
                    licenseDrop.DataSource = Win.Education_Licenses.Select(x => x.License + x.Description).ToList();
                    break;

                case 3:
                    licenseDrop.DataSource = Win.Enterprise_Licenses.Select(x => x.License + x.Description).ToList();
                    break;
            }
            licenseDrop.SelectedIndex = -1;
        }
    }
}