using Microsoft.UI.Xaml.Controls;
using OpenFuryKMS.ViewModels;
using System;
using System.Diagnostics;

namespace OpenFuryKMS.Views;

public sealed partial class WindowsPage : Page
{
    public string pwshOutput;

    public WindowsViewModel ViewModel
    {
        get;
    }

    public WindowsPage()
    {
        //Directory.SetCurrentDirectory(@"C:\Windows\System32");
        
        ViewModel = App.GetService<WindowsViewModel>();
        InitializeComponent();

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
        ServerCombo.ItemsSource = KMSHandler.KmsServers;
        ProductCombo.ItemsSource = WindowsHandler.Editions;
    }

    private void LoadLanguage()
    {
        WindowsHandler.Windows11Fix();
        ProductName.Text = WindowsHandler.GetAllInfo;
        Version.Text = WindowsHandler.Version;
    
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
        Debug.WriteLine(Directory.GetCurrentDirectory());
    }
}
