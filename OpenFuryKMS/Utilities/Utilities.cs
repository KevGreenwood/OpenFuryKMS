using Microsoft.Win32.TaskScheduler;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
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
                    var errors = results.Select(o => o.ToString());
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

        public static async Task<string> RunCommandAsync(string cmd)
        {
            return await System.Threading.Tasks.Task.Run(() =>
            {
                using Runspace runspace = RunspaceFactory.CreateRunspace();
                runspace.Open();

                using PowerShell ps = PowerShell.Create();
                ps.Runspace = runspace;
                ps.AddScript(cmd);

                try
                {
                    var results = ps.Invoke();
                    if (ps.HadErrors)
                    {
                        var errors = results.Select(o => o.ToString());
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
                    runspace.Close();
                }
            });
        }
    }

    public static class KMSHandler
    {
        public static List<string> KmsServers =
        [
            "Auto",
            "kms.digiboy.ir",
            "kms.03k.org",
            "kms-default.cangshui.net",
            "kms.sixyin.com",
            "kms.cgtsoft.com",
            "kms.idina.cn",
            "kms.moeyuuko.com",
            "xincheng213618.cn",
            "kms.loli.best",
            "kms.myds.cloud",
            "kms.0t.net.cn",
            "kms.wxlost.com",
            "kms.moeyuuko.top",
            "kms.ghpym.com",
            "kms.chinancce.com",
            "kms.ddns.net",
            "dimanyakms.sytes.net",
            "ms8.us.to",
            "s8.uk.to",
            "s9.us.to",
            "kms9.msguides.com",
            "kms8.msguides.com",
        ];

        public static async Task<string> AutoKMS(bool windows = false, bool office = false)
        {
            foreach (var server in KmsServers.Skip(1))
            {
                var setKms = windows ? $"cscript //nologo slmgr.vbs /skms {server} 2>&1" :
                              office ? $"cscript //nologo ospp.vbs /sethst:{server} 2>&1" : string.Empty;

                var activate = windows ? "cscript //nologo slmgr.vbs /ato" :
                                office ? "cscript //nologo ospp.vbs /act" : string.Empty;

                var result = await PowershellHandler.RunCommandAsync($"{setKms}; {activate}");

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
                    TaskDefinition taskDefinition = ts.NewTask();
                    taskDefinition.RegistrationInfo.Description = $"Executes the script {script}.ps1 every 181 days.";
                    taskDefinition.Triggers.Add(new DailyTrigger { DaysInterval = 181 });
                    taskDefinition.Actions.Add(new ExecAction("powershell.exe", $"-ExecutionPolicy Bypass -File \"{scriptFilePath}\"", null));
                    tf.RegisterTaskDefinition(script, taskDefinition);
                }
                return "Task created successfully.";
            }
            catch (Exception ex)
            {
                return $"Error creating the task: {ex.Message}";
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

        public void RecreateTask()
        {
            DeleteTask();
            CreateScheduledTask();
        }
    }

    public static class InternetConnection
    {
        public static bool result;

        public static async System.Threading.Tasks.Task IsInternetAvailable()
        {
            try
            {
                using var client = new HttpClient();
                client.Timeout = TimeSpan.FromSeconds(5);
                var response = await client.GetAsync("https://www.google.com");
                result = response.IsSuccessStatusCode;
            }
            catch
            {
                result = false;
            }
        }
    }
}