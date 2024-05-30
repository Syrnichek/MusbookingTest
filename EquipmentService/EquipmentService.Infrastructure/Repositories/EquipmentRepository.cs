using EquipmentService.Core.Entities;
using EquipmentService.Core.Repositories;
using EquipmentService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EquipmentService.Infrastructure.Repositories;

public class EquipmentRepository : IEquipmentRepository
{
    private readonly EquipmentContext _equipmentContext;

    public EquipmentRepository(EquipmentContext equipmentContext)
    {
        _equipmentContext = equipmentContext;
    }

    public async Task<EquipmentModel> AddEquipment(EquipmentModel equipmentModel)
    {
        await _equipmentContext.EquipmentModels.AddAsync(equipmentModel);
        await _equipmentContext.SaveChangesAsync();
        return equipmentModel;
    }

    public async Task<bool> UpdateAmount(string name, int equipmentAmount)
    {
        var entity = await _equipmentContext
            .EquipmentModels
            .FirstOrDefaultAsync(e => e.Name ==name);
        
        if (entity != null)
        {
            entity.Amount = equipmentAmount;
            _equipmentContext.EquipmentModels.Update(entity);
            return _equipmentContext.SaveChangesAsync().IsCompleted;
        }

        return false;
    }

    public async Task<EquipmentModel> GetEquipmentByName(string name)
    {
        return await _equipmentContext.EquipmentModels.FirstOrDefaultAsync(e => e.Name == name) ?? throw new InvalidOperationException();
    }

    public async Task<List<EquipmentModel>> GetEquipmentAll()
    {
        return await _equipmentContext.EquipmentModels.ToListAsync();
    }
}