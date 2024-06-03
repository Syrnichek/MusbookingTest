using System.ComponentModel.DataAnnotations;

namespace OrderService.Core.Entities;

public class OrderModel
{
    [Key]
    public int OrderId { get; set; }

    public string Description { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public double Price { get; set; }

    public List<EquipmentInOrderModel> EquipmentList { get; set; }
}