using OrderService.Core.Entities;

namespace OrderService.Core.Repositories;

public interface IOrderRepository
{
    Task<OrderModel> AddOrder(OrderModel orderModel);

    Task<bool> UpdateOrder(OrderModel orderModel);

    Task<bool> DeleteOrder(int id);

    Task<List<OrderModel>> GetOrdersByPage(int pageNumber);

    Task<OrderModel> GetOrderById(int id);
}