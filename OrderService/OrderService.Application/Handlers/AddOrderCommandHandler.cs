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
        
        foreach (var equipment in request.EquipmentList)
        {
            var getEquipmentByNameRequest = new GetEquipmentByNameRequest
            {
                Name = equipment.Name
            };

            var equipmentFromDb = await _equipmentServiceClient.GetEquipmentByNameAsync(getEquipmentByNameRequest);

            if (equipmentFromDb.Amount < equipment.Amount)
            {
                throw new EquipmentAmountNotEnoughException("Not enough equipment");
            }
            
            var updateAmountRequest = new UpdateAmountRequest
            {
                Name = equipment.Name,
                Amount = equipmentFromDb.Amount - equipment.Amount
            };
            await _equipmentServiceClient.UpdateAmountAsync(updateAmountRequest);

            orderEntity.Price += equipmentFromDb.Price;
        }
        
        var command = await _orderRepository.AddOrder(orderEntity);
        
        var response = OrderMapper.Mapper.Map<OrderResponse>(command);

        return response;
    }
}