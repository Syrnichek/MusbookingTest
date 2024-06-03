using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrderService.Application.Commands;
using EquipmentService.Application;
using OrderService.Application.Mappers;

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
}