using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using OpenFuryKMS.ViewModels;

namespace OpenFuryKMS.Views;

public sealed partial class OfficePage : Page
{
    private int defaultVersion;
    private string dirtyOutput;
    private string pwshOutput;
    public CreateTask task = new("OfficeRenewer");


    public OfficeViewModel ViewModel
    {
        get;
    }

    public OfficePage()
    {
        ViewModel = App.GetService<OfficeViewModel>();
        InitializeComponent();

        OfficeHandler.DirChecker();

        ProductName.Text = $"{OfficeHandler.ProductName} {OfficeHandler.Platform}";
        Version.Text = OfficeHandler.Version;

        ProductCombo.SelectedIndex = OfficeHandler.SetVersion();
        defaultVersion = ProductCombo.SelectedIndex;
        ServerCombo.ItemsSource = KMSHandler.KmsServers;
        GetLicenseStatus();
        GetTaskStatus();
        Logo.Source = OfficeHandler.SetLogo();
    }

    private void GetTaskStatus()
    {
        if (!task.IsTaskScheduled())
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
        pwshOutput = PowershellHandler.RunCommand("cscript //nologo ospp.vbs /dstatus");
        string licenseStatus = OfficeHandler.ExtractLicenseStatus(pwshOutput);
        LicenseStatus.Text = licenseStatus;
        RemoveButton.IsEnabled = licenseStatus != "Unlicensed";
        if (licenseStatus == "Licensed")
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

    private async void ActivateButton_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        if (MethodCombo.SelectedIndex == 0 && OfficeHandler.productLicenses.ContainsKey(ProductCombo.SelectedIndex))
        {
            var productInfo = OfficeHandler.productLicenses[ProductCombo.SelectedIndex];

            if (!string.IsNullOrEmpty(productInfo.productKey))
            {
                dirtyOutput = OfficeHandler.InstallLicense(productInfo.productKey, productInfo.keys, productInfo.license);
            }
            else
            {
                dirtyOutput = PowershellHandler.RunCommand($"cscript //nologo ospp.vbs /inpkey:{productInfo.license}");
            }

            ShellBox.Text = OfficeHandler.ClearOutput(PowershellHandler.RunCommand(dirtyOutput));

            if (ServerCombo.SelectedIndex == 0)
            {
                dirtyOutput = KMSHandler.AutoKMS(office: true);
            }
            else
            {
                string server = KMSHandler.KmsServers[ServerCombo.SelectedIndex - 1];
                dirtyOutput = PowershellHandler.RunCommand($"cscript //nologo ospp.vbs /sethst:{server}; cscript //nologo ospp.vbs /act");
            }
            ShellBox.Text = OfficeHandler.ClearOutput(dirtyOutput);
        }
        else if (MethodCombo.SelectedIndex == 1 || MethodCombo.SelectedIndex == 2)
        {
            string command = MethodCombo.SelectedIndex == 1 ? "/act" : "/rearm";
            dirtyOutput = PowershellHandler.RunCommand($"cscript //nologo ospp.vbs {command}");
        }

        ShellBox.Text = OfficeHandler.ClearOutput(dirtyOutput);
        GetLicenseStatus();

        if (MethodCombo.SelectedIndex <= 1)
        {
            if (!task.IsTaskScheduled())
            {
                ContentDialog renewTask = new()
                {
                    XamlRoot = this.XamlRoot,
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
                        XamlRoot = this.XamlRoot,
                        Style = Application.Current.Resources["DefaultContentDialogStyle"] as Style,
                        Title = "Product Renew Task",
                        Content = task.CreateScheduledTask(),
                        CloseButtonText = "OK",
                    };
                    await resultDialog.ShowAsync();
                }
            }

            GetTaskStatus();
        }
    }

    private void InfoButton_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        ShellBox.Text = OfficeHandler.ClearOutput(PowershellHandler.RunCommand("cscript //nologo ospp.vbs /dstatus"));
    }

    private void RemoveButton_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        if (OfficeHandler.productLicenses.ContainsKey(OfficeHandler.SetVersion()))
        {
            foreach (var key in OfficeHandler.productLicenses[OfficeHandler.SetVersion()].keys)
            {
                dirtyOutput = PowershellHandler.RunCommand($"cscript //nologo ospp.vbs /unpkey:{key}");
                ShellBox.Text = OfficeHandler.ClearOutput(dirtyOutput);
            }
        }
        GetLicenseStatus();
    }

    private void ServerCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        UpdateActivateButtonState();
    }

    private void MethodCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        ServerCombo.SelectedIndex = -1;
        ProductCombo.SelectedIndex = defaultVersion;

        bool isKmsSelected = MethodCombo.SelectedIndex == 0;

        ProductsCard.Visibility = isKmsSelected
            ? Microsoft.UI.Xaml.Visibility.Visible
            : Microsoft.UI.Xaml.Visibility.Collapsed;
        ServerCard.Visibility = isKmsSelected
            ? Microsoft.UI.Xaml.Visibility.Visible
            : Microsoft.UI.Xaml.Visibility.Collapsed;

        ActivateButton.IsEnabled = !isKmsSelected;
    }

    private void ProductCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

    }

    private void UpdateActivateButtonState()
    {
        ActivateButton.IsEnabled = ServerCombo.SelectedIndex != -1;
    }
}