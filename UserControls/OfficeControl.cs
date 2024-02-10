using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace OpenFuryKMS
{
    public partial class OfficeControl : UserControl
    {
        PowershellHandler Pwsh = new PowershellHandler();
        OfficeHandler officeHandler = new OfficeHandler();

        public string DirtyOutput;
        public string PwshOutput;

        public OfficeControl()
        {
            InitializeComponent();

            ServerDrop.Enabled = false;
            ActivateButton.Enabled = false;
            officeHandler.DirChecker();
            Autodetect();
            InfoButton.PerformClick();
            PwshOutput = Pwsh.ExecuteCommand("cscript //nologo ospp.vbs /dstatus");

            string LicenseStatus = officeHandler.ExtractLicenseStatus(PwshOutput);

            if (LicenseStatus == "Unlicensed")
            {
                DeactivateButton.Enabled = false;
            }

            LicenseStatusLbl.Text = "License Status: " + LicenseStatus + " (" + officeHandler.GetLicenseType() + ") ";
            ProductNameLbl.Text = "Software: " + officeHandler.GetProductName() + officeHandler.GetPlatform();
            VersionLbl.Text = "Build: " + officeHandler.Version;
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
                if (officeHandler.ProductName.Contains(item.Key))
                {
                    ProductDrop.SelectedIndex = item.Value;
                    ServerDrop.Enabled = true;
                    break;
                }
            }
        }

        private void Activation()
        {
            switch (ProductDrop.SelectedIndex)
            {
                case 0:
                case 3:
                    DirtyOutput = officeHandler.InstallLicense("proplusvl_kms", new List<string> { "BTDRB", "KHGM9", "CPQVG" }, "XQNVK-8JYDB-WJ9W3-YJ8YR-WFG99");
                    break;

                case 1:
                    DirtyOutput = officeHandler.InstallLicense("ProPlus2021VL_KMS", new List<string> { "6F7TH" }, "FXYTK-NJJ8C-GB6DW-3DYQT-6F7TH");
                    break;

                case 2:
                    DirtyOutput = officeHandler.InstallLicense("ProPlus2019VL", new List<string> { "6MWKP" }, "NMMKJ-6RK4F-KMJVX-8D9MJ-6MWKP");
                    break;

                case 4:
                    DirtyOutput = Pwsh.ExecuteCommand("cscript //nologo ospp.vbs /inpkey:YC7DK-G2NP3-2QQC3-J6H88-GVGXT");
                    break;
            }
            ShellBox.Text = officeHandler.ClearOutput(Pwsh.ExecuteCommand(DirtyOutput));
            SetKMS_Server();
        }

        private void SetKMS_Server()
        {
            switch (ServerDrop.SelectedIndex)
            {
                case 0:
                    DirtyOutput = Pwsh.AutoKMS(office: true);
                    break;

                case 1:
                    DirtyOutput = Pwsh.ExecuteCommand("cscript //nologo ospp.vbs /sethst:kms.digiboy.ir; cscript //nologo ospp.vbs /act");
                    break;

                case 2:
                    DirtyOutput = Pwsh.ExecuteCommand("cscript //nologo ospp.vbs /sethst:kms.chinancce.com; cscript //nologo ospp.vbs /act");
                    break;
            }
            ActivateButton.Enabled = true;
            ShellBox.Text = officeHandler.ClearOutput(DirtyOutput);
        }

        private void InfoButton_Click(object sender, EventArgs e)
        {
            DirtyOutput = Pwsh.ExecuteCommand("cscript //nologo ospp.vbs /dstatus");
            ShellBox.Text = officeHandler.ClearOutput(DirtyOutput);
        }

        private void ActivateButton_Click(object sender, EventArgs e)
        {
            switch (MethodDrop.SelectedIndex)
            {
                case 0:
                    Activation();
                    break;

                case 1:
                    DirtyOutput = Pwsh.ExecuteCommand("cscript //nologo ospp.vbs /act");
                    break;

                case 2:
                    DirtyOutput = Pwsh.ExecuteCommand("cscript //nologo ospp.vbs /rearm");
                    break;
            }
            ShellBox.Text = officeHandler.ClearOutput(DirtyOutput);
            LicenseStatusLbl.Text = "License Status: " + officeHandler.ExtractLicenseStatus(PwshOutput) + " (" + officeHandler.GetLicenseType() + ") ";
        }

        private void DeactivateButton_Click(object sender, EventArgs e)
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
                    DirtyOutput = Pwsh.ExecuteCommand($"cscript //nologo ospp.vbs /unpkey:{officeKey.Value}");
                    ShellBox.Text = officeHandler.ClearOutput(DirtyOutput);
                    break;
                }
            }
            LicenseStatusLbl.Text = "License Status: " + officeHandler.ExtractLicenseStatus(PwshOutput) + " (" + officeHandler.GetLicenseType() + ") ";
        }

        private void ProductDrop_SelectedIndexChanged(object sender, EventArgs e)
        {
            ServerDrop.Enabled = true;
        }
        private void MethodDrop_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActivateButton.Enabled = true;
        }
    }
}