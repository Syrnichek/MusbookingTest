using EquipmentService.Application.Commands;
using EquipmentService.Core.Repositories;
using MediatR;

namespace EquipmentService.Application.Handlers;

public class UpdateAmountCommandHandler : IRequestHandler<UpdateAmountCommand, bool>
{
    private readonly IEquipmentRepository _equipmentRepository;

    public UpdateAmountCommandHandler(IEquipmentRepository equipmentRepository)
    {
        _equipmentRepository = equipmentRepository;
    }

    public async Task<bool> Handle(UpdateAmountCommand request, CancellationToken cancellationToken)
    {
        var equipmentEntity = await _equipmentRepository.UpdateAmount(request.Name, request.Amount);
        return equipmentEntity;
    }
}