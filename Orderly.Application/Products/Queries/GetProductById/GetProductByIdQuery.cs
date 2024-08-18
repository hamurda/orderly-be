using MediatR;
using Orderly.Application.Products.DTOs;

namespace Orderly.Application.Products.Queries.GetProductById;

public class GetProductByIdQuery(int id) : IRequest<ProductDTO>
{
    public int Id { get; } = id;
}
