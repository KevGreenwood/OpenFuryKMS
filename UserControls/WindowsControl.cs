using FontAwesome.Sharp;
using System;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace OpenFuryKMS
{
    public partial class WindowsControl : UserControl
    {
        WindowsHandler windowsHandler = new WindowsHandler();
        PowershellHandler pwsh = new PowershellHandler();

        public string pwshOutput;

        public WindowsControl()
        {
            InitializeComponent();

            activateBtn.Enabled = false;

            Directory.SetCurrentDirectory(@"C:\Windows\system32");
            
            ProductNameLbl.Text = $"Operating System: {windowsHandler.GetAllInfo}";
            VersionLbl.Text = $"Version: {windowsHandler.Version}";

            GetLicenseStatus();

            if (WindowsHandler.ProductName.Contains("Windows 11"))
            {
                productLogo.IconChar = IconChar.Microsoft;
            }
            else
            {
                productLogo.IconChar = IconChar.Windows;
            }

            var products = new[] { "Home", "Pro", "Education", "Enterprise" };
            for (int i = 0; i < products.Length; i++)
            {
                if (WindowsHandler.ProductName.Contains(products[i]))
                {
                    productDrop.SelectedIndex = i;
                    break;
                }
            }
            CheckForInternetConnection();
            infoBtn.PerformClick();
        }

        public void GetLicenseStatus()
        {
            pwshOutput = pwsh.ExecuteCommand("cscript //nologo slmgr.vbs /dli");
            string licenseStatus = windowsHandler.ExtractLicenseStatus(pwshOutput);
            statusLbl.Text = $"License Status: {licenseStatus}";
            removeBtn.Enabled = licenseStatus != "Unlicensed";
        }

        public void CheckForInternetConnection()
        {
            bool isConnected = NetworkInterface.GetIsNetworkAvailable();

            if (!isConnected)
            {
                licenseDrop.Enabled = false;
                serverDrop.Enabled = false;
            }
        }

        private void SetKMS_Server()
        {
            if (serverDrop.SelectedIndex == 0)
            {
                shellBox.Text = pwsh.AutoKMS(windows: true);
            }
            else
            {
                string server = pwsh.KmsServers[serverDrop.SelectedIndex - 1];
                shellBox.Text = pwsh.ExecuteCommand($"cscript //nologo slmgr.vbs /skms {server}; cscript //nologo slmgr.vbs /ato");
            }
        }

        private void activateBtn_Click(object sender, EventArgs e)
        {
            switch (methodDrop.SelectedIndex)
            {
                case 0:
                    if (licenseDrop.SelectedIndex != -1)
                    {
                        string selectedLicense = licenseDrop.SelectedItem.ToString();
                        string licenseKey = selectedLicense.Split(' ')[0];
                        shellBox.Text = pwsh.ExecuteCommand($"cscript //nologo slmgr.vbs /ipk {licenseKey}");
                        SetKMS_Server();
                    }
                    break;

                case 1:
                case 2:
                    string command = methodDrop.SelectedIndex == 1 ? "/ato" : "/rearm";
                    shellBox.Text = pwsh.ExecuteCommand($"cscript //nologo slmgr.vbs {command}");
                    break;
            }
        }
        private void infoBtn_Click(object sender, EventArgs e)
        {
            shellBox.Text = pwsh.ExecuteCommand("cscript //nologo slmgr.vbs /dli; cscript //nologo slmgr.vbs /xpr");
        }
        private void removeBtn_Click(object sender, EventArgs e)
        {
            shellBox.Text = pwsh.ExecuteCommand("cscript //nologo slmgr.vbs /upk; cscript //nologo slmgr.vbs /cpky; cscript //nologo slmgr.vbs /ckms");
        }

        private void productDrop_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (productDrop.SelectedIndex)
            {
                case 0:
                    licenseDrop.DataSource = windowsHandler.Home_Licenses.Select(x => x.License + x.Description).ToList();
                    break;

                case 1:
                    licenseDrop.DataSource = windowsHandler.Pro_Licenses.Select(x => x.License + x.Description).ToList();
                    break;

                case 2:
                    licenseDrop.DataSource = windowsHandler.Education_Licenses.Select(x => x.License + x.Description).ToList();
                    break;

                case 3:
                    licenseDrop.DataSource = windowsHandler.Enterprise_Licenses.Select(x => x.License + x.Description).ToList();
                    break;
            }
            licenseDrop.SelectedIndex = -1;
            licenseDrop.Enabled = true;
        }
        private void methodDrop_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isRearmSelected = methodDrop.SelectedIndex == 2;
            bool isRenewSelected = methodDrop.SelectedIndex == 1;
            bool isAllSelected = productDrop.SelectedIndex != -1 && licenseDrop.SelectedIndex != -1 && serverDrop.SelectedIndex != -1;

            activateBtn.Enabled = isAllSelected || isRearmSelected || isRenewSelected;
            licenseDrop.Enabled = serverDrop.Enabled = !isRearmSelected && !isRenewSelected;
        }
    }
}