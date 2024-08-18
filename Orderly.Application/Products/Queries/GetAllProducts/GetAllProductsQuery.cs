using MediatR;
using Orderly.Application.Orders.DTOs;
using Orderly.Application.Products.DTOs;

namespace Orderly.Application.Products.Queries.GetAllProducts;

public class GetAllProductsQuery :IRequest<IEnumerable<ProductDTO>>
{
}
