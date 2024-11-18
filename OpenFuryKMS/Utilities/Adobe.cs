using Microsoft.UI.Xaml.Media.Imaging;
using System.Diagnostics;

namespace OpenFuryKMS
{
    public class AdobeProduct
    {
        public string Name { get; set; }
        public string Version { get; set; }
        public string ExecutablePath { get; set; }
        public bool IsFirewallBlocked { get; set; }
        public BitmapImage Icon { get; set; }
    }

    public static class AdobeHandler
    {
        public static List<AdobeProduct> Products = [];

        private static readonly string[] AdobePaths =
        {
            @"C:\Program Files\Adobe",
            @"C:\Program Files (x86)\Adobe"
        };

        private static readonly HashSet<string> ExecutableNames =
        [
            "Photoshop.exe",
            "Illustrator.exe",
            "AfterFX.exe",
            "Premiere.exe",
            "InDesign.exe"
        ];

        private static IEnumerable<string> FindExecutables()
        {
            foreach (var path in AdobePaths)
            {
                if (!Directory.Exists(path)) continue;

                var folders = Directory.EnumerateDirectories(path);
                foreach (var folder in folders)
                {
                    var executables = Directory.EnumerateFiles(folder, "*.exe", SearchOption.AllDirectories)
                                               .Where(file => ExecutableNames.Contains(Path.GetFileName(file)));
                    foreach (var executable in executables)
                    {
                        yield return executable;
                    }
                }
            }
        }

        public static async Task LoadProducts()
        {
            var executables = FindExecutables();

            foreach (var executable in executables)
            {
                FileVersionInfo info = FileVersionInfo.GetVersionInfo(executable);

                var product = new AdobeProduct
                {
                    Name = info.ProductName ?? Path.GetFileNameWithoutExtension(executable),
                    Version = info.ProductVersion ?? "Unknown",
                    ExecutablePath = executable,
                    IsFirewallBlocked = await FirewallRuleExists(info.ProductName ?? Path.GetFileNameWithoutExtension(executable)),
                    Icon = GetLargestIconAsImageSource(executable)
                };

                Products.Add(product);
            }
        }

        private static async Task<bool> FirewallRuleExists(string ruleName)
        {
            return await Task.Run(() =>
            {
                return !PowershellHandler.RunCommand($@"netsh advfirewall firewall show rule name=""{ruleName}""").Contains("Error");
            });
        }

        private static BitmapImage GetLargestIconAsImageSource(string executablePath)
        {
            using (var icon = System.Drawing.Icon.ExtractAssociatedIcon(executablePath))
            {
                if (icon == null)
                    return null;

                using (var bitmap = icon.ToBitmap())
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        bitmap.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
                        memoryStream.Seek(0, SeekOrigin.Begin);

                        var bitmapImage = new BitmapImage();
                        bitmapImage.SetSource(memoryStream.AsRandomAccessStream());
                        return bitmapImage;
                    }
                }
            }
        }

    }
}
