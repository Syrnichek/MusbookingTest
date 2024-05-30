using EquipmentService.Application.Responses;
using MediatR;

namespace EquipmentService.Application.Queries;

public class GetEquipmentAllQuery : IRequest<List<EquipmentResponse>>
{
    
}