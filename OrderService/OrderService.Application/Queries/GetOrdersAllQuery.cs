using MediatR;
using OrderService.Core.Entities;

namespace OrderService.Application.Queries;

public class GetOrdersAllQuery : IRequest<List<OrderModel>>
{
    
}