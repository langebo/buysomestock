using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.Logging;
using Shared;

namespace Ordering;

public class OrderCreatedHandler : IConsumer<OrderCreated>
{
    private readonly IMailingService _mailingService;
    private readonly ILogger _logger;

    public OrderCreatedHandler(IMailingService mailingService, ILogger<OrderCreatedHandler> logger)
    {
        _mailingService = mailingService;
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<OrderCreated> context)
    {
        throw new System.Exception("Boris ist doof");
        _logger.LogInformation("Reveived OrderCreated message {Message} at {Timestamp}", context.Message, context.Message.Timestamp);
        await _mailingService.SendOrderConfirmationAsync(context.Message.Order, context.CancellationToken);
    }
}
