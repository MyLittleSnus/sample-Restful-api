using GoodsApi.Models;
using GoodsApi.Repositories;

namespace GoodsApi.Services.OrderService;

public class OrderService : IOrderService
{
	private readonly OrderRepo _repo;

	public OrderService(OrderRepo repo) => _repo = repo;

	public async Task<IEnumerable<Order>> GetLazyOrders()
	{
		var orders = await _repo.Read();

        return orders.Count() > 0 ? orders : Enumerable.Empty<Order>();
    }

	public async Task<IEnumerable<Order>> GetCompleteOrders()
	{
		var orders = await GetLazyOrders();

		if (orders == null || orders.Count() == 0)
			return Enumerable.Empty<Order>();

		foreach (var order in orders)
			_repo.IncludeMultiple(order, (o) => o.Goods);

		return orders;
	}

	public async Task<bool> CreateOrder(Order order)
	{
		return await _repo.Create(order);
	}

	public async Task<bool> UpdateOrderStatus((string Id, int status) updateInfo)
	{
		var order = await _repo.GetById(updateInfo.Id);

		if (order.Status == updateInfo.status)
			return true;

		order.Status = updateInfo.status;

		return await _repo.Update(order);
    }

	public async Task<bool> DeleteOrder(string id)
	{
		return await _repo.Delete(id);
    }
}