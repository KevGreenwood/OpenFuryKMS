using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.Win32;
using System.Text;
using System.Text.RegularExpressions;

namespace OpenFuryKMS
{
    public static class WindowsHandler
    {
        private const string WindowsPath = @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion";

        private static string DisplayVersion { get; set; }
        private static string Build { get; set; }
        private static string UBR { get; set; }
        private static string ProductName { get; set; }
        private static string Platform => Environment.Is64BitOperatingSystem ? "64 bits" : "32 bits";
        public static string Version => $"{DisplayVersion} ({Build}.{UBR})";
        public static string GetMinimalInfo => $"{ProductName} {DisplayVersion} {Platform}";
        public static string GetAllInfo { get; private set; }
        public static string LicenseStatus { get; private set; }
        public static string ShellOutput { get; private set; }
        public static int ProductIndex { get; private set; }
        public static int LicenseIndex { get; private set; }
        public static bool ServerEval => ProductName.Contains("Evaluation") && ProductName.Contains("Server");
        public static ImageSource Logo { get; private set; }
        public static RenewTask Task = new("WindowsRenewer");

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
            ("MH37W-N47XK-V7XM9-C7227-GCQG9", " (N)"),
            ("NRG8B-VKK3Q-CXVCJ-9G2XF-6Q84J", " (Pro for Workstations)"),
            ("9FNHH-K3HBT-3W4TD-6383H-6XYWF", " (Pro for Workstations N)")
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
            ("M7XTQ-FN8P6-TTKYV-9D4CC-J462D", " (LTSC)"),
            ("92NFX-8DJQP-P6BBQ-THF9C-7CG2H", " (N LTSC)"),
        ];
        public static readonly List<(string License, string Description)> SDServer_Licenses =
        [
            ("TVRH6-WHNXV-R9WG3-9XRFY-MY832", " (2025 Standard)"),
            ("VDYBN-27WPP-V4HQT-9VMD4-VMK7H", " (2022 Standard)"),
            ("N69G4-B89J2-4G8F4-WWYCC-J464C", " (2019 Standard)"),
            ("WC2BQ-8NRM3-FDDYY-2BFGV-KHKQY", " (2016 Standard)"),
        ];
        public static readonly List<(string License, string Description)> DCServer_Licenses =
        [
            ("D764K-2NDRG-47T6Q-P8T8W-YP6DF", " (2025 Datacenter)"),
            ("WX4NM-KYWYW-QJJR4-XV3QB-6VM33", " (2022 Datacenter)"),
            ("WMDGN-G9PQG-XVVXX-R3X43-63DFG", " (2019 Datacenter)"),
            ("CB7KF-BWN84-R7R2Y-793K2-8XDDG", " (2016 Datacenter)"),
        ];
        public static readonly List<(string License, string Description)> Server_Licenses = [.. SDServer_Licenses, .. DCServer_Licenses];

        public static readonly string[] Products =
        [
            "Windows Home",
            "Windows Pro",
            "Windows Education",
            "Windows Enterprise",
            "Windows Server",
        ];

        public static async Task InitializeAsync()
        {
            Build = await GetRegistryValueAsync(WindowsPath, "CurrentBuildNumber");
            ProductName = await GetRegistryValueAsync(WindowsPath, "ProductName");
            DisplayVersion = await GetRegistryValueAsync(WindowsPath, "DisplayVersion");
            UBR = await GetRegistryValueAsync(WindowsPath, "UBR");

            if (int.TryParse(Build, out var buildNumber) && buildNumber >= 22000)
            {
                ProductName = ProductName.Replace("Windows 10", "Windows 11");
                Logo = new SvgImageSource(new Uri("ms-appx:///Assets/SVG/Windows/11.svg"));
            }
            else
            {
                Logo = new SvgImageSource(new Uri("ms-appx:///Assets/SVG/Windows/10.svg"));
            }

            string[] products = { "Home", "Pro", "Education", "Enterprise", "Server" };
            ProductIndex = Array.FindIndex(products, p => ProductName.Contains(p));

            string[] SDlicenses = { "2025 Standard", "2022 Standard", "2019 Standard", "2019 Datacenter", "2016 Datacenter" };
            string[] DClicenses = { "2025 Datacenter", "2022 Datacenter", "2019 Datacenter", "2016 Datacenter" };
            if (ProductName.Contains("Standard"))
            {
                LicenseIndex = Array.FindIndex(SDlicenses, p => ProductName.Contains(p));
            }
            else if (ProductName.Contains("Datacenter"))
            {
                LicenseIndex = Array.FindIndex(DClicenses, p => ProductName.Contains(p));
            }

            GetAllInfo = $"Microsoft {ProductName} {Platform}";

            Directory.SetCurrentDirectory(@"C:\Windows\System32");
            ExtractLicenseStatus();
        }

