namespace Orderly.Domain.Entities;

public class ProductOrder
{
    public int ProductId { get; set; }
    public Product Product { get; set; } = default!;

    public int OrderId { get; set; }
    public Order Order { get; set; } = default!;
}
