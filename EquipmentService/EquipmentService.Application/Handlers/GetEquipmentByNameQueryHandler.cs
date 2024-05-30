using EquipmentService.Application.Mappers;
using EquipmentService.Application.Queries;
using EquipmentService.Core.Repositories;
using MediatR;

namespace EquipmentService.Application.Handlers;

public class GetEquipmentByNameQueryHandler : IRequestHandler<GetEquipmentByNameQuery, EquipmentResponse>
{
    private readonly IEquipmentRepository _equipmentRepository;

    public GetEquipmentByNameQueryHandler(IEquipmentRepository equipmentRepository)
    {
        _equipmentRepository = equipmentRepository;
    }

    public async Task<EquipmentResponse> Handle(GetEquipmentByNameQuery request, CancellationToken cancellationToken)
    {
        var equipment = await _equipmentRepository.GetEquipmentByName(request.Name);
        var equipmentResponse = EquipmentMapper.Mapper.Map<EquipmentResponse>(equipment);
        return equipmentResponse;
    }
}