using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MediatR;
using OrderService.Application.Responses;
using OrderService.Core.Entities;

namespace OrderService.Application.Commands;

public class AddOrderCommand : IRequest<OrderResponse>
{
    [MaxLength(50)]
    public string? Description { get; set; }

    public DateTime CreatedAt { get; set; }

    [DefaultValue(null)]
    public DateTime? UpdatedAt { get; set; }
    
    public List<EquipmentInOrderModel> EquipmentList { get; set; }
}