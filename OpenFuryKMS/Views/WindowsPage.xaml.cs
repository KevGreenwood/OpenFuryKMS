using Microsoft.UI;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using OpenFuryKMS.ViewModels;
using System.Diagnostics;
using System.Drawing;

namespace OpenFuryKMS.Views;

public sealed partial class WindowsPage : Page
{
    public string pwshOutput;
    WindowsHandler windowsHandler = new WindowsHandler();

    public WindowsViewModel ViewModel
    {
        get;
    }

    public WindowsPage()
    {
        ViewModel = App.GetService<WindowsViewModel>();
        InitializeComponent();

        ActivateButton.IsEnabled = false;
        RemoveButton.IsEnabled = false;
        Directory.SetCurrentDirectory(@"C:\Windows\System32");

        string[] products = { "Home", "Pro", "Education", "Enterprise" };
        ProductCombo.SelectedIndex = Array.FindIndex(products, p => WindowsHandler.ProductName.Contains(p));

        LoadLanguage();
        GetLicenseStatus();
        ComboBoxHandler();
    }

    private void ComboBoxHandler()
    {
        var serverListWithAuto = new List<string> { "Auto" };
        serverListWithAuto.AddRange(KMSHandler.KmsServers);
        ServerCombo.ItemsSource = serverListWithAuto;
    }

    private void LoadLanguage()
    {
        ProductName.Text = windowsHandler.GetAllInfo;
        Version.Text = windowsHandler.Version;

    }

    public void GetLicenseStatus()
    {
        pwshOutput = PowershellHandler.RunCommand("cscript //nologo slmgr.vbs /dli");
        string licenseStatus = windowsHandler.ExtractLicenseStatus(pwshOutput);
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

    private void SetKMS_Server()
    {
        ShellBox.Text = ServerCombo.SelectedIndex == 0
            ? KMSHandler.AutoKMS(windows: true)
            : PowershellHandler.RunCommand($"cscript //nologo slmgr.vbs /skms {KMSHandler.KmsServers[ServerCombo.SelectedIndex - 1]}; cscript //nologo slmgr.vbs /ato");
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
            SetKMS_Server();
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

        bool isKmsSelected = MethodCombo.SelectedIndex == 0;

        ServerCard.Visibility = isKmsSelected
            ? Microsoft.UI.Xaml.Visibility.Visible
            : Microsoft.UI.Xaml.Visibility.Collapsed;

        ProductCombo.IsEnabled = isKmsSelected;
        LicenseCombo.IsEnabled = isKmsSelected;
        ActivateButton.IsEnabled = !isKmsSelected;
    }

    private void ServerCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        UpdateActivateButtonState();
    }

    private void UpdateActivateButtonState()
    {
        ActivateButton.IsEnabled = ServerCombo.SelectedIndex != -1 && LicenseCombo.SelectedIndex != -1;
    }

    private void LicenseCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        UpdateActivateButtonState();
    }
}