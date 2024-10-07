using Microsoft.UI.Xaml.Controls;

using OpenFuryKMS.ViewModels;

namespace OpenFuryKMS.Views;

public sealed partial class MainPage : Page
{
    public MainViewModel ViewModel
    {
        get;
    }

    public MainPage()
    {
        ViewModel = App.GetService<MainViewModel>();
        InitializeComponent();
    }
}
