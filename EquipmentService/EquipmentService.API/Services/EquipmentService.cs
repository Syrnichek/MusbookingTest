using EquipmentService.Application;
using EquipmentService.Application.Commands;
using EquipmentService.Application.Queries;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using MediatR;

namespace EquipmentService.API.Services;

public class EquipmentService : equipmentService.equipmentServiceBase
{
    private readonly IMediator _mediator;

    public EquipmentService(IMediator mediator)
    {
        _mediator = mediator;
    }

    public override async Task<EquipmentResponse> AddEquipment(AddEquipmentRequest request, ServerCallContext context)
    {
        var command = new AddEquipmentCommand
        {
            Name = request.Name,
            Amount = request.Amount,
            Price = request.Price
        };
        return await _mediator.Send(command);
    }

    public override async Task<EquipmentResponseList> GetEquipmentAll(Empty request, ServerCallContext context)
    {
        var result = await _mediator.Send(new GetEquipmentAllQuery());
        var response = new EquipmentResponseList
        {
            Equipment = { result.Select(item => item) }
        };
        return response;
    }

    public override async Task<EquipmentResponse> GetEquipmentByName(GetEquipmentByNameRequest request, ServerCallContext context)
    {
        var query = new GetEquipmentByNameQuery(request.Name);
        return await _mediator.Send(query);
    }

    public override async Task<UpdateAmountResponse> UpdateAmount(UpdateAmountRequest request, ServerCallContext context)
    {
        var command = new UpdateAmountCommand
        {
            Amount = request.Amount,
            Name = request.Name
        };
        
        var result = await _mediator.Send(command);

        var response = new UpdateAmountResponse
        {
            Result = result
        };
        
        return response;
    }
}