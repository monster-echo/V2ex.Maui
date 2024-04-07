namespace V2ex.Blazor.Services;

public class NativeClipboard : Services.IClipboard
{
    public Task Copy(string text)
    {
        return Clipboard.Default.SetTextAsync(text);
    }
}
