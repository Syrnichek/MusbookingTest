using AutoMapper;
using EquipmentService.Application;
using OrderService.Application.Commands;
using OrderService.Application.Responses;
using OrderService.Core.Entities;

namespace OrderService.Application.Mappers;

public class OrderMapperProfile : Profile
{
    public OrderMapperProfile()
    {
        CreateMap<AddEquipmentRequest, AddEquipmentRequest>().ReverseMap();
        CreateMap<EquipmentResponse, AddEquipmentRequest>().ReverseMap();
        CreateMap<OrderModel, AddOrderCommand>().ReverseMap();
        CreateMap<OrderModel, OrderResponse>().ReverseMap();
    }
}