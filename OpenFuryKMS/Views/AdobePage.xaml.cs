using Microsoft.UI.Xaml.Controls;

using OpenFuryKMS.ViewModels;

namespace OpenFuryKMS.Views;

public sealed partial class AdobePage : Page
{
    public AdobeViewModel ViewModel
    {
        get;
    }

    public AdobePage()
    {
        ViewModel = App.GetService<AdobeViewModel>();
        InitializeComponent();
    }
}
