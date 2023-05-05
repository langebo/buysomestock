using MassTransit;
using Shared;

namespace Store;

public class OrderEventService : IOrderEventService
{
    private readonly IBus _bus;
    private readonly ILogger _logger;

    public OrderEventService(IBus bus, ILogger<OrderEventService> logger)
    {
        _bus = bus;
        _logger = logger;
    }

    public async Task PublishOrderAsync(Order order, CancellationToken cancellationToken = default)
    {
        var orderCreated = new OrderCreated();
        orderCreated.Order = order;
        orderCreated.Timestamp = DateTime.UtcNow;
        await _bus.Publish(orderCreated, cancellationToken);
    }
}