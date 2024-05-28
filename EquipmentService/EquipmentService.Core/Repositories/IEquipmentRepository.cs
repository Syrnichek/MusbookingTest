using EquipmentService.Core.Entities;

namespace EquipmentService.Core.Repositories;

public interface IEquipmentRepository
{
    Task<EquipmentModel> AddEquipment(EquipmentModel equipmentModel);

    Task<int> UpdateAmount(int equipmentAmount);

    Task<EquipmentModel> GetEquipmentByName(string name);

    Task<List<EquipmentModel>> GetEquipmentAll();
}