using EquipmentService.Application.Commands;
using EquipmentService.Application.Responses;
using MediatR;

namespace EquipmentService.Application.Handlers;

public class AddEquipmentCommandHandler : IRequestHandler<AddEquipmentCommand, EquipmentResponse>
{
    public Task<EquipmentResponse> Handle(AddEquipmentCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}