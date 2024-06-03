using EquipmentService.Core.Entities;

namespace OrderService.Application.Responses;

public class OrderResponse
{
    public string Description { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public double Price { get; set; }

    public List<EquipmentModel> EquipmentList { get; set; }
}