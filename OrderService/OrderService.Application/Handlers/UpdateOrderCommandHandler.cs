using EquipmentService.Application;
using MediatR;
using OrderService.Application.Commands;
using OrderService.Application.Exceptions;
using OrderService.Application.Mappers;
using OrderService.Core.Entities;
using OrderService.Core.Repositories;

namespace OrderService.Application.Handlers;

public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, bool>
{
    private readonly IOrderRepository _orderRepository;
    
    private readonly equipmentService.equipmentServiceClient _equipmentServiceClient;

    public UpdateOrderCommandHandler(IOrderRepository orderRepository, equipmentService.equipmentServiceClient equipmentServiceClient)
    {
        _orderRepository = orderRepository;
        _equipmentServiceClient = equipmentServiceClient;
    }

    public async Task<bool> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        var orderEntity = OrderMapper.Mapper.Map<OrderModel>(request);
        var orderById = await _orderRepository.GetOrderById(request.OrderId);
        
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

            var equipmentInOrder = orderById.EquipmentList.Find(e => e.Name.Contains(equipment.Name));
            
            if (equipmentInOrder != null && equipmentInOrder.Amount > equipment.Amount)
            {
                var amountDifference = equipmentInOrder.Amount - equipment.Amount;
                var updateAmountRequest = new UpdateAmountRequest
                {
                    Name = equipment.Name,
                    Amount = equipmentFromDb.Amount + amountDifference
                };
                orderEntity.Price -= equipmentFromDb.Price * equipment.Amount;
                await _equipmentServiceClient.UpdateAmountAsync(updateAmountRequest);
            }
            else if (equipmentInOrder != null && equipmentInOrder.Amount < equipment.Amount)
            {
                var amountDifference = equipment.Amount - equipmentInOrder.Amount;
                var updateAmountRequest = new UpdateAmountRequest
                {
                    Name = equipment.Name,
                    Amount = equipmentFromDb.Amount - amountDifference
                };
                orderEntity.Price += equipmentFromDb.Price * equipment.Amount;
                await _equipmentServiceClient.UpdateAmountAsync(updateAmountRequest);
            }
            else if (equipmentInOrder == null)
            {
                var updateAmountRequest = new UpdateAmountRequest
                {
                    Name = equipment.Name,
                    Amount = equipmentFromDb.Amount - equipment.Amount
                };
                orderEntity.Price += equipmentFromDb.Price * equipment.Amount;
                await _equipmentServiceClient.UpdateAmountAsync(updateAmountRequest);
            }
            else
            {
                orderEntity.Price = orderById.Price;
            }
        }
        return await _orderRepository.UpdateOrder(orderEntity);
    }
}