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
        public string ExecuteCommand(string cmd)
        {
            using (PowerShell pwsh = PowerShell.Create())
            {
                pwsh.AddScript(cmd);
                var result = pwsh.Invoke();
                string output = string.Join(Environment.NewLine, result.Select(o => o.ToString()));
                return output;
            }
        }

        public string AutoKMS(bool Windows = false, bool Office = false)
        {
            var KMS_Servers = new List<string> { "kms.chinancce.com", "kms.digiboy.ir", "kms.ddns.net", "xykz.f3322.org", "dimanyakms.sytes.net", "kms.03k.org", "ms8.us.to", "s8.uk.to", "s9.us.to", "kms9.msguides.com", "kms8.msguides.com", "kms7.msguides.com" };
            bool ActivationSuccessful = false;
            string result = "";

            foreach (string Server in KMS_Servers)
            {
                if (!ActivationSuccessful)
                {
                    string SetKMS = "";
                    string Activate = "";

                    if (Windows == true)
                    {
                        SetKMS = $"cscript //nologo slmgr.vbs /skms {Server} 2>&1";
                        Activate = "cscript //nologo slmgr.vbs /ato";
                    }
                    if (Office == true)
                    {
                        SetKMS = $"cscript //nologo ospp.vbs /sethst:{Server} 2>&1";
                        Activate = "cscript //nologo ospp.vbs /act";
                    }

                    result = ExecuteCommand($"{SetKMS}; {Activate}");

                    if (result.Contains("successful"))
                    {
                        ActivationSuccessful = true;
                        break;
                    }
                    else
                    {
                        result = "The connection to KMS Servers failed! Please try again and make sure you have an internet connection.";
                    }
                }
                else
                {
                    break;
                }
            }
            return result;
        }
    }

    public class WindowsHandler
    {
        private static string WindowsPath = @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion";
        private string ProductName = Registry.GetValue(WindowsPath, "ProductName", "").ToString();
        private static string DisplayVersion = Registry.GetValue(WindowsPath, "DisplayVersion", "").ToString();
        private static string Build = Registry.GetValue(WindowsPath, "CurrentBuildNumber", "").ToString();
        private string Platform = Environment.Is64BitOperatingSystem ? " 64 bits" : " 32 bits";
        private static string UBR = Registry.GetValue(WindowsPath, "UBR", "").ToString();
        private string EditionID = Registry.GetValue(WindowsPath, "EditionID", "").ToString();
        private string Organization = Registry.GetValue(WindowsPath, "RegisteredOrganization", "").ToString();
        private string Owner = Registry.GetValue(WindowsPath, "RegisteredOwner", "").ToString();

        public string Version = DisplayVersion + " (" + Build + "." + UBR + ") ";

        public void Windows11_Fix()
        {
            if (Convert.ToInt32(Build) >= 22000)
            {
                ProductName = ProductName.Replace("Windows 10", "Windows 11");
            }
        }

        public string GetMinimalInfo()
        {
            Windows11_Fix();
            string MinimalInfo = ProductName + " " + DisplayVersion + " " + Platform;
            return MinimalInfo;
        }
        public string GetAllInfo()
        {
            Windows11_Fix();
            string WholeInfo = "Microsoft " + ProductName + Platform;
            return WholeInfo;
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
            bool IsInstalled = false;
            string[] OfficePaths =
            {
                @"C:\Program Files\Microsoft Office\Office16",
                @"C:\Program Files\Microsoft Office\Office15",
                @"C:\Program Files (x86)\Microsoft Office\Office16",
                @"C:\Program Files (x86)\Microsoft Office\Office15"
            };

            foreach (string OfficePath in OfficePaths)
            {
                if (Directory.Exists(OfficePath))
                {
                    Directory.SetCurrentDirectory(OfficePath);
                    IsInstalled = true;
                    break;
                }
            }
            return IsInstalled;
        }
        public string GetLicenseType()
        {
            string LicenseType = "";

            if (ReleaseId.EndsWith("Retail"))
            {
                LicenseType = "Retail";
            }
            else if (ReleaseId.EndsWith("Volume"))
            {
                LicenseType = "Volume";
            }
            return LicenseType;
        }
        public string GetProductName()
        {
            string[] FullName = ProductName.Split('-');
            string FinalName = FullName[0];
            return FinalName;
        }
        public string GetPlatform()
        {
            string FinalPlatform = "";

            if (Platform.Contains("x64"))
            {
                return FinalPlatform = "64 bits";
            }
            else
            {
                return FinalPlatform = "32 bits";
            }
        }

        public string ExtractLicenseStatus(string output)
        {
            string Status = "Unlicensed";
            var match = Regex.Match(output, @"LICENSE STATUS:\s*(.*)");
            if (match.Success)
            {
                Status = match.Groups[1].Value.Trim();
                Status = Status.Replace("---LICENSED---", "Licensed");
                Status = Status.Replace("---NOTIFICATIONS---", "Unlicensed");
            }
            return Status;
        }


        public string ClearOutput(string output)
        {
            var Lines = output.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            var CleanedLines = Lines.Where(line => !line.Contains("---Processing--------------------------") && !line.Contains("---Exiting-----------------------------") && !line.Contains("---------------------------------------"));
            return string.Join(Environment.NewLine, CleanedLines);
        }

        public string InstallLicense(string Product, List<string> LastKeys, string LicenseKey)
        {
            string output = $"cmd /c \"for /f %x in ('dir /b ..\\root\\Licenses16\\{Product}*.xrm-ms') do cscript //nologo ospp.vbs /inslic:..\\root\\Licenses16\\%x\"; cscript //nologo ospp.vbs /setprt:1688; ";

            foreach (string LastKey in LastKeys)
            {
                output += $"cscript //nologo ospp.vbs /unpkey:{LastKey} >nul; ";
            }

            output += $"cscript //nologo ospp.vbs /inpkey:{LicenseKey}";
            return output;
        }
    }
}