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
        public string DirtyOutput;

        PowershellHandler Pwsh = new PowershellHandler();
        OfficeHandler officeHandler = new OfficeHandler();

        public OfficeControl()
        {
            InitializeComponent();
            
            officeHandler.DirChecker();

            string PwshOutput = Pwsh.ExecuteCommand("cscript //nologo ospp.vbs /dstatus");

            LicenseStatusLbl.Text = "License Status: " + officeHandler.ExtractLicenseStatus(PwshOutput) + " (" + officeHandler.GetLicenseType() + ") ";
            ProductNameLbl.Text = "Software: " + officeHandler.GetProductName() + officeHandler.GetPlatform();
            VersionLbl.Text = "Build: " + officeHandler.Version;

            InfoButton.PerformClick();
        }

        public void Activation()
        {
            switch (ProductDrop.SelectedIndex)
            {
                case 0:
                    DirtyOutput = Pwsh.ExecuteCommand("cmd /c \"for /f %x in ('dir /b ..\\root\\Licenses16\\proplusvl_kms*.xrm-ms') do cscript //nologo ospp.vbs /inslic:..\\root\\Licenses16\\%x\"; cscript //nologo ospp.vbs /inpkey:XQNVK-8JYDB-WJ9W3-YJ8YR-WFG99;" +
                        "cscript //nologo ospp.vbs /unpkey:BTDRB >nul; cscript //nologo ospp.vbs /unpkey:KHGM9 >nul; cscript //nologo ospp.vbs /unpkey:CPQVG >nul");
                    break;

                case 1:
                    DirtyOutput = Pwsh.ExecuteCommand("cmd /c \"for /f %x in ('dir /b ..\\root\\Licenses16\\ProPlus2021VL_KMS*.xrm-ms') do cscript //nologo ospp.vbs /inslic:..\\root\\Licenses16\\%x\"; cscript //nologo ospp.vbs /unpkey:6F7TH >nul;" +
                        "cscript //nologo ospp.vbs /inpkey:FXYTK-NJJ8C-GB6DW-3DYQT-6F7TH");
                    break;
                case 2:
                    DirtyOutput = Pwsh.ExecuteCommand("cmd /c \"for /f %x in ('dir /b ..\\root\\Licenses16\\ProPlus2019VL*.xrm-ms') do cscript //nologo ospp.vbs /inslic:..\\root\\Licenses16\\%x\"; cscript //nologo ospp.vbs /unpkey:6MWKP >nul;" +
                        "cscript //nologo ospp.vbs /inpkey:NMMKJ-6RK4F-KMJVX-8D9MJ-6MWKP");
                    break;
                case 3:
                    DirtyOutput = Pwsh.ExecuteCommand("cmd /c \"for /f %x in ('dir /b ..\\root\\Licenses16\\proplusvl_kms*.xrm-ms') do cscript //nologo ospp.vbs /inslic:..\\root\\Licenses16\\%x\"; cscript //nologo ospp.vbs /inpkey:XQNVK-8JYDB-WJ9W3-YJ8YR-WFG99;" +
                        "cscript //nologo ospp.vbs /unpkey:BTDRB >nul; cscript //nologo ospp.vbs /unpkey:KHGM9 >nul; cscript //nologo ospp.vbs /unpkey:CPQVG >nul");
                    break;
                case 4:
                    DirtyOutput = Pwsh.ExecuteCommand("cscript //nologo ospp.vbs /inpkey:YC7DK-G2NP3-2QQC3-J6H88-GVGXT");
                    break;
            }
        }


        private void InfoButton_Click(object sender, EventArgs e)
        {
            DirtyOutput = Pwsh.ExecuteCommand("cscript //nologo ospp.vbs /dstatus");
            ShellBox.Text = officeHandler.ClearOutput(DirtyOutput);
        }

        private void ActivateButton_Click(object sender, EventArgs e)
        {
            DirtyOutput = Pwsh.ExecuteCommand("cscript //nologo ospp.vbs /setprt:1688");
            ShellBox.Text = officeHandler.ClearOutput(DirtyOutput);

            switch (MethodDrop.SelectedIndex)
            {
                case 0:
                    DirtyOutput = Pwsh.ExecuteCommand("cscript //nologo ospp.vbs /act");
                    ShellBox.Text = officeHandler.ClearOutput(DirtyOutput);
                    break;

                case 1:
                    DirtyOutput = Pwsh.ExecuteCommand("cscript //nologo ospp.vbs /act");
                    ShellBox.Text = officeHandler.ClearOutput(DirtyOutput);
                    break;
                
                case 2:
                    DirtyOutput = Pwsh.ExecuteCommand("cscript //nologo ospp.vbs /rearm");
                    ShellBox.Text = officeHandler.ClearOutput(DirtyOutput);
                    break;
            }

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
        }

    }
}
