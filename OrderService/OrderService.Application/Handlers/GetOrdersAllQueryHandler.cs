using MediatR;
using OrderService.Application.Queries;
using OrderService.Core.Entities;
using OrderService.Core.Repositories;

namespace OrderService.Application.Handlers;

public class GetOrdersAllQueryHandler : IRequestHandler<GetOrdersByPageQuery, List<OrderModel>>
{
    private readonly IOrderRepository _orderRepository;

    public GetOrdersAllQueryHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public Task<List<OrderModel>> Handle(GetOrdersByPageQuery request, CancellationToken cancellationToken)
    {
        return _orderRepository.GetOrdersByPage(request.pageNumber);
    }
}