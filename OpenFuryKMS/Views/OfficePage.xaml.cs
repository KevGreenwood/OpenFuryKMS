using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using OpenFuryKMS.ViewModels;

namespace OpenFuryKMS.Views;

public sealed partial class OfficePage : Page
{
    private int defaultVersion;
    private string dirtyOutput = string.Empty;

    public OfficeViewModel ViewModel
    {
        get;
    }

    public OfficePage()
    {
        ViewModel = App.GetService<OfficeViewModel>();
        InitializeComponent();
        Loaded += OfficePage_Loaded;

        OfficeHandler.DirChecker();
        GetLicenseStatus();
        GetTaskStatus();

        Logo.Source = OfficeHandler.Logo;
        ProductName.Text = $"{OfficeHandler.ProductName} {OfficeHandler.Platform}";
        Version.Text = OfficeHandler.Version;
        ProductCombo.SelectedIndex = OfficeHandler.ProductIndex;
        defaultVersion = ProductCombo.SelectedIndex;
        ServerCombo.ItemsSource = KMSHandler.KmsServers;
        ShellBox.Text = OfficeHandler.ShellOutput;
    }

    private async void OfficePage_Loaded(object sender, RoutedEventArgs e)
    {
        if (OfficeHandler.needAtention)
        {
            ContentDialog dialog = new()
            {
                XamlRoot = XamlRoot,
                Style = Application.Current.Resources["DefaultContentDialogStyle"] as Style,
                Title = "License Conflict Detected",
                Content = "The current version of Microsoft Office installed on your system is not compatible with the existing license key. Please uninstall the conflicting license to proceed.",
                PrimaryButtonText = "OK",
                DefaultButton = ContentDialogButton.Primary
            };

            var result = await dialog.ShowAsync();

            if (result == ContentDialogResult.Primary)
            {
                ShellBox.Text = await OfficeHandler.RemoveAll();
            }
        }
    }

    private void GetTaskStatus()
    {
        if (!OfficeHandler.Task.IsTaskScheduled())
        {
            RenewalStatus.Text = "Not Installed";
            CrossRe.Glyph = "\uF13D";
            CrossRe.Foreground = new SolidColorBrush(Colors.Red);
            CircleRe.Foreground = new SolidColorBrush(Colors.Red);
        }
        else
        {
            RenewalStatus.Text = "Installed";
            CrossRe.Glyph = "\uF13E";
            CrossRe.Foreground = new SolidColorBrush(Colors.Green);
            CircleRe.Foreground = new SolidColorBrush(Colors.Green);
        }
    }

    private void GetLicenseStatus()
    {
        LicenseStatus.Text = OfficeHandler.LicenseStatus;
        RemoveButton.IsEnabled = OfficeHandler.LicenseStatus != "Unlicensed";
        if (OfficeHandler.LicenseStatus == "Licensed")
        {
            CrossLic.Glyph = "\uF13E";
            CrossLic.Foreground = new SolidColorBrush(Colors.Green);
            CircleLic.Foreground = new SolidColorBrush(Colors.Green);
        }
        else
        {
            CrossLic.Glyph = "\uF13D";
            CrossLic.Foreground = new SolidColorBrush(Colors.Red);
            CircleLic.Foreground = new SolidColorBrush(Colors.Red);
        }
    }

