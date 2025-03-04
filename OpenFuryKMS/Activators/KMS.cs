using Microsoft.Win32;
using OpenFuryKMS;
using System.Management;


public static class SLGMR
{

}

public static class OnlineKMS
{
    // abbodi1406's code rewritten in C#
    private static string winID = string.Empty;

    private const string SPPk = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\SoftwareProtectionPlatform";
    private const string OPPk = @"SOFTWARE\Microsoft\OfficeSoftwareProtectionPlatform";
    private const string wApp = "55c92734-d682-4d71-983e-d6ec3f16059";
    private const string oApp = "0ff1ce15-a989-479d-af46-f275c6370663";

    public static bool CheckPerm()
    {
        foreach (ManagementObject service in new ManagementObjectSearcher(@"SELECT Name FROM SoftwareLicensingProduct 
                                                                                    WHERE LicenseStatus=1
                                                                                    AND GracePeriodRemaining=0 
                                                                                    AND PartialProductKey IS NOT NULL AND LicenseDependsOn IS NULL").Get())
        {
            if (service["Name"] is string name && !string.IsNullOrEmpty(name))
            {
                return true;
            }
        }

        return false;
    }

    public static void GetID()
    {

        foreach (ManagementObject service in new ManagementObjectSearcher(@"SELECT ID FROM SoftwareLicensingProduct 
                                                                                    WHERE Name like '%windows%'
                                                                                    AND Description like '%KMSCLIENT%' 
                                                                                    AND PartialProductKey IS NOT NULL AND LicenseDependsOn IS NULL").Get())
        {
            if (service["ID"] is string id && !string.IsNullOrEmpty(id))
            {
                winID = id;
            }
        }
    }

    private static async Task<string> Clear()
    {
        try
        {
            using RegistryKey? imfeoKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Image File Execution Options", true);
            using RegistryKey? sppKey64 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(SPPk, true);
            using RegistryKey? sppKey32 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey(SPPk, true);
            using RegistryKey? sppKey = Registry.LocalMachine.OpenSubKey(SPPk, true);
            using RegistryKey? sppUKey = Registry.Users.OpenSubKey($@"S-1-5-20\{SPPk}", true);
            using RegistryKey? oppKey = Registry.LocalMachine.OpenSubKey(OPPk, true);

            void SafeDeleteSubKeyTree(RegistryKey? key, string subKey)
            {
                if (key != null && key.GetSubKeyNames().Contains(subKey))
                    key.DeleteSubKeyTree(subKey);
            }

            void SafeDeleteValue(RegistryKey? key, string valueName)
            {
                if (key != null && key.GetValue(valueName) != null)
                    key.DeleteValue(valueName);
            }

            // Image File Execution Options
            SafeDeleteSubKeyTree(imfeoKey, "sppsvc.exe");
            SafeDeleteSubKeyTree(imfeoKey, "SppExtComObj.exe");

            // Windows
            SafeDeleteValue(sppKey64, "KeyManagementServiceName");
            SafeDeleteValue(sppKey64, "KeyManagementServicePort");
            SafeDeleteValue(sppKey32, "KeyManagementServiceName");
            SafeDeleteValue(sppKey32, "KeyManagementServicePort");
            SafeDeleteValue(sppKey, "DisableDnsPublishing");
            SafeDeleteValue(sppKey, "DisableKeyManagementServiceHostCaching");
            SafeDeleteSubKeyTree(sppKey, wApp);
            SafeDeleteSubKeyTree(sppUKey, wApp);

            // Office
            SafeDeleteSubKeyTree(sppKey64, oApp);
            SafeDeleteSubKeyTree(sppKey32, oApp);
            SafeDeleteSubKeyTree(sppUKey, oApp);
            SafeDeleteValue(oppKey, "KeyManagementServiceName");
            SafeDeleteValue(oppKey, "KeyManagementServicePort");
            SafeDeleteValue(oppKey, "DisableDnsPublishing");
            SafeDeleteValue(oppKey, "DisableKeyManagementServiceHostCaching");
            SafeDeleteSubKeyTree(oppKey, "59a52881-a989-479d-af46-f275c6370663");
            SafeDeleteSubKeyTree(oppKey, oApp);

            return "All reg keys has been deleted";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    public static async Task<string> InstallProductKey(string key)
    {
        await Clear();
        return await Task.Run(() =>
        {
            foreach (ManagementObject service in new ManagementObjectSearcher("SELECT Version FROM SoftwareLicensingService").Get())
            {
                using ManagementBaseObject inParams = service.GetMethodParameters("InstallProductKey");
                inParams["ProductKey"] = key;

                using ManagementBaseObject outParams = service.InvokeMethod("InstallProductKey", inParams, null);
                int returnValue = Convert.ToInt32(outParams["ReturnValue"]);

                return returnValue == 0 ? "Product Key Installed Successfully" : $"Error Code: {returnValue}";
            }
            return "Error: No se encontró SoftwareLicensingService.";
        });
    }

    public static async Task<string> SetKMS(string server)
    {
        return await Task.Run(() =>
        {
            try
            {
                string[] registryViews = Environment.Is64BitOperatingSystem
                    ? new[] { "Registry64", "Registry32" }
                    : new[] { "Registry32" };

                foreach (string view in registryViews)
                {
                    RegistryView registryView = view == "Registry64" ? RegistryView.Registry64 : RegistryView.Registry32;
                    using (RegistryKey kmsKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, registryView).CreateSubKey(SPPk, true))
                    {
                        kmsKey.SetValue("KeyManagementServiceName", server, RegistryValueKind.String);
                        kmsKey.SetValue("KeyManagementServicePort", "1688", RegistryValueKind.String);
                    }
                }

                return "Registry Keys created successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        });
    }

    public static async Task<string> Activate()
    {
        return await Task.Run(() =>
        {
            GetID();
            using (RegistryKey key = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows NT\CurrentVersion\Software Protection Platform", true))
            {
                if (Convert.ToUInt16(WindowsHandler.Build) == 14393)
                {
                    key.SetValue("NoAcquireGT", 1, RegistryValueKind.DWord);
                }
                else
                {
                    key.SetValue("NoGenTicket", 1, RegistryValueKind.DWord);
                }
            }

            foreach (ManagementObject instance in new ManagementObjectSearcher(@$"SELECT ID FROM SoftwareLicensingProduct WHERE ID='{winID}'").Get())
            {
                using ManagementBaseObject outParams = instance.InvokeMethod("Activate", null, null);
                int returnValue = Convert.ToInt32(outParams["ReturnValue"]);

                return returnValue == 0 ? "Windows Activated Successfully" : $"Activation Error: {returnValue}";
            }

            return "Error: No se encontró el producto con la ID especificada.";
        });
    }
    public static async Task<string> RefreshLicenseStatus()
    {
        try
        {
            foreach (ManagementObject service in new ManagementObjectSearcher(@"SELECT * FROM SoftwareLicensingService").Get())
            {
                service.InvokeMethod("RefreshLicenseStatus", null);
            }
            return "License status refreshed successfully";
        }
        catch (Exception ex)
        {
            return "Error refreshing license status: " + ex.Message;
        }
    }

}