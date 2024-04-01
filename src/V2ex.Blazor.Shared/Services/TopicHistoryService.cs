namespace V2ex.Blazor.Services;

public record Topic(string Id, string Title, string? UserName,  string?Avatar, string? NodeName, int Replies);

public class TopicHistoryService
{
    private const string TopicHistoryFileName = "topics.json";

    private readonly List<Topic> _history = [];
    private readonly Task _loadTask;
    public TopicHistoryService(IBlobStorage blobStorage)
    {
        this.BlobStorage = blobStorage;
        this._loadTask = this.Load();
    }

    private IBlobStorage BlobStorage { get; }

    private async Task Load()
    {
        _history.AddRange(await BlobStorage.LoadAsync(TopicHistoryFileName, Array.Empty<Topic>()));
    }

    public async Task PushAsync(Topic topic)
    {

        await _loadTask;

        var existTopic = _history.FirstOrDefault(x => x.Id == topic.Id);

        if (existTopic != null)
        {
            _history.Remove(existTopic);
        }

        _history.Insert(0, topic);

        if (_history.Count > 100)
        {
            _history.Remove(_history.Last());
        }
        await BlobStorage.SaveAsync(TopicHistoryFileName, _history);
    }

    public  async Task<IReadOnlyList<Topic>> GetListAsync()
    {
        await _loadTask;
        return _history;
    }
}
