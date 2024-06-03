using MediatR;
using OrderService.Application.Responses;
using OrderService.Core.Entities;

namespace OrderService.Application.Commands;

public class AddOrderCommand : IRequest<OrderResponse>
{
    public OrderModel orderModel { get; set; }
}