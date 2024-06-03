using EquipmentService.Application;
using MediatR;
using OrderService.Application.Commands;
using OrderService.Application.Mappers;

namespace OrderService.Application.Handlers;

public class AddEquipmentCommandHandler : IRequestHandler<AddEquipmentCommand, EquipmentResponse>
{
    private readonly EquipmentService.Application.equipmentService.equipmentServiceClient _equipmentServiceClient;

    public AddEquipmentCommandHandler(equipmentService.equipmentServiceClient equipmentServiceClient)
    {
        _equipmentServiceClient = equipmentServiceClient;
    }

    public async Task<EquipmentResponse> Handle(AddEquipmentCommand request, CancellationToken cancellationToken)
    {
        var entity = OrderMapper.Mapper.Map<AddEquipmentRequest>(request);
        
        var result = await _equipmentServiceClient.AddEquipmentAsync(entity);

        var response = OrderMapper.Mapper.Map<EquipmentResponse>(result);
        return response;
    }
}