    private async void ActivateButton_Click(object sender, RoutedEventArgs e)
    {
        ActivateButton.IsEnabled = false;
        if (MethodCombo.SelectedIndex == 0 && OfficeHandler.productLicenses.ContainsKey(ProductCombo.SelectedIndex))
        {
            var productInfo = OfficeHandler.productLicenses[ProductCombo.SelectedIndex];

            if (!string.IsNullOrEmpty(productInfo.productKey))
            {
                dirtyOutput = await OfficeHandler.InstallLicense(productInfo.productKey, productInfo.keys, productInfo.license);
            }
            else
            {
                dirtyOutput = await PowershellHandler.RunCommandAsync($"cscript //nologo ospp.vbs /inpkey:{productInfo.license}");
            }

            ShellBox.Text = OfficeHandler.ClearOutput(dirtyOutput) + "\n";

            if (ServerCombo.SelectedIndex == 0)
            {
                dirtyOutput = await KMSHandler.AutoKMS(office: true);
            }
            else
            {
                string server = KMSHandler.KmsServers[ServerCombo.SelectedIndex];
                dirtyOutput = await PowershellHandler.RunCommandAsync($"cscript //nologo ospp.vbs /sethst:{server}; cscript //nologo ospp.vbs /act");
            }
            ShellBox.Text += OfficeHandler.ClearOutput(dirtyOutput);
        }
        else if (MethodCombo.SelectedIndex == 1 || MethodCombo.SelectedIndex == 2)
        {
            string command = MethodCombo.SelectedIndex == 1 ? "/act" : "/rearm";
            dirtyOutput = await PowershellHandler.RunCommandAsync($"cscript //nologo ospp.vbs {command}");
            ShellBox.Text = OfficeHandler.ClearOutput(dirtyOutput);

            if (MethodCombo.SelectedIndex == 1 && OfficeHandler.Task.IsTaskScheduled())
            {
                OfficeHandler.Task.RecreateTask();
            }
        }
        OfficeHandler.ExtractLicenseStatus();
        GetLicenseStatus();

        if (MethodCombo.SelectedIndex <= 1)
        {
            if (!OfficeHandler.Task.IsTaskScheduled())
            {
                ContentDialog renewTask = new()
                {
                    XamlRoot = XamlRoot,
                    Style = Application.Current.Resources["DefaultContentDialogStyle"] as Style,
                    Title = "Product Renew Task",
                    Content = "Do you want to create a task that every 180 days will renew your license?",
                    PrimaryButtonText = "Yes",
                    CloseButtonText = "No",
                    DefaultButton = ContentDialogButton.Primary
                };

                var renewTask_r = await renewTask.ShowAsync();

                if (renewTask_r == ContentDialogResult.Primary)
                {
                    ContentDialog resultDialog = new()
                    {
                        XamlRoot = XamlRoot,
                        Style = Application.Current.Resources["DefaultContentDialogStyle"] as Style,
                        Title = "Product Renew Task",
                        Content = OfficeHandler.Task.CreateScheduledTask(),
                        CloseButtonText = "OK",
                    };
                    await resultDialog.ShowAsync();
                }
            }
            else if (OfficeHandler.Task.IsTaskScheduled())
            {
                OfficeHandler.Task.RecreateTask();
            }
        }
        GetTaskStatus();
        ActivateButton.IsEnabled = true;
    }

    private async void InfoButton_Click(object sender, RoutedEventArgs e) => ShellBox.Text = OfficeHandler.ClearOutput(await PowershellHandler.RunCommandAsync("cscript //nologo ospp.vbs /dstatus"));

    private async void RemoveButton_Click(object sender, RoutedEventArgs e)
    {
        if (OfficeHandler.productLicenses.ContainsKey(OfficeHandler.ProductIndex))
        {
            foreach (var key in OfficeHandler.productLicenses[OfficeHandler.ProductIndex].keys)
            {
                dirtyOutput = await PowershellHandler.RunCommandAsync($"cscript //nologo ospp.vbs /unpkey:{key}");
                ShellBox.Text = OfficeHandler.ClearOutput(dirtyOutput);
            }
        }
        OfficeHandler.ExtractLicenseStatus();
        GetLicenseStatus();
    }

    private void ServerCombo_SelectionChanged(object sender, SelectionChangedEventArgs e) => ActivateButton.IsEnabled = ServerCombo.SelectedIndex != -1;

    private void MethodCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        ServerCombo.SelectedIndex = -1;
        ProductCombo.SelectedIndex = defaultVersion;

        bool isKmsSelected = MethodCombo.SelectedIndex == 0;

        ProductsCard.Visibility = isKmsSelected
            ? Visibility.Visible
            : Visibility.Collapsed;
        ServerCard.Visibility = isKmsSelected
            ? Visibility.Visible
            : Visibility.Collapsed;

        ActivateButton.IsEnabled = !isKmsSelected;
    }
}