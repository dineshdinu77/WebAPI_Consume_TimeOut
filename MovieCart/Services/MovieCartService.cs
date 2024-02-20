using MovieCart.Models;

public class MovieCartService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly string _moviesServiceBaseUrl;

    public MovieCartService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        _httpClientFactory = httpClientFactory;
        _moviesServiceBaseUrl = configuration.GetValue<string>("MoviesServiceBaseUrl");
    }

    public async Task<IEnumerable<Movie>> GetMoviesAsync()
    {
        var cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        try
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"{_moviesServiceBaseUrl}/api/Movies", cancellationTokenSource.Token);

            response.EnsureSuccessStatusCode();

            var movies = await response.Content.ReadFromJsonAsync<IEnumerable<Movie>>(cancellationToken: cancellationTokenSource.Token);
            return movies ?? new List<Movie>();
        }
        catch (TaskCanceledException ex)
        {
            // This will catch both timeouts and manually canceled requests
            if (cancellationTokenSource.IsCancellationRequested)
            {
                throw new TimeoutException("The request to MoviesService timed out.", ex);
            }
            throw; // Re-throw the original TaskCanceledException if it wasn't due to a timeout
        }
    }

}
