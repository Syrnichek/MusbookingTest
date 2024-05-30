using System.ComponentModel.DataAnnotations;

namespace EquipmentService.Application.Responses;

public class EquipmentResponse
{
    [Key]
    public int EquipmentId { get; set; }
    
    public string Name { get; set; }

    public int Amount { get; set; }
    
    public double Price { get; set; }
}