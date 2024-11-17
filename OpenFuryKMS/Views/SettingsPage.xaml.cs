using Microsoft.UI.Xaml;
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


        WindowsToggle.IsOn = WindowsHandler.Task.IsTaskScheduled();
        OfficeToggle.IsOn = OfficeHandler.Task.IsTaskScheduled();
    }

    private void WindowsToggle_Toggled(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        if (WindowsToggle.IsOn)
        {
            WindowsHandler.Task.CreateScheduledTask();
        }
        else
        {
            WindowsHandler.Task.DeleteTask();
        }
    }

    private void OfficeToggle_Toggled(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        if (OfficeToggle.IsOn)
        {
            OfficeHandler.Task.CreateScheduledTask();
        }
        else
        {
            OfficeHandler.Task.DeleteTask();
        }
    }

    private void WindowsRestore_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        WindowsHandler.Task.CleanAll();
    }

    private void OfficeRestore_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        OfficeHandler.Task.CleanAll();
    }
}
