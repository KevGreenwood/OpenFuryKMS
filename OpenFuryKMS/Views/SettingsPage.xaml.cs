using Microsoft.UI.Xaml.Controls;

using OpenFuryKMS.ViewModels;

namespace OpenFuryKMS.Views;

// TODO: Set the URL for your privacy policy by updating SettingsPage_PrivacyTermsLink.NavigateUri in Resources.resw.
public sealed partial class SettingsPage : Page
{
    public SettingsViewModel ViewModel
    {
        get;
    }

    public SettingsPage()
    {
        ViewModel = App.GetService<SettingsViewModel>();
        InitializeComponent();
    }

    private void WindowsToggle_Toggled(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {

    }

    private void OfficeToggle_Toggled(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {

    }
}
