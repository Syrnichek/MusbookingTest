using MediatR;

namespace EquipmentService.Application.Commands;

public class UpdateAmountCommand : IRequest<bool>
{
    public string Name { get; set; }
    
    public int Amount { get; set; }
}