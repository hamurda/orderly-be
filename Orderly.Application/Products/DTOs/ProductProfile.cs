using AutoMapper;
using Orderly.Domain.Entities;
using Orderly.Application.Products.Commands.CreateProduct;
using Orderly.Application.Products.Commands.UpdateProduct;

namespace Orderly.Application.Products.DTOs;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<CreateProductCommand, Product>();

        CreateMap<Product, ProductDTO>()
            .ForMember(p => p.Orders, opt => opt.MapFrom(src => src.Orders));

        CreateMap<UpdateProductCommand, Product>();
    }
}
