using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Language;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Shapes;


namespace OpenFuryKMS
{
    public class PowershellHandler
    {
        public readonly List<string> KmsServers = new List<string>
        {
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

        public string ExecuteCommand(string cmd)
        {
            using (var pwsh = PowerShell.Create())
            {
                pwsh.AddScript(cmd);
                var result = pwsh.Invoke();
                return string.Join(Environment.NewLine, result.Select(o => o.ToString()));
            }
        }

        public string AutoKMS(bool windows = false, bool office = false)
        {
            foreach (var server in KmsServers)
            {
                var setKms = windows ? $"cscript //nologo slmgr.vbs /skms {server} 2>&1" :
                              office ? $"cscript //nologo ospp.vbs /sethst:{server} 2>&1" : string.Empty;

                var activate = windows ? "cscript //nologo slmgr.vbs /ato" :
                                office ? "cscript //nologo ospp.vbs /act" : string.Empty;

                var result = ExecuteCommand($"{setKms}; {activate}");

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
        private static string Platform = Environment.Is64BitOperatingSystem ? " 64 bits" : " 32 bits";
        private static string UBR = Registry.GetValue(WindowsPath, "UBR", "").ToString();
        private string EditionID = Registry.GetValue(WindowsPath, "EditionID", "").ToString();
        private string Organization = Registry.GetValue(WindowsPath, "RegisteredOrganization", "").ToString();
        private string Owner = Registry.GetValue(WindowsPath, "RegisteredOwner", "").ToString();

        public string Version = $"{DisplayVersion} ({Build}.{UBR})";
        public string GetMinimalInfo = $"{ProductName} {DisplayVersion} {Platform}";
        public string GetAllInfo = $"Microsoft {ProductName}{Platform}";

        public readonly List<(string License, string Description)> Home_Licenses = new List<(string, string)>
        {
            ("TX9XD-98N7V-6WMQ6-BX7FG-H8Q99", ""),
            ("3KHY7-WNT83-DGQKR-F7HPR-844BM", " (N)"),
            ("7HNRX-D7KGG-3K4RQ-4WPJ4-YTDFH", " (Single Language)"),
            ("PVMJN-6DFY6-9CCP6-7BKTT-D3WVR", " (Country Specific)")
        };

        public readonly List<(string License, string Description)> Pro_Licenses = new List<(string, string)>
        {
            ("W269N-WFGWX-YVC9B-4J6C9-T83GX", ""),
            ("MH37W-N47XK-V7XM9-C7227-GCQG9", " (N)")
        };

        public readonly List<(string License, string Description)> Education_Licenses = new List<(string, string)>
        {
            ("NW6C2-QMPVW-D7KKK-3GKT6-VCFB2", ""),
            ("2WH4N-8QGBV-H22JP-CT43Q-MDWWJ", " (N)")
        };

        public readonly List<(string License, string Description)> Enterprise_Licenses = new List<(string, string)>
        {
            ("NPPR9-FWDCX-D2C8J-H872K-2YT43", ""),
            ("DPH2V-TTNVB-4X9Q3-TJR4H-KHJW4", " (N)")
        };

        public WindowsHandler()
        {
            if (int.TryParse(Build, out var buildNumber) && buildNumber >= 22000)
            {
                ProductName = ProductName.Replace("Windows 10", "Windows 11");
            }
        }
    }

    public class OfficeHandler
    {
        private static string OfficePath_C2R = @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Office\ClickToRun\Configuration";
        public string Version = Registry.GetValue(OfficePath_C2R, "VersionToReport", "").ToString();
        public string Platform = Registry.GetValue(OfficePath_C2R, "Platform", "").ToString();
        public string ReleaseId = Registry.GetValue(OfficePath_C2R, "ProductReleaseIds", "").ToString();

        private static string FullName_Path = @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\ProPlus2021Retail - es-es";
        public string ProductName = Registry.GetValue(FullName_Path, "DisplayName", "").ToString();

        public bool DirChecker()
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

        public string GetLicenseType()
        {
            return ReleaseId.EndsWith("Retail") ? "Retail" : ReleaseId.EndsWith("Volume") ? "Volume" : "";
        }

        public string GetProductName()
        {
            return ProductName.Split('-')[0];
        }

        public string GetPlatform()
        {
            return Platform.Contains("x64") ? "64 bits" : "32 bits";
        }

        public string ExtractLicenseStatus(string output)
        {
            var licenseStatusMap = new Dictionary<string, string>
            {
                {"---LICENSED---", "Licensed"},
                {"---NOTIFICATIONS---", "Unlicensed"},
                {"---OOB_GRACE---", "Unlicensed"}
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

            output = lastKeys.Aggregate(output, (current, lastKey) => current + $"cscript //nologo ospp.vbs /unpkey:{lastKey} >nul; ");

            output += $"cscript //nologo ospp.vbs /inpkey:{licenseKey}";
            return output;
        }
    }
}