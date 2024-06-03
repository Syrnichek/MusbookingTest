using EquipmentService.Application;
using MediatR;
using OrderService.Application.Commands;
using OrderService.Application.Mappers;
using OrderService.Application.Responses;
using OrderService.Core.Repositories;

namespace OrderService.Application.Handlers;

public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, bool>
{
    private readonly IOrderRepository _orderRepository;

    private readonly equipmentService.equipmentServiceClient _equipmentServiceClient;

    public DeleteOrderCommandHandler(IOrderRepository orderRepository, equipmentService.equipmentServiceClient equipmentServiceClient)
    {
        _orderRepository = orderRepository;
        _equipmentServiceClient = equipmentServiceClient;
    }

    public async Task<bool> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        var orderEntity = await _orderRepository.GetOrderById(request.Id);
        
        var command = await _orderRepository.DeleteOrder(request.Id);
        
        var equipmentList = orderEntity.EquipmentList;
        foreach (var equipment in equipmentList)
        {
            var getEquipmentByNameRequest = new GetEquipmentByNameRequest
            {
                Name = equipment.Name
            };

            var equipmentAmount = await _equipmentServiceClient.GetEquipmentByNameAsync(getEquipmentByNameRequest); 
            
            var updateAmountRequest = new UpdateAmountRequest
            {
                Name = equipment.Name,
                Amount = equipmentAmount.Amount + equipment.Amount
            };
            _equipmentServiceClient.UpdateAmountAsync(updateAmountRequest);
        }

        return command;
    }
}