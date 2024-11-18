using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

using OpenFuryKMS.ViewModels;
using Windows.System;

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

    private void ThemeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.AddedItems.Count > 0 && e.AddedItems[0] is ComboBoxItem selectedItem)
        {
            if (selectedItem.Tag is string theme && Enum.TryParse(typeof(ElementTheme), theme, out var newTheme))
            {
                ViewModel.SwitchThemeCommand.Execute((ElementTheme)newTheme);
            }
        }
    }


    private async void UpdateButton_Click(object sender, RoutedEventArgs e)
    {
        await Launcher.LaunchUriAsync(new Uri("https://github.com/KevGreenwood/OpenFuryKMS/releases/latest"));
    }
}
