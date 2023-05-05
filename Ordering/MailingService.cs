using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Shared;

namespace Ordering;

public class MailingService : IMailingService
{
    private readonly ILogger _logger;

    public MailingService(ILogger<MailingService> logger)
    {
        _logger = logger;
    }

    public async Task SendOrderConfirmationAsync(Order order, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Attempting to send confirmation for order '{Order}'", order);
        var smtp = new SmtpClient("127.0.0.1", 1025);
        var content = $"Your order of {order.Amount}x '{order.Product.Isin} {order.Product.Title}' has been confirmed";
        var message = new MailMessage("regu@lator.com", "some@one.com", "Order confirmed", content);
        await smtp.SendMailAsync(message, cancellationToken);
        _logger.LogInformation("Order confirmation for order '{Order}' has been sent", order);
    }
}