using System.ComponentModel.DataAnnotations;

namespace OrderService.Core.Entities;

public class EquipmentInOrderModel
{
    [Key]
    public int EquipmentInOrder { get; set; }

    public string Name { get; set; }

    public int Amount { get; set; }
}