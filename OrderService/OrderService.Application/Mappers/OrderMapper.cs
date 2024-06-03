using AutoMapper;
using EquipmentService.Application.Mappers;

namespace OrderService.Application.Mappers;

public class OrderMapper
{
    private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
            cfg.AddProfile<EquipmentMapperProfile>();
        });
        var mapper = config.CreateMapper();
        return mapper;
    });

    public static IMapper Mapper => Lazy.Value;
}