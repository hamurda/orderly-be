using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Orderly.Application.Products.DTOs;
using Orderly.Domain.Entities;
using Orderly.Domain.Exceptions;
using Orderly.Domain.Repositories;

namespace Orderly.Application.Products.Commands.UpdateProduct;

public class UpdateProductCommandHandler(ILogger<UpdateProductCommandHandler> logger,
    IMapper mapper,
    IProductRepository productRepository) : IRequestHandler<UpdateProductCommand>
{
    public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Updated the product: {@ProductId} with {@UpdatedProduct}", request.Id, request);

        var product = await productRepository.GetByIdAsync(request.Id);
        if (product is null)
        {
            throw new NotFoundException(nameof(Product), request.Id.ToString());
        }

        mapper.Map(request, product);

        await productRepository.UpdateAsync(product);
    }
}
