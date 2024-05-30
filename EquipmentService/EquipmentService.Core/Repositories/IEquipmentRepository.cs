using EquipmentService.Core.Entities;

namespace EquipmentService.Core.Repositories;

public interface IEquipmentRepository
{
    Task<EquipmentModel> AddEquipment(EquipmentModel equipmentModel);

    Task<bool> UpdateAmount(string name, int equipmentAmount);

    Task<EquipmentModel> GetEquipmentByName(string name);

    Task<List<EquipmentModel>> GetEquipmentAll();
}