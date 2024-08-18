using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Orderly.Domain.Entities;

public class Product
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public decimal Price { get; set; } = 0;

    public List<ProductOrder> ProductOrders { get; set; } = new List<ProductOrder>();
    public List<Order> Orders { get; set; } = new List<Order>();
}
