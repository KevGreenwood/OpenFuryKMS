using Microsoft.UI.Xaml.Controls;
using OpenFuryKMS.ViewModels;

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

        Directory.SetCurrentDirectory(@"C:\Windows\System32");

        var products = new[] { "Home", "Pro", "Education", "Enterprise" };
        for (int i = 0; i < products.Length; i++)
        {
            if (WindowsHandler.ProductName.Contains(products[i]))
            {
                ProductCombo.SelectedIndex = i;
                break;
            }
        }
        LoadLanguage();

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
        /*string licenseStatus = WindowsHandler.ExtractLicenseStatus(pwshOutput);
        statusLbl.Text = Language.statusLbl + licenseStatus;
        removeBtn.Enabled = licenseStatus != Language.Unlicensed;*/
    }

    private void SetKMS_Server()
    {
        if (ServerCombo.SelectedIndex == 0)
        {
            ShellBox.Text = KMSHandler.AutoKMS(windows: true);
        }
        else
        {
            string server = KMSHandler.KmsServers[ServerCombo.SelectedIndex - 1];
            ShellBox.Text = PowershellHandler.RunCommand($"cscript //nologo slmgr.vbs /skms {server}; cscript //nologo slmgr.vbs /ato");
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
        switch (MethodCombo.SelectedIndex)
        {
            case 0:
                if (LicenseCombo.SelectedIndex != -1)
                {
                    string selectedLicense = LicenseCombo.SelectedItem.ToString();
                    string licenseKey = selectedLicense.Split(' ')[0];
                    ShellBox.Text = PowershellHandler.RunCommand($"cscript //nologo slmgr.vbs /ipk {licenseKey}");
                    SetKMS_Server();
                }
                break;

            case 1:
            case 2:
                string command = MethodCombo.SelectedIndex == 1 ? "/ato" : "/rearm";
                ShellBox.Text = PowershellHandler.RunCommand($"cscript //nologo slmgr.vbs {command}");
                break;
        }
    }

    private void RemoveButton_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        ShellBox.Text = PowershellHandler.RunCommand("cscript //nologo slmgr.vbs /upk; cscript //nologo slmgr.vbs /cpky; cscript //nologo slmgr.vbs /ckms");
    }

    private void MethodCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (MethodCombo.SelectedIndex == 0)
        {
            ServerCard.Visibility = Microsoft.UI.Xaml.Visibility.Visible;
        }
        else
        {
            ServerCard.Visibility = Microsoft.UI.Xaml.Visibility.Collapsed;
        }
    }
}