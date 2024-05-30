using EquipmentService.Application.Responses;
using MediatR;

namespace EquipmentService.Application.Queries;

public class GetEquipmentByNameQuery : IRequest<EquipmentResponse>
{
    public GetEquipmentByNameQuery(string name)
    {
        Name = name;
    }

    public string Name { get; set; }
}