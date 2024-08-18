using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Orderly.Application.Products.DTOs;
using Orderly.Domain.Repositories;

namespace Orderly.Application.Products.Queries.GetAllProducts;

public class GetAllProductsQueryHandler (ILogger<GetAllProductsQueryHandler> logger,
    IMapper mapper,
    IProductRepository productRepository) : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductDTO>>
{
    public async Task<IEnumerable<ProductDTO>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting all products.");
        var products = await productRepository.GetAllAsync();
        var productDTOs = mapper.Map<IEnumerable<ProductDTO>>(products);

        return productDTOs;
    }
}
