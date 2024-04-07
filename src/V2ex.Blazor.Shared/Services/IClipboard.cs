namespace V2ex.Blazor.Services;

public interface IClipboard
{
    Task Copy(string text);
}