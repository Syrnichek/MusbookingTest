using EquipmentService.Application;
using MediatR;
using OrderService.Application.Commands;

namespace OrderService.Application.Handlers;

public class AddEquipmentCommandHandler : IRequestHandler<AddEquipmentCommand, EquipmentResponse>
{
    public Task<EquipmentResponse> Handle(AddEquipmentCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}