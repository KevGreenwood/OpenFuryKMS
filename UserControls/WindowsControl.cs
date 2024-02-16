using FontAwesome.Sharp;
using Microsoft.Win32.TaskScheduler;
using OpenFuryKMS.Properties;
using OpenFuryKMS.Resources;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Threading;
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
            shellBox.Text = pwshOutput;
            LoadLanguage();
        }

        public void LoadLanguage()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Settings.Default.Language);
            infoTitleLbl.Text = Language.infoTitleLbl;
            osLbl.Text = Language.osLbl + windowsHandler.GetAllInfo;
            versionLbl.Text = Language.versionLbl + windowsHandler.Version;
            actTitleLbl.Text = Language.actTitleLbl;
            productLbl.Text = Language.productsLbl;
            licenseLbl.Text = Language.licensesLbl;
            kmsLbl.Text = Language.kmsLbl;
            methodLbl.Text = Language.methodLbl;
            productDrop.Text = Language.productDrop;
            licenseDrop.Text = Language.licenceDrop;
            serverDrop.Text = Language.serverDrop;
            methodDrop.Text = Language.methodDrop;
            activateBtn.Text = Language.activateBtn;
            infoBtn.Text = Language.infoBtn;
            removeBtn.Text = Language.removeBtn;
        }

        public void GetLicenseStatus()
        {
            pwshOutput = pwsh.ExecuteCommand("cscript //nologo slmgr.vbs /dli");
            string licenseStatus = windowsHandler.ExtractLicenseStatus(pwshOutput);
            statusLbl.Text = Language.statusLbl + licenseStatus;
            removeBtn.Enabled = licenseStatus != Language.Unlicensed;
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

        private void SwitchControls()
        {
            bool isMethodZero = methodDrop.SelectedIndex == 0;
            bool isMethodOneOrTwo = methodDrop.SelectedIndex == 1 || methodDrop.SelectedIndex == 2;
            bool isLicenseAndServerSelected = licenseDrop.SelectedIndex != -1 && serverDrop.SelectedIndex != -1;

            activateBtn.Enabled = (isMethodZero && isLicenseAndServerSelected) || isMethodOneOrTwo;
            productDrop.Enabled = !isMethodOneOrTwo;
            licenseDrop.Enabled = !isMethodOneOrTwo;
            serverDrop.Enabled = !isMethodOneOrTwo;
        }

        private void CreateTask()
        {
            string targetFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "OpenFuryKMS");
            string targetPath = Path.Combine(targetFolder, "WindowsRenewer.ps1");

            Directory.CreateDirectory(targetFolder);

            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "OpenFuryKMS.Resources.Scripts.WindowsRenewer.ps1";

            if (!File.Exists(targetPath) && assembly.GetManifestResourceNames().Contains(resourceName))
            {
                using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                using (StreamReader reader = new StreamReader(stream))
                {
                    File.WriteAllText(targetPath, reader.ReadToEnd());
                }
            }

            using (TaskService ts = new TaskService())
            {
                // Especifica el nombre de la carpeta donde quieres crear la tarea
                string taskFolderName = "\\OpenFuryKMS";

                // Intenta obtener la carpeta
                TaskFolder tf = ts.GetFolder(taskFolderName);

                // Si la carpeta no existe, créala
                if (tf == null)
                {
                    tf = ts.RootFolder.CreateFolder(taskFolderName);
                }

                // Si la tarea no existe, créala
                if (tf.GetTasks().FirstOrDefault(t => t.Name == "WindowsRenewer") == null)
                {
                    TaskDefinition td = ts.NewTask();
                    td.RegistrationInfo.Description = "Ejecuta el script WindowsRenewer.ps1 cada 180 días";
                    td.Triggers.Add(new DailyTrigger { DaysInterval = 180 });
                    td.Actions.Add(new ExecAction("powershell.exe", $"-File \"{targetPath}\""));

                    // Registra la tarea en la carpeta especificada
                    tf.RegisterTaskDefinition("WindowsRenewer", td);
                }
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
            if (methodDrop.SelectedIndex < 2)
            {
                using (TaskService ts = new TaskService())
                {
                    string taskFolderName = "\\OpenFuryKMS";
                    TaskFolder tf = ts.GetFolder(taskFolderName);
                    if (tf == null || tf.GetTasks().FirstOrDefault(t => t.Name == "WindowsRenewer") == null)
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
        }
        private void licenseDrop_SelectedIndexChanged(object sender, EventArgs e)
        {
            SwitchControls();
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