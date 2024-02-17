using Microsoft.Win32.TaskScheduler;
using OpenFuryKMS.Properties;
using OpenFuryKMS.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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

            productNameLbl.Text = $"Software: {officeHandler.GetProductName()} {officeHandler.GetPlatform()}";

            officeHandler.DirChecker();
            Autodetect();
            GetLicenseStatus();

            Dictionary<string, Image> productToImage = new Dictionary<string, Image>
            {
                { "365", Properties.Resources.microsoft365 },
                { "2021", Properties.Resources.microsoft365 },
                { "2019", Properties.Resources.Office2019_2021 },
                { "2016", Properties.Resources.Office2013_2016 },
                { "2013", Properties.Resources.Office2013_2016 }
            };
            foreach (var item in productToImage)
            {
                if (officeHandler.GetProductName().Contains(item.Key))
                {
                    productLogo.Image = item.Value;
                    break;
                }
            }
            shellBox.Text = officeHandler.ClearOutput(pwshOutput);
            LoadLanguage();
        }

        public void LoadLanguage()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Settings.Default.Language);
            infoTitleLbl.Text = Language.infoTitleLbl;
            versionLbl.Text = Language.versionLbl + officeHandler.Version;
            actTitleLbl.Text = Language.actTitleLbl;
            productLbl.Text = Language.productsLbl;
            kmsLbl.Text = Language.kmsLbl;
            methodLbl.Text = Language.methodLbl;
            productDrop.Text = Language.productDrop;
            serverDrop.Text = Language.serverDrop;
            methodDrop.Text = Language.methodDrop;
            activateBtn.Text = Language.activateBtn;
            infoBtn.Text = Language.infoBtn;
            removeBtn.Text = Language.removeBtn;
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
                if (!officeHandler.GetProductName().Contains(item.Key)) continue;
                productDrop.SelectedIndex = item.Value;
                serverDrop.Enabled = true;
                break;
            }
        }

        public void GetLicenseStatus()
        {
            pwshOutput = pwsh.ExecuteCommand("cscript //nologo ospp.vbs /dstatus");
            string licenseStatus = officeHandler.ExtractLicenseStatus(pwshOutput);
            statusLbl.Text = Language.statusLbl + licenseStatus;
            removeBtn.Enabled = licenseStatus != Language.Unlicensed;
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
                    dirtyOutput = officeHandler.InstallLicense("ProPlus2021VL_KMS", new List<string> { "PG343", "6F7TH" }, "FXYTK-NJJ8C-GB6DW-3DYQT-6F7TH");
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

        private void SwitchControls()
        {
            bool isMethodZero = methodDrop.SelectedIndex == 0;
            bool isMethodOneOrTwo = methodDrop.SelectedIndex == 1 || methodDrop.SelectedIndex == 2;
            bool isServerSelected = serverDrop.SelectedIndex != -1;

            activateBtn.Enabled = (isMethodZero && isServerSelected) || isMethodOneOrTwo;
            productDrop.Enabled = !isMethodOneOrTwo;
            serverDrop.Enabled = !isMethodOneOrTwo;
        }

        private void CreateTask()
        {
            string targetFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "OpenFuryKMS");
            string targetPath = Path.Combine(targetFolder, "OfficeRenewer.ps1");

            Directory.CreateDirectory(targetFolder);

            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "OpenFuryKMS.Resources.Scripts.OfficeRenewer.ps1";

            if (assembly.GetManifestResourceNames().Contains(resourceName))
            {
                using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                using (StreamReader reader = new StreamReader(stream))
                {
                    File.WriteAllText(targetPath, reader.ReadToEnd());
                }
            }

            using (TaskService ts = new TaskService())
            {
                string taskFolderName = "\\OpenFuryKMS";
                TaskFolder tf = ts.GetFolder(taskFolderName);

                if (tf == null)
                {
                    tf = ts.RootFolder.CreateFolder(taskFolderName);
                }

                if (tf.GetTasks().FirstOrDefault(t => t.Name == "OfficeRenewer") == null)
                {
                    TaskDefinition td = ts.NewTask();
                    td.RegistrationInfo.Description = "Ejecuta el script OfficeRenewer.ps1 cada 180 días";
                    td.Triggers.Add(new DailyTrigger { DaysInterval = 182 });
                    td.Actions.Add(new ExecAction("powershell.exe", $"-File \"{targetPath}\""));
                    tf.RegisterTaskDefinition("OfficeRenewer", td);
                }
            }
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
            if (methodDrop.SelectedIndex < 2)
            {
                using (TaskService ts = new TaskService())
                {
                    string taskFolderName = "\\OpenFuryKMS";
                    TaskFolder tf = ts.GetFolder(taskFolderName);
                    if (tf == null || tf.GetTasks().FirstOrDefault(t => t.Name == "OfficeRenewer") == null)
                    {
                        if (MessageBox.Show("¿Desea crear la tarea?", "Confirmación", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            CreateTask();
                            MessageBox.Show("La tarea ha sido creada exitosamente.");
                        }
                    }
                }
            }
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

        private void serverDrop_SelectedIndexChanged(object sender, EventArgs e)
        {
            SwitchControls();
        }
        private void methodDrop_SelectedIndexChanged(object sender, EventArgs e)
        {
            SwitchControls();
        }
    }
}