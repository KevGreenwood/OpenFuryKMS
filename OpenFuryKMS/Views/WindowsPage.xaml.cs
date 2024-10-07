using Microsoft.UI.Xaml.Controls;

using OpenFuryKMS.ViewModels;

namespace OpenFuryKMS.Views;

public sealed partial class WindowsPage : Page
{
    public WindowsViewModel ViewModel
    {
        get;
    }

    public WindowsPage()
    {
        ViewModel = App.GetService<WindowsViewModel>();
        InitializeComponent();
    }
}
