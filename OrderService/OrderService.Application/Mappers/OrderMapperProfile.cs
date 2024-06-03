using AutoMapper;
using EquipmentService.Application;

namespace OrderService.Application.Mappers;

public class OrderMapperProfile : Profile
{
    public OrderMapperProfile()
    {
        CreateMap<AddEquipmentRequest, AddEquipmentRequest>().ReverseMap();
        CreateMap<EquipmentResponse, AddEquipmentRequest>().ReverseMap();
    }
}