
using System.Text.Json;

namespace V2ex.Blazor.Services;

public class BlobStorage: IBlobStorage
{
    public async Task SaveAsync<T>(string fileName, T value)
    {
        var data = JsonSerializer.SerializeToUtf8Bytes(value);
        await File.WriteAllBytesAsync(Path.Combine(FileSystem.Current.AppDataDirectory, fileName), data);
    }

    public async Task<T> LoadAsync<T>(string fileName, T defaultValue)
    {
        try
        {
            var data = await File.ReadAllBytesAsync(Path.Combine(FileSystem.Current.AppDataDirectory, fileName));
            return JsonSerializer.Deserialize<T>(data) ?? defaultValue;
        }
        catch (Exception)
        {
            return defaultValue;
        }
    }
}