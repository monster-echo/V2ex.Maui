namespace V2ex.Blazor.Services;

public class NativeShare : IShare
{
    public Task ShareUrl(string title, string url)
    {
        return Share.Default.RequestAsync(new ShareTextRequest
        {
            Uri = url,
            Title = title
        });
    }
}
