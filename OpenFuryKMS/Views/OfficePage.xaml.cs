using Microsoft.UI;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using OpenFuryKMS.ViewModels;

namespace OpenFuryKMS.Views;

public sealed partial class OfficePage : Page
{
    private int defaultVersion;
    private string dirtyOutput;
    private string pwshOutput;

    OfficeHandler officeHandler = new OfficeHandler();
    public OfficeViewModel ViewModel
    {
        get;
    }

    public OfficePage()
    {
        ViewModel = App.GetService<OfficeViewModel>();
        InitializeComponent();

        ProductName.Text = $"{officeHandler.ProductName} {officeHandler.GetPlatform()}";
        Version.Text = officeHandler.Version;

        ProductCombo.SelectedIndex = officeHandler.SetVersion();
        defaultVersion = ProductCombo.SelectedIndex;
        ServerCombo.ItemsSource = KMSHandler.KmsServers;
        GetLicenseStatus();
    }

    private void GetLicenseStatus()
    {
        pwshOutput = PowershellHandler.RunCommand("cscript //nologo ospp.vbs /dstatus");
        string licenseStatus = officeHandler.ExtractLicenseStatus(pwshOutput);
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

    private void Activation()
    {
        if (officeHandler.productLicenses.ContainsKey(ProductCombo.SelectedIndex))
        {
            var productInfo = officeHandler.productLicenses[ProductCombo.SelectedIndex];

            if (!string.IsNullOrEmpty(productInfo.productKey))
            {
                dirtyOutput = officeHandler.InstallLicense(productInfo.productKey, productInfo.keys, productInfo.license);
            }
            else
            {
                dirtyOutput = PowershellHandler.RunCommand($"cscript //nologo ospp.vbs /inpkey:{productInfo.license}");
            }

            ShellBox.Text = officeHandler.ClearOutput(PowershellHandler.RunCommand(dirtyOutput));
            //SetKMS_Server();
        }
    }

    private void ActivateButton_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        if (MethodCombo.SelectedIndex == 0)
        {
            Activation();
        }
        else if (MethodCombo.SelectedIndex == 1 || MethodCombo.SelectedIndex == 2)
        {
            string command = MethodCombo.SelectedIndex == 1 ? "/act" : "/rearm";
            dirtyOutput = PowershellHandler.RunCommand($"cscript //nologo ospp.vbs {command}");
        }
        ShellBox.Text = officeHandler.ClearOutput(dirtyOutput);
        GetLicenseStatus();
    }

    private void InfoButton_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        ShellBox.Text = officeHandler.ClearOutput(PowershellHandler.RunCommand("cscript //nologo ospp.vbs /dstatus"));
    }

    private void RemoveButton_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        var matchingLicense = officeHandler.productLicenses
            .FirstOrDefault(officeKey => officeKey.Value.keys.Any(key => officeHandler.ReleaseId.Contains(key)));

        if (!string.IsNullOrEmpty(matchingLicense.Value.license))
        {
            dirtyOutput = PowershellHandler.RunCommand($"cscript //nologo ospp.vbs /unpkey:{matchingLicense.Value.license}");
            ShellBox.Text = officeHandler.ClearOutput(dirtyOutput);
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