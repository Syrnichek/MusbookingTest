using AutoMapper;
using EquipmentService.Application.Commands;
using EquipmentService.Core.Entities;

namespace EquipmentService.Application.Mappers;

public class EquipmentMapperProfile : Profile
{
    public EquipmentMapperProfile()
    {
        CreateMap<EquipmentModel, EquipmentResponse>().ReverseMap();
        CreateMap<AddEquipmentCommand, EquipmentModel>().ReverseMap();
    }
}