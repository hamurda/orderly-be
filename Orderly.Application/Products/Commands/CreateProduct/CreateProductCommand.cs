using MediatR;

namespace Orderly.Application.Products.Commands.CreateProduct;

public class CreateProductCommand : IRequest<int> //<int> is the return type of the request
{
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public decimal Price { get; set; } = 0;
}
