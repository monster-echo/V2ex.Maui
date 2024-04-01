namespace V2ex.Blazor.Services;

public interface IBlobStorage
{
    Task SaveAsync<T>(string fileName, T value);
    Task<T> LoadAsync<T>(string fileName, T defaultValue);
}