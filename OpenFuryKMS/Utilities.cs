using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;
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
        private const string WindowsPath = @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion";

        public static string DisplayVersion { get; private set; }
        public static string Build { get; private set; }
        public static string Platform = Environment.Is64BitOperatingSystem ? "64 bits" : "32 bits";
        public static string UBR { get; private set; }
        public static string ProductName { get; private set; }
        public static string Version => $"{DisplayVersion} ({Build}.{UBR})";
        public static string GetMinimalInfo => $"{ProductName} {DisplayVersion} {Platform}";
        public static string GetAllInfo { get; private set; }
        public static string LicenseStatus { get; private set; }
        public static string ShellOutput { get; private set; }
        public static ImageSource Logo { get; private set; }

        public static RenewTask task = new("WindowsRenewer");

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
            ("2WH4N-8QGBV-H22JP-CT43Q-MDWWJ", " (N)"),
            ("6TP4R-GNPTD-KYYHQ-7B7DP-J447Y", " (Pro)"),
            ("YVWGF-BXNMC-HTQYQ-CPQ99-66QFC", " (Pro N)"),
        ];
        public static readonly List<(string License, string Description)> Enterprise_Licenses =
        [
            ("NPPR9-FWDCX-D2C8J-H872K-2YT43", ""),
            ("DPH2V-TTNVB-4X9Q3-TJR4H-KHJW4", " (N)"),
            ("YYVX9-NTFWV-6MDM3-9PT4T-4M68B", " (G)"),
            ("44RPN-FTY23-9VTTB-MP9BX-T84FV", " (G N)"),
        ];

        public static async System.Threading.Tasks.Task InitializeAsync()
        {
            Build = await GetRegistryValueAsync(WindowsPath, "CurrentBuildNumber");
            ProductName = await GetRegistryValueAsync(WindowsPath, "ProductName");

            if (int.TryParse(Build, out var buildNumber) && buildNumber >= 22000)
            {
                ProductName = ProductName.Replace("Windows 10", "Windows 11");
                Logo = new SvgImageSource(new Uri("ms-appx:///Assets/SVG/Windows/11.svg"));
            }
            else
            {
                Logo = new SvgImageSource(new Uri("ms-appx:///Assets/SVG/Windows/10.svg"));
            }
            GetAllInfo = $"Microsoft {ProductName} {Platform}";

            DisplayVersion = await GetRegistryValueAsync(WindowsPath, "DisplayVersion");
            UBR = await GetRegistryValueAsync(WindowsPath, "UBR");

            Directory.SetCurrentDirectory(@"C:\Windows\System32");
            ExtractLicenseStatus();
        }

        private static async Task<string> GetRegistryValueAsync(string path, string name)
        {
            return await System.Threading.Tasks.Task.Run(() => Registry.GetValue(path, name, "").ToString());
        }

        public static void ExtractLicenseStatus()
        {
            var licenseStatusMap = new Dictionary<string, string>
            {
                { "Licensed", "Licensed" },
                { "Notification", "Unlicensed" },
                { "Initial grace period", "Trial" },
            };

            ShellOutput = PowershellHandler.RunCommand("cscript //nologo slmgr.vbs /dli");
            var match = Regex.Match(ShellOutput, @"License Status:\s*(.*)");
            if (!match.Success) LicenseStatus = "Unlicensed";
            var status = match.Groups[1].Value.Trim();
            LicenseStatus = licenseStatusMap.ContainsKey(status) ? licenseStatusMap[status] : "Unlicensed";
        }

        public static int SetEdition()
        {
            string[] products = { "Home", "Pro", "Education", "Enterprise", "Server" };
            return Array.FindIndex(products, p => ProductName.Contains(p));
        }
    }

    public static class OfficeHandler
    {
        private const string OfficePath_C2R = @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Office\ClickToRun\Configuration";
        public static string Version = Registry.GetValue(OfficePath_C2R, "VersionToReport", "").ToString();
        public static string Platform = Registry.GetValue(OfficePath_C2R, "Platform", "").ToString().Contains("x64") ? "64 bits" : "32 bits";
        public static string ReleaseId = Registry.GetValue(OfficePath_C2R, "ProductReleaseIds", "").ToString();

        /* I don't use: HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\**OFFICE VERSION**
           because it's hard to maintain both x86 & x64 bit builds and rename other Office products, without considering
           that each Office version has its own language */

        public static string ProductName = "Product not found";
        private const string path = "ms-appx:///Assets/SVG/Office";

        public static RenewTask task = new("OfficeRenewer");


        private static Dictionary<string, string> versions = new()
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
        }

        private static Dictionary<string, string> logos = new()
        {
            { "365", $"{path}/365.svg" },
            { "2021", $"{path}/365.svg" },
            { "2019", $"{path}/2021.svg" },
            { "2016", $"{path}/2016.svg" },
            { "2013", $"{path}/2016.svg" }
        };

        public static ImageSource SetLogo()
        {
            foreach (var logo in logos)
            {
                if (ReleaseId.Contains(logo.Key))
                {
                    return new SvgImageSource(new Uri(logo.Value));
                }
            }
            return new SvgImageSource(new Uri(string.Empty));
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
            return licenseStatusMap.TryGetValue(status, out string? value) ? value : "Unlicensed";
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

        private void GetTaskFolder()
        {
            tf = ts.GetFolder(taskFolderName);
        }
    }
}