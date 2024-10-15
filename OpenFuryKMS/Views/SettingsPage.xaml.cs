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


        WindowsToggle.IsOn = WindowsHandler.task.IsTaskScheduled();
        OfficeToggle.IsOn = OfficeHandler.task.IsTaskScheduled();
    }

    private void WindowsToggle_Toggled(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        if (WindowsToggle.IsOn)
        {
            WindowsHandler.task.CreateScheduledTask();
        }
        else
        {
            WindowsHandler.task.DeleteTask();
        }
    }

    private void OfficeToggle_Toggled(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        if (OfficeToggle.IsOn)
        {
            OfficeHandler.task.CreateScheduledTask();
        }
        else
        {
            OfficeHandler.task.DeleteTask();
        }
    }

    private void WindowsRestore_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        WindowsHandler.task.CleanAll();
    }

    private void OfficeRestore_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        OfficeHandler.task.CleanAll();
    }
}
