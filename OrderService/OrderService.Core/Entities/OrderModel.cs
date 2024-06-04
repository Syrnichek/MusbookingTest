using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OrderService.Core.Entities;

public class OrderModel
{
    [Key]
    public int OrderId { get; set; }

    [MaxLength(50)]
    public string? Description { get; set; }

    public DateTime CreatedAt { get; set; }

    [DefaultValue(null)]
    public DateTime? UpdatedAt { get; set; }

    public double Price { get; set; }

    public virtual List<EquipmentInOrderModel> EquipmentList { get; set; }
}