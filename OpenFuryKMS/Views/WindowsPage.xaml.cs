using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using OpenFuryKMS.ViewModels;

namespace OpenFuryKMS.Views;

public sealed partial class WindowsPage : Page
{
    private string pwshOutput;
    private int defaultOS;

    public WindowsViewModel ViewModel
    {
        get;
    }

    public WindowsPage()
    {
        ViewModel = App.GetService<WindowsViewModel>();
        InitializeComponent();

        Directory.SetCurrentDirectory(@"C:\Windows\System32");

        LoadLanguage();
        GetLicenseStatus();

        ProductCombo.SelectedIndex = WindowsHandler.SetEdition();
        defaultOS = ProductCombo.SelectedIndex;
        ServerCombo.ItemsSource = KMSHandler.KmsServers;
    }

    private void ComboBoxHandler()
    {

    }

    private void LoadLanguage()
    {
        ProductName.Text = WindowsHandler.GetAllInfo;
        Version.Text = WindowsHandler.Version;

    }

    private void GetLicenseStatus()
    {
        pwshOutput = PowershellHandler.RunCommand("cscript //nologo slmgr.vbs /dli");
        string licenseStatus = WindowsHandler.ExtractLicenseStatus(pwshOutput);
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

    private void ProductCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        switch (ProductCombo.SelectedIndex)
        {
            case 0:
                LicenseCombo.ItemsSource = WindowsHandler.Home_Licenses.Select(x => x.License + x.Description).ToList();
                break;

            case 1:
                LicenseCombo.ItemsSource = WindowsHandler.Pro_Licenses.Select(x => x.License + x.Description).ToList();
                break;

            case 2:
                LicenseCombo.ItemsSource = WindowsHandler.Education_Licenses.Select(x => x.License + x.Description).ToList();
                break;

            case 3:
                LicenseCombo.ItemsSource = WindowsHandler.Enterprise_Licenses.Select(x => x.License + x.Description).ToList();
                break;
        }
        LicenseCombo.SelectedIndex = -1;
    }

    private void InfoButton_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        ShellBox.Text = PowershellHandler.RunCommand("cscript //nologo slmgr.vbs /dli; cscript //nologo slmgr.vbs /xpr");
    }

    private void ActivateButton_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        if (MethodCombo.SelectedIndex == 0 && LicenseCombo.SelectedIndex != -1)
        {
            string selectedLicense = LicenseCombo.SelectedItem.ToString();
            string licenseKey = selectedLicense.Split(' ')[0];
            ShellBox.Text = PowershellHandler.RunCommand($"cscript //nologo slmgr.vbs /ipk {licenseKey}");
            ShellBox.Text = ServerCombo.SelectedIndex == 0
            ? KMSHandler.AutoKMS(windows: true)
            : PowershellHandler.RunCommand($"cscript //nologo slmgr.vbs /skms {KMSHandler.KmsServers[ServerCombo.SelectedIndex - 1]}; cscript //nologo slmgr.vbs /ato");
        }
        else if (MethodCombo.SelectedIndex == 1 || MethodCombo.SelectedIndex == 2)
        {
            string command = MethodCombo.SelectedIndex == 1 ? "/ato" : "/rearm";
            ShellBox.Text = PowershellHandler.RunCommand($"cscript //nologo slmgr.vbs {command}");
        }

        GetLicenseStatus();
    }

    private void RemoveButton_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        ShellBox.Text = PowershellHandler.RunCommand("cscript //nologo slmgr.vbs /upk; cscript //nologo slmgr.vbs /cpky; cscript //nologo slmgr.vbs /ckms");
        GetLicenseStatus();
    }

    private void MethodCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        LicenseCombo.SelectedIndex = -1;
        ServerCombo.SelectedIndex = -1;
        ProductCombo.SelectedIndex = defaultOS;

        bool isKmsSelected = MethodCombo.SelectedIndex == 0;

        ProductsCard.Visibility = isKmsSelected
            ? Microsoft.UI.Xaml.Visibility.Visible
            : Microsoft.UI.Xaml.Visibility.Collapsed;
        ServerCard.Visibility = isKmsSelected
            ? Microsoft.UI.Xaml.Visibility.Visible
            : Microsoft.UI.Xaml.Visibility.Collapsed;
        LicensesCard.Visibility = isKmsSelected
            ? Microsoft.UI.Xaml.Visibility.Visible
            : Microsoft.UI.Xaml.Visibility.Collapsed;

        ActivateButton.IsEnabled = !isKmsSelected;
    }

    private void UpdateActivateButtonState()
    {
        ActivateButton.IsEnabled = ServerCombo.SelectedIndex != -1 && LicenseCombo.SelectedIndex != -1;
    }

    private void ServerCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        UpdateActivateButtonState();
    }

    private void LicenseCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        UpdateActivateButtonState();
    }
}