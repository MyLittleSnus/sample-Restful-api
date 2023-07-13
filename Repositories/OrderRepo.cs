using GoodsApi.Context;
using GoodsApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GoodsApi.Repositories
{
    public class OrderRepo : BaseRepo<Order>
    {
        public OrderRepo(ShopContext context) : base(context) { }

        public IQueryable<Order> GetOrdersIncludeLinked()
            => _dbContext.Orders.Include(o => o.Goods).AsQueryable();
    }
}