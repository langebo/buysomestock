using System.Threading;
using System.Threading.Tasks;
using Shared;

namespace Ordering
{
    public interface IMailingService
    {
        Task SendOrderConfirmationAsync(Order order, CancellationToken cancellationToken);
    }
}