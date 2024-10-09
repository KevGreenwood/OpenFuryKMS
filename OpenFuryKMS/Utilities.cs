using Microsoft.Win32;
using System.Management.Automation;
using System.Text.RegularExpressions;


namespace OpenFuryKMS
{
    public class PowershellHandler
    {
        public static string RunCommand(string cmd)
        {
            PowerShell ps = PowerShell.Create();
            ps.AddScript(cmd);
            var result = ps.Invoke();
            return string.Join(Environment.NewLine, result.Select(o => o.ToString()));
        }
    }

    public class KMSHandler
    {
        public static List<string> KmsServers = new List<string>
        {
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
        };

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

    public class WindowsHandler
    {
        private static string WindowsPath = @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion";
        public static string ProductName = Registry.GetValue(WindowsPath, "ProductName", "").ToString();
        private static string DisplayVersion = Registry.GetValue(WindowsPath, "DisplayVersion", "").ToString();
        private static string Build = Registry.GetValue(WindowsPath, "CurrentBuildNumber", "").ToString();
        private static string Platform = Environment.Is64BitOperatingSystem ? "64 bits" : "32 bits";
        private static string UBR = Registry.GetValue(WindowsPath, "UBR", "").ToString();
        private string EditionID = Registry.GetValue(WindowsPath, "EditionID", "").ToString();

        public string Version = $"{DisplayVersion} ({Build}.{UBR})";
        public string GetMinimalInfo = $"{ProductName} {DisplayVersion} {Platform}";
        public string GetAllInfo = string.Empty;

        public WindowsHandler()
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

        public static readonly List<(string License, string Description)> Home_Licenses = new()
        {
            ("TX9XD-98N7V-6WMQ6-BX7FG-H8Q99", ""),
            ("3KHY7-WNT83-DGQKR-F7HPR-844BM", " (N)"),
            ("7HNRX-D7KGG-3K4RQ-4WPJ4-YTDFH", " (Single Language)"),
            ("PVMJN-6DFY6-9CCP6-7BKTT-D3WVR", " (Country Specific)")
        };
        public static readonly List<(string License, string Description)> Pro_Licenses = new List<(string, string)>
        {
            ("W269N-WFGWX-YVC9B-4J6C9-T83GX", ""),
            ("MH37W-N47XK-V7XM9-C7227-GCQG9", " (N)")
        };
        public static readonly List<(string License, string Description)> Education_Licenses = new List<(string, string)>
        {
            ("NW6C2-QMPVW-D7KKK-3GKT6-VCFB2", ""),
            ("2WH4N-8QGBV-H22JP-CT43Q-MDWWJ", " (N)")
        };
        public static readonly List<(string License, string Description)> Enterprise_Licenses = new List<(string, string)>
        {
            ("NPPR9-FWDCX-D2C8J-H872K-2YT43", ""),
            ("DPH2V-TTNVB-4X9Q3-TJR4H-KHJW4", " (N)")
        };



        public string ExtractLicenseStatus(string output)
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

    public class OfficeHandler
    {
        private static string OfficePath_C2R = @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Office\ClickToRun\Configuration";
        public static string Version = Registry.GetValue(OfficePath_C2R, "VersionToReport", "").ToString();
        private string Platform = Registry.GetValue(OfficePath_C2R, "Platform", "").ToString();
        private string ReleaseId = Registry.GetValue(OfficePath_C2R, "ProductReleaseIds", "").ToString();

        /* I don't use: HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\**OFFICE VERSION**
           because it's hard to maintain both x86 & x64 bit builds and rename other Office products, without considering
           that each Office version has its own language */

        public string ProductName = string.Empty;

        private Dictionary<string, string> versions = new Dictionary<string, string>
        {
            { "365", "Microsoft 365" },
            { "2021", "Microsoft Office 2021" },
            { "2019", "Microsoft Office 2019" },
            { "2016", "Microsoft Office 2016" },
            { "2013", "Microsoft Office 2013" }
        };

        public OfficeHandler()
        {
            DirChecker();

            foreach (var version in versions)
            {
                if (ReleaseId.Contains(version.Key))
                {
                    ProductName = version.Value;
                    return;
                }
            }
            ProductName = "Microsoft Office";
        }

        private bool DirChecker()
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

        public int SetVersion()
        {
            return versions.Values.ToList().FindIndex(p => ProductName.Contains(p));
        }
        public string GetPlatform()
        {
            return Platform.Contains("x64") ? "64 bits" : "32 bits";
        }

        /*public string GetLicenseType()
        {
            return ReleaseId.EndsWith("Retail") ? "Retail" : ReleaseId.EndsWith("Volume") ? "Volume" : "";
        }*/

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

        public string ClearOutput(string output)
        {
            var lines = output.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            var cleanedLines = lines.Where(line => !line.Contains("---Processing--------------------------") && !line.Contains("---Exiting-----------------------------") && !line.Contains("---------------------------------------"));
            return string.Join(Environment.NewLine, cleanedLines);
        }

        public string InstallLicense(string product, IEnumerable<string> lastKeys, string licenseKey)
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
}