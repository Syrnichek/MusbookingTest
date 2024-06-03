using MediatR;
using OrderService.Core.Entities;

namespace OrderService.Application.Commands;

public class UpdateOrderCommand : IRequest<bool>
{
    public OrderModel orderModel { get; set; }
}