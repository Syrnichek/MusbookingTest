using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace OrderService.Core.Entities;

[Index("Name", IsUnique = true)]
public class EquipmentModel
{
    [Key]
    public int EquipmentId { get; set; }
    
    public string Name { get; set; }

    public int Amount { get; set; }
    
    public double Price { get; set; }
}