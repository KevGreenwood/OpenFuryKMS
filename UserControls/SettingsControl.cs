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
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace OpenFuryKMS.UserControls
{
    public partial class SettingsControl : UserControl
    {
        private MainForm main { get; }
        public SettingsControl(MainForm mainForm)
        {
            InitializeComponent();
            main = mainForm;
        }
        private void SettingsControl_Load(object sender, EventArgs e)
        {
            removeWindowsBtn.Enabled = CheckTaskAndFile("WindowsRenewer");
            removeOfficeBtn.Enabled = CheckTaskAndFile("OfficeRenewer");
            LoadLanguage();
            langDrop.Text = Settings.Default.LanguageSelected;
        }

        private string GetTargetPath(string fileName)
        {
            string targetFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "OpenFuryKMS");
            return Path.Combine(targetFolder, $"{fileName}.ps1");
        }
        private bool CheckTaskAndFile(string fileName)
        {
            string targetPath = GetTargetPath(fileName);
            bool fileExists = File.Exists(targetPath);

            bool taskExists = false;
            using (TaskService ts = new TaskService())
            {
                string taskFolderName = "\\OpenFuryKMS";
                TaskFolder tf = ts.GetFolder(taskFolderName);
                if (tf != null)
                {
                    Task task = tf.GetTasks().FirstOrDefault(t => t.Name == fileName);
                    taskExists = task != null;
                }
            }
            return fileExists || taskExists;
        }
        private bool DeleteTaskAndFile(string fileName)
        {
            string targetPath = GetTargetPath(fileName);

            if (File.Exists(targetPath))
            {
                File.Delete(targetPath);
            }

            using (TaskService ts = new TaskService())
            {
                TaskFolder tf = ts.GetFolder("\\OpenFuryKMS");
                if (tf != null)
                {
                    Task task = tf.GetTasks().FirstOrDefault(t => t.Name == fileName);

                    if (task != null)
                    {
                        tf.DeleteTask(fileName);
                    }
                }
            }
            MessageBox.Show("La tarea y el archivo han sido eliminados exitosamente.");
            return false;
        }

        public void LoadLanguage()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Settings.Default.Language);
            settingsLbl.Text = Language.settingsBtn;
            langLbl.Text = Language.langLbl;

            updatesLbl.Text = Language.updatesLbl;
            downloadBtn.Text = Language.updatesBtn;
            removeOfficeBtn.Text = Language.homeBtn;
            aboutLbl.Text = Language.aboutLbl;

            main.LoadLanguage();
        }

        private void langDrop_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] languages = { "en", "es", "ru" };
            if (langDrop.SelectedIndex >= 0 && langDrop.SelectedIndex < languages.Length)
            {
                Settings.Default.Language = languages[langDrop.SelectedIndex];
                LoadLanguage();
                Settings.Default.LanguageSelected = langDrop.Text;
            }
        }
        private void removeWindowsBtn_Click(object sender, EventArgs e)
        {
            removeWindowsBtn.Enabled = DeleteTaskAndFile("WindowsRenewer");
        }
        private void removeOfficeBtn_Click(object sender, EventArgs e)
        {
            removeOfficeBtn.Enabled = DeleteTaskAndFile("OfficeRenewer");
        }
    }
}