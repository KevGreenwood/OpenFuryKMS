using Microsoft.Win32.TaskScheduler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OpenFuryKMS.UserControls
{
    public partial class SettingsControl : UserControl
    {
        public SettingsControl()
        {
            InitializeComponent();
            CheckTaskAndFile();
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

        private void removeWin_Btn_Click(object sender, EventArgs e)
        {
            string targetFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "OpenFuryKMS");
            string targetPath = Path.Combine(targetFolder, "WindowsRenewer.ps1");

            // Elimina el archivo si existe
            if (File.Exists(targetPath))
            {
                File.Delete(targetPath);
            }

            using (TaskService ts = new TaskService())
            {
                // Especifica el nombre de la carpeta donde está la tarea
                string taskFolderName = "\\OpenFuryKMS";

                // Intenta obtener la carpeta
                TaskFolder tf = ts.GetFolder(taskFolderName);

                // Si la carpeta existe, intenta obtener la tarea
                if (tf != null)
                {
                    Task task = tf.GetTasks().FirstOrDefault(t => t.Name == "WindowsRenewer");

                    // Si la tarea existe, elimínala
                    if (task != null)
                    {
                        tf.DeleteTask("WindowsRenewer");
                    }
                }
            }

            MessageBox.Show("La tarea y el archivo han sido eliminados exitosamente.");
            removeWin_Btn.Enabled = false;
        }
    }
}
