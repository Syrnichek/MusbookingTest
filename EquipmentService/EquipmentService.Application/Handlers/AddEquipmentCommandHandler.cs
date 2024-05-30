using EquipmentService.Application.Commands;
using EquipmentService.Application.Mappers;
using EquipmentService.Core.Entities;
using EquipmentService.Core.Repositories;
using MediatR;

namespace EquipmentService.Application.Handlers;

public class AddEquipmentCommandHandler : IRequestHandler<AddEquipmentCommand, EquipmentResponse>
{
    private readonly IEquipmentRepository _equipmentRepository;

    public AddEquipmentCommandHandler(IEquipmentRepository equipmentRepository)
    {
        _equipmentRepository = equipmentRepository;
    }

    public async Task<EquipmentResponse> Handle(AddEquipmentCommand request, CancellationToken cancellationToken)
    {
        var equipmentEntity = EquipmentMapper.Mapper.Map<EquipmentModel>(request);
        if (equipmentEntity is null)
        {
            throw new ApplicationException("There is an issue with mapping while creating new product");
        }

        var newEquipment = await _equipmentRepository.AddEquipment(equipmentEntity);
        var equipmentResponse = EquipmentMapper.Mapper.Map<EquipmentResponse>(newEquipment);
        return equipmentResponse;
    }
}