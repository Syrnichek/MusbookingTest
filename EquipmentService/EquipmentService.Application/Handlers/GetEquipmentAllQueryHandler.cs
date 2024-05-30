using EquipmentService.Application.Mappers;
using EquipmentService.Application.Queries;
using EquipmentService.Core.Repositories;
using MediatR;

namespace EquipmentService.Application.Handlers;

public class GetEquipmentAllQueryHandler : IRequestHandler<GetEquipmentAllQuery, List<EquipmentResponse>>
{
    private readonly IEquipmentRepository _equipmentRepository;

    public GetEquipmentAllQueryHandler(IEquipmentRepository equipmentRepository)
    {
        _equipmentRepository = equipmentRepository;
    }

    public async Task<List<EquipmentResponse>> Handle(GetEquipmentAllQuery request, CancellationToken cancellationToken)
    {
        var equipmentList = await _equipmentRepository.GetEquipmentAll();
        var equipmentListResponse = EquipmentMapper.Mapper.Map<List<EquipmentResponse>>(equipmentList);
        return equipmentListResponse;
    }
}