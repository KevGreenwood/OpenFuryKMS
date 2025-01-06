using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

using OpenFuryKMS.ViewModels;

namespace OpenFuryKMS.Views;

public sealed partial class HomePage : Page
{
    public HomeViewModel ViewModel
    {
        get;
    }

    public HomePage()
    {
        ViewModel = App.GetService<HomeViewModel>();
        InitializeComponent();

        if (InternetConnection.result)
        {
            Connection_Header.Description = "You are able activate to Windows and Office via KMS.";
            MainIcon.Glyph = "\uF385";
            AuxIcon.Visibility = Visibility.Visible;
        }
        else
        {
            Connection_Header.Description = "You only can reactivate your license and use the trial license, try again to connect to internet.";
            MainIcon.Glyph = "\uF384";
            AuxIcon.Visibility = Visibility.Collapsed;
        }
        Win_Header.Description = $"{WindowsHandler.ProductName}\n{WindowsHandler.LicenseStatus}";
        Win_Logo.Source = WindowsHandler.LogoPNG;
        Office_Header.Description = $"{OfficeHandler.ProductName}\n{OfficeHandler.LicenseStatus}";
        Office_Logo.Source = OfficeHandler.LogoPNG;
        Adobe_Header.Description = $"{AdobeHandler.Products.Count} Products Installed";
    }
}
