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
        private MainForm main {  get; }
        public SettingsControl(MainForm mainForm)
        {
            InitializeComponent();
            CheckTaskAndFile();
            main = mainForm;
        }
        private void SettingsControl_Load(object sender, EventArgs e)
        {
            LoadLanguage();
            langDrop.Text = Settings.Default.LanguageSelected;
        }

        private void CheckTaskAndFile()
        {
            string targetFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "OpenFuryKMS");
            string targetPath = Path.Combine(targetFolder, "WindowsRenewer.ps1");

            bool fileExists = File.Exists(targetPath);

            bool taskExists = false;
            using (TaskService ts = new TaskService())
            {
                string taskFolderName = "\\OpenFuryKMS";
                TaskFolder tf = ts.GetFolder(taskFolderName);
                if (tf != null)
                {
                    Task task = tf.GetTasks().FirstOrDefault(t => t.Name == "WindowsRenewer");
                    taskExists = task != null;
                }
            }
            removeWin_Btn.Enabled = fileExists || taskExists;
        }

        public void LoadLanguage()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Settings.Default.Language);
            removeWin_Btn.Text = Language.homeBtn;
            main.LoadLanguage();
        }

        private void removeWin_Btn_Click(object sender, EventArgs e)
        {
            string targetFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "OpenFuryKMS");
            string targetPath = Path.Combine(targetFolder, "WindowsRenewer.ps1");

            if (File.Exists(targetPath))
            {
                File.Delete(targetPath);
            }

            using (TaskService ts = new TaskService())
            {
                TaskFolder tf = ts.GetFolder("\\OpenFuryKMS");
                if (tf != null)
                {
                    Task task = tf.GetTasks().FirstOrDefault(t => t.Name == "WindowsRenewer");

                    if (task != null)

                    {
                        tf.DeleteTask("WindowsRenewer");
                    }
                }
            }
            MessageBox.Show("La tarea y el archivo han sido eliminados exitosamente.");
            removeWin_Btn.Enabled = false;
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
    }
}