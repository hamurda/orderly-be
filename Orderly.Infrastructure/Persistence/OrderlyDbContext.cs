using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Orderly.Domain.Entities;

namespace Orderly.Infrastructure.Persistence;

internal class OrderlyDbContext(DbContextOptions<OrderlyDbContext> options) : IdentityDbContext<User>(options)
{
    internal DbSet<Order> Orders { get; set; }
    internal DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Product>()
            .HasMany(p => p.Orders)
            .WithMany(p => p.Products)
            .UsingEntity<ProductOrder>();

        modelBuilder.Entity<Order>()
            .HasMany(o => o.Products)
            .WithMany(o => o.Orders)
            .UsingEntity<ProductOrder>();
    }
}
