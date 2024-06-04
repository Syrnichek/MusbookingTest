using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MediatR;
using OrderService.Core.Entities;

namespace OrderService.Application.Commands;

public class UpdateOrderCommand : IRequest<bool>
{
    public int OrderId { get; set; }
    
    [MaxLength(50)]
    public string? Description { get; set; }
    
    [DefaultValue(null)]
    public DateTime? UpdatedAt { get; set; }
    
    public List<EquipmentInOrderModel> EquipmentList { get; set; }
}