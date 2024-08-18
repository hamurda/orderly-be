using Microsoft.EntityFrameworkCore;
using Orderly.Domain.Entities;
using Orderly.Domain.Repositories;
using Orderly.Infrastructure.Persistence;

namespace Orderly.Infrastructure.Repositories;

internal class ProductRepository(OrderlyDbContext orderlyDbContext) : IProductRepository
{
    public async Task<int> Create(Product product)
    {
        orderlyDbContext.Products.Add(product);
        await orderlyDbContext.SaveChangesAsync();
        return product.Id;
    }

    public async Task Delete(Product product)
    {
        orderlyDbContext.Remove(product);
        await orderlyDbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await orderlyDbContext.Products
            .Include(p => p.Orders)
            .ToListAsync();
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
        return await orderlyDbContext.Products
            .Include(p => p.Orders)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<int> UpdateAsync(Product product)
    {
        var updateProduct = await orderlyDbContext.Products.FirstOrDefaultAsync<Product>(p => p.Id == product.Id);
        if (updateProduct != null)
        {
            updateProduct.Name = product.Name;
            updateProduct.Description = product.Description;
            updateProduct.Price = product.Price;
        }

        await orderlyDbContext.SaveChangesAsync();

        return product.Id;
    }
}
