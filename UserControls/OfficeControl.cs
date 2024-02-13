using OpenFuryKMS.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace OpenFuryKMS
{
    public partial class OfficeControl : UserControl
    {
        PowershellHandler pwsh = new PowershellHandler();
        OfficeHandler officeHandler = new OfficeHandler();

        public string dirtyOutput;
        public string pwshOutput;

        public OfficeControl()
        {
            InitializeComponent();

            activateBtn.Enabled = false;

            productName_Lbl.Text = $"Software: {officeHandler.GetProductName()}{officeHandler.GetPlatform()}";
            versionLbl.Text = $"Build: {officeHandler.Version}";
            
            officeHandler.DirChecker();
            Autodetect();
            CheckForInternetConnection();
            GetLicenseStatus();

            Dictionary<string, Image> productToImage = new Dictionary<string, Image>
            {
                { "365", Resources.microsoft365 },
                { "2021", Resources.microsoft365 },
                { "2019", Resources.Office2019_2021 },
                { "2016", Resources.Office2013_2016 },
                { "2013", Resources.Office2013_2016 }
            };
            foreach (var item in productToImage)
            {
                if (officeHandler.ProductName.Contains(item.Key))
                {
                    productLogo.Image = item.Value;
                    break;
                }
            }
            infoBtn.PerformClick();
        }

        public void CheckForInternetConnection()
        {
            bool isConnected = NetworkInterface.GetIsNetworkAvailable();

            if (!isConnected)
            {
                serverDrop.Enabled = false;
                if (methodDrop.SelectedIndex == 2)
                {
                    activateBtn.Enabled = true;
                }
                else
                {
                    activateBtn.Enabled = false;
                }
            }
        }

        private void Autodetect()
        {
            Dictionary<string, int> productToIndex = new Dictionary<string, int>
            {
                { "365", 0 },
                { "2021", 1 },
                { "2019", 2 },
                { "2016", 3 },
                { "2013", 4 }
            };
            foreach (var item in productToIndex)
            {
                if (!officeHandler.ProductName.Contains(item.Key)) continue;
                productDrop.SelectedIndex = item.Value;
                serverDrop.Enabled = true;
                break;
            }
        }
        
        public void GetLicenseStatus()
        {
            pwshOutput = pwsh.ExecuteCommand("cscript //nologo ospp.vbs /dstatus");
            string licenseStatus = officeHandler.ExtractLicenseStatus(pwshOutput);
            statusLbl.Text = $"License Status: {licenseStatus} ({officeHandler.GetLicenseType()})";
            removeBtn.Enabled = licenseStatus != "Unlicensed";
        }
        
        private void Activation()
        {
            switch (productDrop.SelectedIndex)
            {
                case 0:
                case 3:
                    dirtyOutput = officeHandler.InstallLicense("proplusvl_kms", new List<string> { "BTDRB", "KHGM9", "CPQVG" }, "XQNVK-8JYDB-WJ9W3-YJ8YR-WFG99");
                    break;

                case 1:
                    dirtyOutput = officeHandler.InstallLicense("ProPlus2021VL_KMS", new List<string> { "6F7TH" }, "FXYTK-NJJ8C-GB6DW-3DYQT-6F7TH");
                    break;

                case 2:
                    dirtyOutput = officeHandler.InstallLicense("ProPlus2019VL", new List<string> { "6MWKP" }, "NMMKJ-6RK4F-KMJVX-8D9MJ-6MWKP");
                    break;

                case 4:
                    dirtyOutput = pwsh.ExecuteCommand("cscript //nologo ospp.vbs /inpkey:YC7DK-G2NP3-2QQC3-J6H88-GVGXT");
                    break;
            }
            shellBox.Text = officeHandler.ClearOutput(pwsh.ExecuteCommand(dirtyOutput));
            SetKMS_Server();
        }
        
        private void SetKMS_Server()
        {
            if (serverDrop.SelectedIndex == 0)
            {
                dirtyOutput = pwsh.AutoKMS(office: true);
            }
            else
            {
                string server = pwsh.KmsServers[serverDrop.SelectedIndex - 1];
                dirtyOutput = pwsh.ExecuteCommand($"cscript //nologo ospp.vbs /sethst:{server}; cscript //nologo ospp.vbs /act");
            }
            activateBtn.Enabled = true;
            shellBox.Text = officeHandler.ClearOutput(dirtyOutput);
        }

        private void activateBtn_Click(object sender, EventArgs e)
        {
            switch (methodDrop.SelectedIndex)
            {
                case 0:
                    Activation();
                    break;

                case 1:
                case 2:
                    string command = methodDrop.SelectedIndex == 1 ? "/act" : "/rearm";
                    dirtyOutput = pwsh.ExecuteCommand($"cscript //nologo ospp.vbs {command}");
                    break;
            }
            shellBox.Text = officeHandler.ClearOutput(dirtyOutput);
            GetLicenseStatus();
        }
        private void infoBtn_Click(object sender, EventArgs e)
        {
            dirtyOutput = pwsh.ExecuteCommand("cscript //nologo ospp.vbs /dstatus");
            shellBox.Text = officeHandler.ClearOutput(dirtyOutput);
        }
        private void removeBtn_Click(object sender, EventArgs e)
        {
            var officeKeys = new Dictionary<string, string>
            {
               {"2021", "6F7TH"},
               {"2019", "6MWKP"},
               {"2016", "WFG99"},
               {"365", "WFG99"},
               {"2013", "GVGXT"}
            };
            foreach (var officeKey in officeKeys)
            {
                if (officeHandler.ReleaseId.Contains(officeKey.Key))
                {
                    dirtyOutput = pwsh.ExecuteCommand($"cscript //nologo ospp.vbs /unpkey:{officeKey.Value}");
                    shellBox.Text = officeHandler.ClearOutput(dirtyOutput);
                    break;
                }
            }
            GetLicenseStatus();
        }

        private void methodDrop_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isRearmSelected = methodDrop.SelectedIndex == 2;
            bool isRenewSelected = methodDrop.SelectedIndex == 1;
            bool isAllSelected = productDrop.SelectedIndex != -1;

            activateBtn.Enabled = isAllSelected || isRearmSelected || isRenewSelected;
            serverDrop.Enabled = isAllSelected;
        }
    }
}