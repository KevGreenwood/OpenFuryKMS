using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using OpenFuryKMS.ViewModels;

namespace OpenFuryKMS.Views;

public sealed partial class WindowsPage : Page
{
    private int defaultOS;
    private string edition;

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
        GetTaskStatus();

        Logo.Source = WindowsHandler.Logo;
        
        ProductCombo.ItemsSource = WindowsHandler.Products;
        ProductCombo.SelectedIndex = WindowsHandler.ProductIndex;
        defaultOS = ProductCombo.SelectedIndex;
        ServerCombo.ItemsSource = KMSHandler.KmsServers;
        ShellBox.Text = WindowsHandler.ShellOutput;
    }

    private void LoadLanguage()
    {
        ProductName.Text = WindowsHandler.GetAllInfo;
        Version.Text = WindowsHandler.Version;
    }

    private void GetLicenseStatus()
    {
        string licenseStatus = WindowsHandler.LicenseStatus;
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

    private void GetTaskStatus()
    {
        if (!WindowsHandler.Task.IsTaskScheduled())
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

    private void ProductCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        switch (ProductCombo.SelectedIndex)
        {
            case 0:
                LicenseCombo.ItemsSource = WindowsHandler.Home_Licenses.Select(x => x.License + x.Description).ToList();
                EditionCard.Visibility = Visibility.Collapsed;

                break;

            case 1:
                LicenseCombo.ItemsSource = WindowsHandler.Pro_Licenses.Select(x => x.License + x.Description).ToList();
                EditionCard.Visibility = Visibility.Collapsed;

                break;

            case 2:
                LicenseCombo.ItemsSource = WindowsHandler.Education_Licenses.Select(x => x.License + x.Description).ToList();
                EditionCard.Visibility = Visibility.Collapsed;

                break;

            case 3:
                LicenseCombo.ItemsSource = WindowsHandler.Enterprise_Licenses.Select(x => x.License + x.Description).ToList();
                EditionCard.Visibility = Visibility.Collapsed;
                break;

            case 4:
                LicenseCombo.ItemsSource = WindowsHandler.Server_Licenses.Select(x => x.License + x.Description).ToList();
                if (WindowsHandler.ServerEval)
                {
                    EditionCard.Visibility = Visibility.Visible;
                }

                break;
        }
        LicenseCombo.SelectedIndex = -1;
        EditionCombo.SelectedIndex = -1;
    }

    private void InfoButton_Click(object sender, RoutedEventArgs e)
    {
        ShellBox.Text = PowershellHandler.RunCommand("cscript //nologo slmgr.vbs /dli; cscript //nologo slmgr.vbs /xpr");
    }

    private async void ActivateButton_Click(object sender, RoutedEventArgs e)
    {
        if (MethodCombo.SelectedIndex == 0 && LicenseCombo.SelectedIndex != -1)
        {
            string selectedLicense = LicenseCombo.SelectedItem.ToString();
            string licenseKey = selectedLicense.Split(' ')[0];

            if (LicenseCombo.SelectedIndex == 4)
            {
                ShellBox.Text = PowershellHandler.RunCommand($"DISM /online /set-edition:{edition} /productkey:{licenseKey} /accepteula");
            }

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

        WindowsHandler.ExtractLicenseStatus();
        GetLicenseStatus();

        if (MethodCombo.SelectedIndex <= 1)
        {
            if (!WindowsHandler.Task.IsTaskScheduled())
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
                        Content = WindowsHandler.Task.CreateScheduledTask(),
                        CloseButtonText = "OK",
                    };
                    await resultDialog.ShowAsync();
                }
            }
        }

        GetTaskStatus();
    }

    private void RemoveButton_Click(object sender, RoutedEventArgs e)
    {
        ShellBox.Text = PowershellHandler.RunCommand("cscript //nologo slmgr.vbs /upk; cscript //nologo slmgr.vbs /cpky; cscript //nologo slmgr.vbs /ckms");
        WindowsHandler.ExtractLicenseStatus();
        GetLicenseStatus();
    }

    private void MethodCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        LicenseCombo.SelectedIndex = -1;
        ServerCombo.SelectedIndex = -1;
        ProductCombo.SelectedIndex = defaultOS;

        bool isKmsSelected = MethodCombo.SelectedIndex == 0;

        ProductsCard.Visibility = isKmsSelected
            ? Visibility.Visible
            : Visibility.Collapsed;
        ServerCard.Visibility = isKmsSelected
            ? Visibility.Visible
            : Visibility.Collapsed;
        LicensesCard.Visibility = isKmsSelected
            ? Visibility.Visible
            : Visibility.Collapsed;

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

    private void EditionCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        switch (EditionCombo.SelectedIndex)
        {
            case 0:
                edition = "serverstandard";
                LicenseCombo.ItemsSource = WindowsHandler.SDServer_Licenses.Select(x => x.License + x.Description).ToList();
                break;

            case 1:
                edition = "serverdatacenter";
                LicenseCombo.ItemsSource = WindowsHandler.DCServer_Licenses.Select(x => x.License + x.Description).ToList();
                break;
        }
    }
}