using Microsoft.UI.Xaml.Controls;
using CommunityToolkit.WinUI.Controls;
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

        string exePath = @"C:\Program Files\Adobe\Adobe Photoshop 2022\Photoshop.exe";

        ShellIconExtractor iconExtractor = new ShellIconExtractor(exePath, 0);
        System.Drawing.Icon icon = iconExtractor.GetIcon(64);

        if (icon != null)
        {
            // Convierte a BitmapImage
            var bitmapImage = AdobeHandler.ConvertIconToBitmapImage(icon);

            // Asigna al control Image
            IconImage.Source = bitmapImage; // IconImage es el nombre de tu control Image en XAML
        }
    }


}
