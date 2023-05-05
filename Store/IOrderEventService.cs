using Shared;

namespace Store
{
    public interface IOrderEventService
    {
        Task PublishOrderAsync(Order order, CancellationToken cancellationToken = default);
    }
}