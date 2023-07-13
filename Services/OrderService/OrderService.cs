using GoodsApi.Models;
using GoodsApi.Repositories;

namespace GoodsApi.Services.OrderService;

public class OrderService : IOrderService
{
	private readonly OrderRepo _repo;

	public OrderService(OrderRepo repo) => _repo = repo;

	public IQueryable<Order> GetLazyOrders() => _repo.Read();

	public IQueryable<Order> GetCompleteOrders()
		=> _repo.GetOrdersIncludeLinked();

	public async Task<bool> CreateOrder(Order order)
		=> await _repo.Create(order);

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