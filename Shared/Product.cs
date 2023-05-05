namespace Shared;

public class Product
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Isin { get; set; } = string.Empty;
    public decimal Price { get; set; }
}