using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Orderly.Domain.Entities;
using Orderly.Domain.Exceptions;
using Orderly.Domain.Repositories;

namespace Orderly.Application.Products.Commands.DeleteProduct;

public class DeleteProductCommandHandler(ILogger<DeleteProductCommandHandler> logger,
    IProductRepository productRepository) : IRequestHandler<DeleteProductCommand>
{
    public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Deleting product with id: {@ProductId}", request.Id);
        var product = await productRepository.GetByIdAsync(request.Id);
        if (product is null) {
            throw new NotFoundException(nameof(Product), request.Id.ToString());
        } 

        await productRepository.Delete(product);

    }
}
