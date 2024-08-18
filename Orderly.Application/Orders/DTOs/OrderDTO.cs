using Orderly.Application.Products.DTOs;
using Orderly.Domain.Entities;

namespace Orderly.Application.Orders.DTOs;

public class OrderDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public string Status { get; set; } = "New";

}
