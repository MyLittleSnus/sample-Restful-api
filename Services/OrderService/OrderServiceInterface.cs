using GoodsApi.Models;

namespace GoodsApi.Services.OrderService;

public interface IOrderService
{
    /// <summary>
    /// Method for getting orders without linked complex objects
    /// </summary>
    /// <returns></returns>
	IQueryable<Order> GetLazyOrders();

    /// <summary>
    /// Method for getting orders with linked complex objects
    /// </summary>
    /// <returns></returns>
    IQueryable<Order> GetCompleteOrders();

    /// <summary>
    /// Method for creating new order
    /// </summary>
    /// <returns>Task<bool></returns>
    Task<bool> CreateOrder(Order order);

    /// <summary>
    /// Method for updating existing order
    /// </summary>
    /// <returns></returns>
    Task<bool> UpdateOrderStatus((string Id, int status) updateInfo);

    /// <summary>
    /// Method for existing order deletion
    /// </summary>
    /// <returns></returns>
    Task<bool> DeleteOrder(string id);
}