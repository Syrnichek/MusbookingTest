using MediatR;
using OrderService.Core.Entities;

namespace OrderService.Application.Queries;

public class GetOrdersByPageQuery : IRequest<List<OrderModel>>
{
    public int pageNumber { get; set; }
}