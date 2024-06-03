using EquipmentService.Application;
using MediatR;
using OrderService.Application.Commands;
using OrderService.Application.Exceptions;
using OrderService.Application.Mappers;
using OrderService.Application.Responses;
using OrderService.Core.Entities;
using OrderService.Core.Repositories;

namespace OrderService.Application.Handlers;

public class AddOrderCommandHandler : IRequestHandler<AddOrderCommand, OrderResponse>
{
    private readonly IOrderRepository _orderRepository;

    private readonly equipmentService.equipmentServiceClient _equipmentServiceClient;

    public AddOrderCommandHandler(IOrderRepository orderRepository, equipmentService.equipmentServiceClient equipmentServiceClient)
    {
        _orderRepository = orderRepository;
        _equipmentServiceClient = equipmentServiceClient;
    }

    public async Task<OrderResponse> Handle(AddOrderCommand request, CancellationToken cancellationToken)
    {
        var orderEntity = OrderMapper.Mapper.Map<OrderModel>(request);
        
        var command = _orderRepository.AddOrder(orderEntity);
        
        var equipmentList = request.orderModel.EquipmentList;
        foreach (var equipment in equipmentList)
        {
            var getEquipmentByNameRequest = new GetEquipmentByNameRequest
            {
                Name = equipment.Name
            };

            var equipmentAmount = await _equipmentServiceClient.GetEquipmentByNameAsync(getEquipmentByNameRequest);

            if (equipmentAmount.Amount < equipment.Amount)
            {
                throw new EquipmentAmountNotEnoughException("Not enough equipment");
            }
            
            var updateAmountRequest = new UpdateAmountRequest
            {
                Name = equipment.Name,
                Amount = equipmentAmount.Amount - equipment.Amount
            };
            _equipmentServiceClient.UpdateAmountAsync(updateAmountRequest);
        }

        var response = OrderMapper.Mapper.Map<OrderResponse>(command);

        return response;
    }
}