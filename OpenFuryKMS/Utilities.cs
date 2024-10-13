using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.Win32;
using Microsoft.Win32.TaskScheduler;
using System.Management.Automation;
using System.Reflection;
using System.Text.RegularExpressions;


namespace OpenFuryKMS
{
    public static class PowershellHandler
    {
        public static string RunCommand(string cmd)
        {
            PowerShell ps = PowerShell.Create();
            ps.AddScript(cmd);
            var result = ps.Invoke();
            return string.Join(Environment.NewLine, result.Select(o => o.ToString()));
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

    public static class WindowsHandler
    {
        private static string WindowsPath = @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion";
        private static string DisplayVersion = Registry.GetValue(WindowsPath, "DisplayVersion", "").ToString();
        private static string Build = Registry.GetValue(WindowsPath, "CurrentBuildNumber", "").ToString();
        private static string Platform = Environment.Is64BitOperatingSystem ? "64 bits" : "32 bits";
        private static string UBR = Registry.GetValue(WindowsPath, "UBR", "").ToString();
        private static string EditionID = Registry.GetValue(WindowsPath, "EditionID", "").ToString();
        
        public static string ProductName = Registry.GetValue(WindowsPath, "ProductName", "").ToString();
        public static string Version = $"{DisplayVersion} ({Build}.{UBR})";
        public static string GetMinimalInfo = $"{ProductName} {DisplayVersion} {Platform}";
        public static string GetAllInfo = string.Empty;

        public static void Windows11Fix()
        {
            if (int.TryParse(Build, out var buildNumber) && buildNumber >= 22000)
            {
                ProductName = ProductName.Replace("Windows 10", "Windows 11");
            }
            GetAllInfo = $"Microsoft {ProductName} {Platform}";
        }

        public static int SetEdition()
        {
            string[] products = { "Home", "Pro", "Education", "Enterprise", "Server" };
            return Array.FindIndex(products, p => WindowsHandler.ProductName.Contains(p));
        }

        public static readonly List<(string License, string Description)> Home_Licenses =
        [
            ("TX9XD-98N7V-6WMQ6-BX7FG-H8Q99", ""),
            ("3KHY7-WNT83-DGQKR-F7HPR-844BM", " (N)"),
            ("7HNRX-D7KGG-3K4RQ-4WPJ4-YTDFH", " (Single Language)"),
            ("PVMJN-6DFY6-9CCP6-7BKTT-D3WVR", " (Country Specific)")
        ];
        public static readonly List<(string License, string Description)> Pro_Licenses =
        [
            ("W269N-WFGWX-YVC9B-4J6C9-T83GX", ""),
            ("MH37W-N47XK-V7XM9-C7227-GCQG9", " (N)")
        ];
        public static readonly List<(string License, string Description)> Education_Licenses =
        [
            ("NW6C2-QMPVW-D7KKK-3GKT6-VCFB2", ""),
            ("2WH4N-8QGBV-H22JP-CT43Q-MDWWJ", " (N)")
        ];
        public static readonly List<(string License, string Description)> Enterprise_Licenses =
        [
            ("NPPR9-FWDCX-D2C8J-H872K-2YT43", ""),
            ("DPH2V-TTNVB-4X9Q3-TJR4H-KHJW4", " (N)")
        ];

        public static string ExtractLicenseStatus(string output)
        {
            var licenseStatusMap = new Dictionary<string, string>
            {
                {"Licensed", "Licensed"},
                {"Notification", "Unicensed"},
                {"Initial grace period", "Trial"}
            };
            var match = Regex.Match(output, @"License Status:\s*(.*)");
            if (!match.Success) return "Unicensed";
            var status = match.Groups[1].Value.Trim();
            return licenseStatusMap.ContainsKey(status) ? licenseStatusMap[status] : "Unicensed";
        }
    }

    public static class OfficeHandler
    {
        private static string OfficePath_C2R = @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Office\ClickToRun\Configuration";
        public static string Version = Registry.GetValue(OfficePath_C2R, "VersionToReport", "").ToString();
        public static string Platform = Registry.GetValue(OfficePath_C2R, "Platform", "").ToString().Contains("x64") ? "64 bits" : "32 bits";
        public static string ReleaseId = Registry.GetValue(OfficePath_C2R, "ProductReleaseIds", "").ToString();

        /* I don't use: HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\**OFFICE VERSION**
           because it's hard to maintain both x86 & x64 bit builds and rename other Office products, without considering
           that each Office version has its own language */

        public static string ProductName = string.Empty;

        public static Dictionary<string, string> versions = new()
        {
            { "365", "Microsoft 365" },
            { "2021", "Microsoft Office 2021" },
            { "2019", "Microsoft Office 2019" },
            { "2016", "Microsoft Office 2016" },
            { "2013", "Microsoft Office 2013" }
        };

        public static void GetProductName()
        {
            foreach (var version in versions)
            {
                if (ReleaseId.Contains(version.Key))
                {
                    ProductName = version.Value;
                    return;
                }
            }
            ProductName = "Product not found";
        }

        public static bool DirChecker()
        {
            string[] officePaths =
            {
                @"C:\Program Files\Microsoft Office\Office16",
                @"C:\Program Files\Microsoft Office\Office15",
                @"C:\Program Files (x86)\Microsoft Office\Office16",
                @"C:\Program Files (x86)\Microsoft Office\Office15"
            };

            foreach (string officePath in officePaths)
            {
                if (!Directory.Exists(officePath)) continue;
                Directory.SetCurrentDirectory(officePath);
                return true;
            }
            return false;
        }

        public static int SetVersion()
        {
            return versions.Values.ToList().FindIndex(p => ProductName.Contains(p));
        }

        /*public string GetLicenseType()
        {
            return ReleaseId.EndsWith("Retail") ? "Retail" : ReleaseId.EndsWith("Volume") ? "Volume" : "";
        }*/

        public static Dictionary<int, (string productKey, List<string> keys, string license)> productLicenses = new()
        {
            { 0, ("proplusvl_kms", new List<string> { "BTDRB", "KHGM9", "CPQVG" }, "XQNVK-8JYDB-WJ9W3-YJ8YR-WFG99") },
            { 1, ("ProPlus2021VL_KMS", new List<string> { "PG343", "6F7TH" }, "FXYTK-NJJ8C-GB6DW-3DYQT-6F7TH") },
            { 2, ("ProPlus2019VL", new List<string> { "6MWKP" }, "NMMKJ-6RK4F-KMJVX-8D9MJ-6MWKP") },
            { 3, ("proplusvl_kms", new List<string> { "BTDRB", "KHGM9", "CPQVG" }, "XQNVK-8JYDB-WJ9W3-YJ8YR-WFG99") },
            { 4, ("", new List<string>(), "YC7DK-G2NP3-2QQC3-J6H88-GVGXT") }
        };

        public static string ExtractLicenseStatus(string output)
        {
            var licenseStatusMap = new Dictionary<string, string>
            {
                {"---LICENSED---", "Licensed"},
                {"---NOTIFICATIONS---", "Unlicensed"},
                {"---OOB_GRACE---", "Trial"}
            };

            var match = Regex.Match(output, @"LICENSE STATUS:\s*(.*)");
            if (!match.Success) return "Unlicensed";
            var status = match.Groups[1].Value.Trim();
            return licenseStatusMap.ContainsKey(status) ? licenseStatusMap[status] : "Unlicensed";
        }

        public static string ClearOutput(string output)
        {
            var lines = output.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            var cleanedLines = lines.Where(line => !line.Contains("---Processing--------------------------") && !line.Contains("---Exiting-----------------------------") && !line.Contains("---------------------------------------"));
            return string.Join(Environment.NewLine, cleanedLines);
        }

        public static string InstallLicense(string product, IEnumerable<string> lastKeys, string licenseKey)
        {
            var output = $"cmd /c \"for /f %x in ('dir /b ..\\root\\Licenses16\\{product}*.xrm-ms') do cscript //nologo ospp.vbs /inslic:..\\root\\Licenses16\\%x\"; cscript //nologo ospp.vbs /setprt:1688; ";

            foreach (var lastKey in lastKeys)
            {
                output += $"cscript //nologo ospp.vbs /unpkey:{lastKey}; ";
            }

            output += $"cscript //nologo ospp.vbs /inpkey:{licenseKey}";
            return output;
        }
    }

    public class CreateTask
    {
        public string script = "WindowsRenewer";
        public string appDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "OpenFuryKMS");
        public string scriptFilePath;

        public CreateTask()
        {
            scriptFilePath = Path.Combine(appDataPath, $"{script}.ps1");
            SaveScript();
            CreateScheduledTask();
        }

        public void SaveScript()
        {
            Directory.CreateDirectory(appDataPath);
            string scriptPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Scripts", $"{script}.ps1");
            try
            {
                if (!File.Exists(scriptFilePath) || File.GetLastWriteTime(scriptPath) > File.GetLastWriteTime(scriptFilePath))
                {
                    File.Copy(scriptPath, scriptFilePath, true);
                    //Console.WriteLine($"Script {script}.ps1 copiado a {appDataPath} exitosamente.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al copiar el script: {ex.Message}");
            }
        }

        public void CreateScheduledTask()
        {
            try
            {
                using (TaskService taskService = new TaskService())
                {
                    string taskFolderName = "OpenFuryKMS";
                    TaskFolder tf;

                    try
                    {
                        tf = taskService.GetFolder(taskFolderName);
                    }
                    catch
                    {
                        tf = taskService.RootFolder.CreateFolder(taskFolderName);
                    }

                    if (tf.GetTasks().FirstOrDefault(t => t.Name == script) == null)
                    {
                        TaskDefinition td = taskService.NewTask();
                        td.RegistrationInfo.Description = $"Ejecuta el script {script}.ps1 cada 181 días";
                        td.Triggers.Add(new DailyTrigger { DaysInterval = 181 });
                        td.Actions.Add(new ExecAction("powershell.exe", $"-ExecutionPolicy Bypass -File \"{scriptFilePath}\"", null));
                        tf.RegisterTaskDefinition(script, td);
                        //Console.WriteLine("Tarea 'WindowsRenewer' creada exitosamente.");
                    }
                    else
                    {
                        Console.WriteLine("La tarea 'WindowsRenewer' ya existe.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear la tarea: {ex.Message}");
            }
        }
    }
}