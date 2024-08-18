
using Orderly.Application.Orders.DTOs;
using Orderly.Domain.Entities;

namespace Orderly.Application.Products.DTOs;

public class ProductDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public List<OrderDTO?> Orders { get; set; } = [];

}
