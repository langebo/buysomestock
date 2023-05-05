namespace Shared;

public class OrderCreated
{
    public DateTime Timestamp { get; set; }
    public Order Order { get; set; } = default!;
}
