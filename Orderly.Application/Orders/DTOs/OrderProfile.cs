using AutoMapper;
using Orderly.Domain.Entities;

namespace Orderly.Application.Orders.DTOs;

public class OrderProfile : Profile
{
    public OrderProfile()
    {
        CreateMap<Order, OrderDTO>();
    }
}
