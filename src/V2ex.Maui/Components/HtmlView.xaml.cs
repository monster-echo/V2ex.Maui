using System.Windows.Input;
using V2ex.Maui.Services;

namespace V2ex.Maui.Components;

public partial class HtmlView : ContentView
{
    private bool _isHtml;
    public HtmlView()
    {
        InitializeComponent();
    }

    public static readonly BindableProperty TextProperty = BindableProperty.Create(
        nameof(Text),
        typeof(string),
        typeof(HtmlView), propertyChanged: TextChanged, propertyChanging: TextChanging);



    public ICommand TapCommand
    {
        get { return (ICommand)GetValue(TapCommandProperty); }
        set { SetValue(TapCommandProperty, value); }
    }

    public static readonly BindableProperty TapCommandProperty =
        BindableProperty.Create(nameof(TapCommand), typeof(ICommand), typeof(HtmlView));

    private static void TextChanging(BindableObject bindable, object oldValue, object newValue)
    {
        if(bindable is not HtmlView htmlView)
        {
            return;
        }

        htmlView.IsHtml = CheckIsHtml(newValue?.ToString());
    }

    private static void TextChanged(BindableObject bindable, object oldValue, object newValue)
    {

    }

    public event EventHandler<string>? UrlTapped;

    public string? Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    private static bool CheckIsHtml(string? value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return false;
        }

        if (value.Contains("<html") || value.Contains("<div") || value.Contains("<p") || value.Contains("<pre")
            || value.Contains("<a"))
        {
            return true;
        }

        return false;
    }

    public bool IsHtml
    {
        get
        {
            return _isHtml;
        }
        set
        {
            if (value == _isHtml)
            {
                return;
            }
            _isHtml = value;
            OnPropertyChanged();
        }
    }

    public ResourcesService? ResourcesService { get; }

    private void WebView_Navigated(object sender, WebNavigatedEventArgs e)
    {

    }

    private void WebView_Navigating(object sender, WebNavigatingEventArgs e)
    {
        var url = e.Url;
        if (TapCommand != null && TapCommand.CanExecute(url))
        {
            TapCommand.Execute(url);
        }
        this.UrlTapped?.Invoke(this, url);
        e.Cancel = true;
    }

    private void WebView_Loaded(object sender, EventArgs e)
    {
    }
}