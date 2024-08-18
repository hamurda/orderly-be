using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Orderly.Domain.Entities;

public class Order
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public decimal Price { get; set; } = 0;
    public string Status { get; set; } = "New";

    public List<ProductOrder> ProductOrders { get; set; } = new List<ProductOrder>();
    public List<Product> Products { get; set;} = new List<Product>();

}
