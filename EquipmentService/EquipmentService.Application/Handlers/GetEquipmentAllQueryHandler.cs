using EquipmentService.Core.Repositories;

namespace EquipmentService.Application.Handlers;

public class GetEquipmentAllQueryHandler
{
    private readonly IEquipmentRepository _equipmentRepository;

    public GetEquipmentAllQueryHandler(IEquipmentRepository equipmentRepository)
    {
        _equipmentRepository = equipmentRepository;
    }
}