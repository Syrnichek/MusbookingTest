using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrderService.Application.Commands;
using EquipmentService.Application;
using OrderService.Application.Mappers;
using OrderService.Application.Queries;
using OrderService.Application.Responses;
using OrderService.Core.Entities;

namespace OrderService.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderServiceController : Controller
{
    private readonly IMediator _mediator;

    public OrderServiceController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost]
    [Route("[action]")]
    public async Task<EquipmentResponse> AddEquipment([FromBody] AddEquipmentCommand addChecklistCommand)
    {
        var result = await _mediator.Send(addChecklistCommand);
        var mappedResult = OrderMapper.Mapper.Map<EquipmentResponse>(result);
        return mappedResult;
    }
    
    [HttpPost]
    [Route("[action]")]
    public async Task<OrderResponse> AddOrder([FromBody] AddOrderCommand addChecklistCommand)
    {
        var result = await _mediator.Send(addChecklistCommand);
        var mappedResult = OrderMapper.Mapper.Map<OrderResponse>(result);
        return mappedResult;
    }
    
    [HttpPost]
    [Route("[action]")]
    public async Task<bool> UpdateOrder([FromBody] UpdateOrderCommand updateOrderCommand)
    {
        var result = await _mediator.Send(updateOrderCommand);
        return result;
    }
    
    [HttpGet]
    [Route("[action]")]
    public async Task<bool> DeleteOrder([FromQuery] DeleteOrderCommand deleteOrderCommand)
    {
        var result = await _mediator.Send(deleteOrderCommand);
        return result;
    }
    
    [HttpGet]
    [Route("[action]")]
    public async Task<List<OrderModel>> GetOrdersAll([FromQuery] GetOrdersByPageQuery getOrdersByPageQuery)
    {
        var result = await _mediator.Send(getOrdersByPageQuery);
        return result;
    }
}