using Microsoft.Win32.TaskScheduler;
using System.Management.Automation;
using System.Reflection;


namespace OpenFuryKMS
{
    public static class PowershellHandler
    {
        public static string RunCommand(string cmd)
        {
            PowerShell ps = PowerShell.Create();
            ps.AddScript(cmd);
            try
            {
                var results = ps.Invoke();
                if (ps.HadErrors)
                {
                    var errors = ps.Streams.Error.Select(e => e.ToString());
                    return $"Error executing command: {cmd}{Environment.NewLine}{string.Join(Environment.NewLine, errors)}";
                }

                return string.Join(Environment.NewLine, results.Select(o => o.ToString()));
            }
            catch (Exception ex)
            {
                return $"Exception occurred: {ex.Message}";
            }
            finally
            {
                ps.Dispose();
            }
        }
    }

    public static class KMSHandler
    {
        public static List<string> KmsServers =
        [
            "Auto",
            "kms.digiboy.ir",
            "kms.chinancce.com",
            "kms.ddns.net",
            "xykz.f3322.org",
            "dimanyakms.sytes.net",
            "kms.03k.org",
            "ms8.us.to",
            "s8.uk.to",
            "s9.us.to",
            "kms9.msguides.com",
            "kms8.msguides.com",
            "kms7.msguides.com"
        ];

        public static string AutoKMS(bool windows = false, bool office = false)
        {
            foreach (var server in KmsServers.Skip(1))
            {
                var setKms = windows ? $"cscript //nologo slmgr.vbs /skms {server} 2>&1" :
                              office ? $"cscript //nologo ospp.vbs /sethst:{server} 2>&1" : string.Empty;

                var activate = windows ? "cscript //nologo slmgr.vbs /ato" :
                                office ? "cscript //nologo ospp.vbs /act" : string.Empty;

                var result = PowershellHandler.RunCommand($"{setKms}; {activate}");

                if (result.Contains("successful"))
                {
                    return result;
                }
            }
            return "The connection to KMS Servers failed! Please try again and make sure you have an internet connection.";
        }
    }

    public class RenewTask
    {
        public string script;
        public string appDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "OpenFuryKMS");
        public string scriptFilePath;
        public const string taskFolderName = "\\OpenFuryKMS";
        public TaskService ts = new();
        public TaskFolder? tf;

        public RenewTask(string scriptName)
        {
            script = scriptName;
            scriptFilePath = Path.Combine(appDataPath, $"{script}.ps1");
        }

        private void SaveScript()
        {
            Directory.CreateDirectory(appDataPath);

            if (!File.Exists(scriptFilePath))
            {
                var assembly = Assembly.GetExecutingAssembly();
                var resourceName = $"OpenFuryKMS.Scripts.{script}.ps1";
                if (assembly.GetManifestResourceNames().Contains(resourceName))
                {
                    using Stream? stream = assembly.GetManifestResourceStream(resourceName);
                    using FileStream fileStream = new(scriptFilePath, FileMode.Create, FileAccess.Write);
                    stream?.CopyTo(fileStream);
                }
            }
        }

        public bool IsTaskScheduled()
        {
            try
            {
                GetTaskFolder();
                var task = tf?.GetTasks().FirstOrDefault(t => t.Name == script);
                return task != null;
            }
            catch
            {
                return false;
            }
        }

        public string CreateScheduledTask()
        {
            SaveScript();
            try
            {
                GetTaskFolder();
                tf ??= ts.RootFolder.CreateFolder(taskFolderName);

                if (tf.GetTasks().FirstOrDefault(t => t.Name == script) == null)
                {
                    TaskDefinition td = ts.NewTask();
                    td.RegistrationInfo.Description = $"Ejecuta el script {script}.ps1 cada 181 días";
                    td.Triggers.Add(new DailyTrigger { DaysInterval = 181 });
                    td.Actions.Add(new ExecAction("powershell.exe", $"-ExecutionPolicy Bypass -File \"{scriptFilePath}\"", null));
                    tf.RegisterTaskDefinition(script, td);
                }
                return "Tarea creada correctamente";
            }
            catch (Exception ex)
            {
                return $"Error al crear la tarea: {ex.Message}";
            }
        }

        public void DeleteTask()
        {
            if (File.Exists(scriptFilePath))
            {
                File.Delete(scriptFilePath);
            }

            GetTaskFolder();
            if (tf != null)
            {
                Microsoft.Win32.TaskScheduler.Task task = tf.GetTasks().FirstOrDefault(t => t.Name == script);

                if (task != null)
                {
                    tf.DeleteTask(script);
                }
            }
        }

        public void CleanAll()
        {
            DeleteTask();

            if (Directory.GetFiles(appDataPath) == null)
            {
                Directory.Delete(appDataPath);
            }

            GetTaskFolder();
            tf?.DeleteFolder(taskFolderName);
        }

        private void GetTaskFolder() => tf = ts.GetFolder(taskFolderName);
    }
}