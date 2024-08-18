using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Orderly.Application.Products.DTOs;
using Orderly.Domain.Entities;
using Orderly.Domain.Repositories;

namespace Orderly.Application.Products.Commands.CreateProduct;

public class CreateProdcutCommandHandler(ILogger<CreateProdcutCommandHandler> logger,
    IMapper mapper,
    IProductRepository productRepository) : IRequestHandler<CreateProductCommand, int>
{
    public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating a new product: {@Product}", request);

        var product = mapper.Map<Product>(request);

        int id = await productRepository.Create(product);
        return id;
    }
}
