using Microsoft.EntityFrameworkCore;
using OrderService.Core.Entities;
using OrderService.Core.Repositories;
using OrderService.Infrastructure.Data;

namespace OrderService.Infrastructure.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly OrderContext _orderContext;

    public OrderRepository(OrderContext orderContext)
    {
        _orderContext = orderContext;
    }

    public async Task<OrderModel> AddOrder(OrderModel orderModel)
    {
        await _orderContext.OrderModels.AddAsync(orderModel);
        await _orderContext.SaveChangesAsync();
        return orderModel;
    }

    public async Task<bool> UpdateOrder(OrderModel orderModel)
    {
        var entity = await _orderContext
            .OrderModels
            .FirstOrDefaultAsync(e => e.OrderId == orderModel.OrderId);

        if (entity != null)
        {
            entity.EquipmentList = orderModel.EquipmentList;
            entity.Description = orderModel.Description;
            entity.UpdatedAt = DateTime.UtcNow;
            _orderContext.OrderModels.Update(entity);
            return _orderContext.SaveChangesAsync().IsCompleted;
        }

        return false;
    }

    public async Task<bool> DeleteOrder(int id)
    {
        var entity = await _orderContext
            .OrderModels
            .FirstOrDefaultAsync(e => e.OrderId == id);
        
        if (entity != null)
        {
            _orderContext.OrderModels.Remove(entity);
            return _orderContext.SaveChangesAsync().IsCompleted;
        }

        return false;
    }
    
    public async Task<List<OrderModel>> GetOrdersByPage(int pageNumber)
    {
        int pageSize = 10;
        IQueryable<OrderModel> queryable = _orderContext.OrderModels;
        
        var pagedOrders = queryable
            .OrderByDescending(o => o.CreatedAt)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        return pagedOrders;
    }

    public async Task<OrderModel> GetOrderById(int id)
    {
        return await _orderContext.OrderModels
            .Include(o => o.EquipmentList)
            .FirstOrDefaultAsync(o => o.OrderId == id) ?? throw new InvalidOperationException();
    }
}