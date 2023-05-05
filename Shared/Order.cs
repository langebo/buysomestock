namespace Shared;

public class Order
{
    public Guid Id { get; set; }
    public Product Product { get; set; } = default!;
    public int Amount { get; set; }
}