        private static async Task<string> GetRegistryValueAsync(string path, string name) => await System.Threading.Tasks.Task.Run(() => Registry.GetValue(path, name, "").ToString());

        public static void ExtractLicenseStatus()
        {
            var licenseStatusMap = new Dictionary<string, string>
            {
                { "Licensed", "Licensed" },
                { "Notification", "Unlicensed" },
                { "Initial grace period", "Trial" },
            };

            ShellOutput = RemoveNewLine(PowershellHandler.RunCommand("cscript //nologo slmgr.vbs /dli"));
            var match = Regex.Match(ShellOutput, @"License Status:\s*(.*)");
            if (!match.Success) LicenseStatus = "Unlicensed";
            var status = match.Groups[1].Value.Trim();
            LicenseStatus = licenseStatusMap.ContainsKey(status) ? licenseStatusMap[status] : "Unlicensed";
        }

        public static string RemoveNewLine(string output)
        {
            string[] lines = output.Split(['\n'], StringSplitOptions.None);

            int start = 0, end = lines.Length - 1;

            while (start <= end && string.IsNullOrWhiteSpace(lines[start]))
                start++;
            while (end >= start && string.IsNullOrWhiteSpace(lines[end]))
                end--;

            return string.Join("\n", lines[start..(end + 1)]);
        }
    }

    public static class OfficeHandler
    {
        private const string OfficePath_C2R = @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Office\ClickToRun\Configuration";

        public static string Version { get; private set; }
        public static string Platform { get; private set; }
        public static string ReleaseId { get; private set; }
        public static string ShellOutput { get; private set; }
        public static string LicenseStatus { get; private set; }
        public static string ProductName = "Product not found";
        public static int ProductIndex { get; private set; }
        public static ImageSource Logo { get; private set; }
        private const string PathAssets = "ms-appx:///Assets/SVG/Office";
        public static RenewTask Task = new("OfficeRenewer");

        private static Dictionary<string, string> versions = new()
        {
            { "365", "Microsoft 365" },
            { "2021", "Microsoft Office 2021" },
            { "2019", "Microsoft Office 2019" },
            { "2016", "Microsoft Office 2016" },
            { "2013", "Microsoft Office 2013" }
        };
        private static Dictionary<string, string> logos = new()
        {
            { "365", $"{PathAssets}/365.svg" },
            { "2021", $"{PathAssets}/365.svg" },
            { "2019", $"{PathAssets}/2021.svg" },
            { "2016", $"{PathAssets}/2016.svg" },
            { "2013", $"{PathAssets}/2016.svg" }
        };
        public static Dictionary<int, (string productKey, List<string> keys, string license)> productLicenses = new()
        {
            { 0, ("proplusvl_kms", new List<string> { "BTDRB", "KHGM9", "CPQVG" }, "XQNVK-8JYDB-WJ9W3-YJ8YR-WFG99") },
            { 1, ("ProPlus2021VL_KMS", new List<string> { "PG343", "6F7TH" }, "FXYTK-NJJ8C-GB6DW-3DYQT-6F7TH") },
            { 2, ("ProPlus2019VL", new List<string> { "6MWKP" }, "NMMKJ-6RK4F-KMJVX-8D9MJ-6MWKP") },
            { 3, ("proplusvl_kms", new List<string> { "BTDRB", "KHGM9", "CPQVG" }, "XQNVK-8JYDB-WJ9W3-YJ8YR-WFG99") },
            { 4, ("", new List<string>(), "YC7DK-G2NP3-2QQC3-J6H88-GVGXT") }
        };

        public static async Task InitializeAsync()
        {
            if (DirChecker())
            {
                Version = await GetRegistryValueAsync(OfficePath_C2R, "VersionToReport");
                Platform = (await GetRegistryValueAsync(OfficePath_C2R, "Platform")).Contains("x64") ? "64 bits" : "32 bits";
                ReleaseId = await GetRegistryValueAsync(OfficePath_C2R, "ProductReleaseIds");

                /* I don't use: HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\**OFFICE VERSION**
                   because it's hard to maintain both x86 & x64 bit builds and rename other Office products, without considering
                   that each Office version has its own language */

                foreach (var version in versions)
                {
                    if (!ReleaseId.Contains(version.Key)) continue;
                    ProductName = version.Value;
                    logos.TryGetValue(version.Key, out string logoPath);
                    Logo = new SvgImageSource(new Uri(logoPath));
                    break;
                }

                ExtractLicenseStatus();

                ProductIndex = versions.Values.ToList().FindIndex(p => ProductName.Contains(p));
            }
        }

        private static async Task<string> GetRegistryValueAsync(string path, string name) => await System.Threading.Tasks.Task.Run(() => Registry.GetValue(path, name, "").ToString());


        public static bool DirChecker()
        {
            string[] officePaths =
            {
                @"C:\Program Files\Microsoft Office\Office16",
                @"C:\Program Files\Microsoft Office\Office15",
                @"C:\Program Files (x86)\Microsoft Office\Office16",
                @"C:\Program Files (x86)\Microsoft Office\Office15"
            };

            var foundPath = officePaths.FirstOrDefault(Directory.Exists);
            if (foundPath != null)
            {
                Directory.SetCurrentDirectory(foundPath);
                return true;
            }
            return false;
        }

        public static void ExtractLicenseStatus()
        {
            var licenseStatusMap = new Dictionary<string, string>
            {
                {"---LICENSED---", "Licensed"},
                {"---NOTIFICATIONS---", "Unlicensed"},
                {"---OOB_GRACE---", "Trial"}
            };
            ShellOutput = ClearOutput(PowershellHandler.RunCommand("cscript //nologo ospp.vbs /dstatus"));
            var match = Regex.Match(ShellOutput, @"LICENSE STATUS:\s*(.*)");
            if (!match.Success) LicenseStatus = "Unlicensed";
            var status = match.Groups[1].Value.Trim();
            LicenseStatus = licenseStatusMap.TryGetValue(status, out string? value) ? value : "Unlicensed";
        }

        public static string ClearOutput(string output)
        {
            var exclusionPatterns = new[]
            {
                "---Processing--------------------------",
                "---Exiting-----------------------------",
                "---------------------------------------"
            };

            var cleanedLines = output
                .Split([Environment.NewLine], StringSplitOptions.None)
                .Where(line => !exclusionPatterns.Any(pattern => line.Contains(pattern)))
                .ToArray();

            return string.Join(Environment.NewLine, cleanedLines);
        }

        public async static Task<string> InstallLicense(string product, IEnumerable<string> lastKeys, string licenseKey)
        {
            var outputBuilder = new StringBuilder();

            outputBuilder.AppendLine(await ConvertEdition(product));

            outputBuilder.AppendLine(await PowershellHandler.RunCommandAsync("cscript //nologo ospp.vbs /setprt:1688"));

            foreach (string lastKey in lastKeys)
            {
                outputBuilder.AppendLine(await PowershellHandler.RunCommandAsync($"cscript //nologo ospp.vbs /unpkey:{lastKey}"));
            }

            outputBuilder.AppendLine(await PowershellHandler.RunCommandAsync($"cscript //nologo ospp.vbs /inpkey:{licenseKey}"));

            return outputBuilder.ToString();
        }

        private async static Task<string> ConvertEdition(string product)
        {
            if (PowershellHandler.RunCommand("cscript //nologo ospp.vbs /dstatus").Contains("RETAIL"))
            {
                var licenseFiles = Directory.GetFiles(@"..\root\Licenses16", $"{product}*.xrm-ms");
                var outputBuilder = new StringBuilder();

                foreach (string licenseFile in licenseFiles)
                {
                    outputBuilder.AppendLine(await PowershellHandler.RunCommandAsync($"cscript //nologo ospp.vbs /inslic:\"{licenseFile}\""));
                }

                return outputBuilder.ToString();
            }
            else
            {
                return "No conversion needed. Current license is not RETAIL.";
            }
        }
    }
}
