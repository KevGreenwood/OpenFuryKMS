using Microsoft.UI.Xaml.Controls;

using OpenFuryKMS.ViewModels;

namespace OpenFuryKMS.Views;

public sealed partial class OfficePage : Page
{
    public OfficeViewModel ViewModel
    {
        get;
    }

    public OfficePage()
    {
        ViewModel = App.GetService<OfficeViewModel>();
        InitializeComponent();
    }
}
