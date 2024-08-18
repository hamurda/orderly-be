using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Orderly.Application.Products.DTOs;
using Orderly.Domain.Entities;
using Orderly.Domain.Exceptions;
using Orderly.Domain.Repositories;

namespace Orderly.Application.Products.Queries.GetProductById;

public class GetProductByIdQueryHandler (ILogger<GetProductByIdQueryHandler> logger,
    IMapper mapper,
    IProductRepository productRepository) : IRequestHandler<GetProductByIdQuery, ProductDTO>
{
    public async Task<ProductDTO> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting product {@ProductId}", request.Id);
        var product = await productRepository.GetByIdAsync(request.Id) ??
            throw new NotFoundException(nameof(Product), request.Id.ToString());

        return mapper.Map<ProductDTO>(product);
    }
}
