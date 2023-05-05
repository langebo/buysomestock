using Shared;

namespace Store
{
    public interface IProductsClient
    {
        Task<IEnumerable<Product>> GetProductsAsync(CancellationToken cancellationToken = default);
    }
}