using Microsoft.UI.Xaml.Controls;

using OpenFuryKMS.ViewModels;

namespace OpenFuryKMS.Views;

public sealed partial class OfficePage : Page
{
    OfficeHandler officeHandler = new OfficeHandler();
    public OfficeViewModel ViewModel
    {
        get;
    }

    public OfficePage()
    {
        ViewModel = App.GetService<OfficeViewModel>();
        InitializeComponent();

        ProductName.Text = $"{officeHandler.ProductName} {officeHandler.GetPlatform()}";
        ProductCombo.SelectedIndex = officeHandler.SetVersion();
    }

    private void ActivateButton_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {

    }

    private void InfoButton_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {

    }

    private void RemoveButton_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {

    }

    private void ServerCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        UpdateActivateButtonState();
    }

    private void MethodCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        ServerCombo.SelectedIndex = -1;

        bool isKmsSelected = MethodCombo.SelectedIndex == 0;

        ServerCard.Visibility = isKmsSelected
            ? Microsoft.UI.Xaml.Visibility.Visible
            : Microsoft.UI.Xaml.Visibility.Collapsed;

        ProductCombo.IsEnabled = isKmsSelected;
        ActivateButton.IsEnabled = !isKmsSelected;
    }

    private void ProductCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

    }

    private void UpdateActivateButtonState()
    {
        ActivateButton.IsEnabled = ServerCombo.SelectedIndex != -1;
    }
}