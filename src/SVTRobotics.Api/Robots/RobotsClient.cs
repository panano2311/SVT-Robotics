public interface IRobotsClient
{
    Task<IEnumerable<Robot>> GetAsync(CancellationToken cancellation);
}

public class RobotsClient : IRobotsClient
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<RobotsClient> _logger;

    public RobotsClient(HttpClient httpClient, ILogger<RobotsClient> logger)
	{
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<IEnumerable<Robot>> GetAsync(CancellationToken cancellation)
    {
        try
        {
            var robots = await _httpClient.GetFromJsonAsync<List<Robot>>("robots", cancellation);
            return robots ?? Enumerable.Empty<Robot>();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to get robots from API");
            throw new Exception("Unable to load robots");
        }
    }
}
