using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using OpenFuryKMS.ViewModels;

namespace OpenFuryKMS.Views;

public sealed partial class AdobePage : Page
{
    public List<AdobeProduct> Products { get; set; }

    public AdobeViewModel ViewModel
    {
        get;
    }

    public AdobePage()
    {
        ViewModel = App.GetService<AdobeViewModel>();
        InitializeComponent();


        Products = AdobeHandler.Products;

        this.DataContext = this;
    }

    private void ToggleSwitch_Toggled(object sender, RoutedEventArgs e)
    {
        if (sender is ToggleSwitch toggleSwitch && toggleSwitch.DataContext is AdobeProduct product)
        {
            if (toggleSwitch.IsOn)
            {
                BlockFirewall(product);
            }
            else
            {
                UnblockFirewall(product);
            }
        }
    }

    private void BlockFirewall(AdobeProduct product)
    {
        string ruleName = $"{product.Name}";

        PowershellHandler.RunCommand($@"
        netsh advfirewall firewall add rule name=""{ruleName}"" dir=in action=block program=""{product.ExecutablePath}"";
        netsh advfirewall firewall add rule name=""{ruleName}"" dir=out action=block program=""{product.ExecutablePath}""");

        product.IsFirewallBlocked = true;
    }

    private void UnblockFirewall(AdobeProduct product)
    {
        PowershellHandler.RunCommand($@"netsh advfirewall firewall delete rule name = ""{product.Name}""");
        product.IsFirewallBlocked = false;
    }
}
