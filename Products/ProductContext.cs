using Bogus;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace Products;

public class ProductContext : DbContext
{
    public DbSet<Product> Products { get; set; } = default!;

    public ProductContext(DbContextOptions<ProductContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var bogusProducts = new Faker<Product>()
            .RuleFor(x => x.Id, f => Guid.NewGuid())
            .RuleFor(x => x.Isin, f => f.Random.Replace("DE00********"))
            .RuleFor(x => x.Price, f => f.Random.Decimal(10, 1000))
            .RuleFor(x => x.Title, f => f.Company.CompanyName())
            .Generate(30);

        modelBuilder.Entity<Product>()
            .HasData(bogusProducts);
    }
}