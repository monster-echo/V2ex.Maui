namespace V2ex.Blazor.Services;

public interface IShare
{
    Task ShareUrl(string title, string url);
}
