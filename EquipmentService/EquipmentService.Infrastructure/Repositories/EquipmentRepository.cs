using EquipmentService.Core.Entities;
using EquipmentService.Core.Repositories;

namespace EquipmentService.Infrastructure.Repositories;

public class EquipmentRepository : IEquipmentRepository
{
    public Task<EquipmentModel> AddEquipment(EquipmentModel equipmentModel)
    {
        throw new NotImplementedException();
    }

    public Task<int> UpdateAmount(int equipmentAmount)
    {
        throw new NotImplementedException();
    }

    public Task<EquipmentModel> GetEquipmentByName(string name)
    {
        throw new NotImplementedException();
    }

    public Task<List<EquipmentModel>> GetEquipmentAll()
    {
        throw new NotImplementedException();
    }
}