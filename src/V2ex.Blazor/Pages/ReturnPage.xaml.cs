
namespace V2ex.Blazor.Pages;

public partial class ReturnPage : ContentPage
{
    public ReturnPage(string targetLocation)
    {
        InitializeComponent();
        this.BindingContext = new ReturnPageViewModel(targetLocation);
        RootComponent.Parameters = new Dictionary<string, object?>
        {
            { "Url", targetLocation }
        };
    }

    private void BlazorWebView_UrlLoading(object sender, Microsoft.AspNetCore.Components.WebView.UrlLoadingEventArgs e)
    {
        // todo: add a whitelist to prevent open malicious website
        e.UrlLoadingStrategy = Microsoft.AspNetCore.Components.WebView.UrlLoadingStrategy.OpenInWebView;
    }
}