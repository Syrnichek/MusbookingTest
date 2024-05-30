using EquipmentService.Application.Responses;
using MediatR;

namespace EquipmentService.Application.Commands;

public class AddEquipmentCommand : IRequest<EquipmentResponse>
{
    public string Name { get; set; }

    public int Amount { get; set; }
    
    public double Price { get; set; }
}