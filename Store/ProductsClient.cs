using Shared;

namespace Store;

public class ProductsClient : IProductsClient
{
    private readonly HttpClient _httpClient;
    private readonly ILogger _logger;

    public ProductsClient(HttpClient httpClient, ILogger<ProductsClient> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<IEnumerable<Product>> GetProductsAsync(CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Retrieving prodcts");
        var products = await _httpClient.GetFromJsonAsync<IEnumerable<Product>>("/");
        return products ?? Enumerable.Empty<Product>();
    }
}