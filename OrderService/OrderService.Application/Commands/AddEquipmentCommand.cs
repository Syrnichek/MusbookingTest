using EquipmentService.Application;
using MediatR;

namespace OrderService.Application.Commands;

public class AddEquipmentCommand : IRequest<EquipmentResponse>
{
    public string Name { get; set; }

    public int Amount { get; set; }
    
    public double Price { get; set; }
}