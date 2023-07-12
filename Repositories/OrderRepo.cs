using System;
using GoodsApi.Context;
using GoodsApi.Models;

namespace GoodsApi.Repositories
{
    public class OrderRepo : BaseRepo<Order>
    {
        public OrderRepo(ShopContext context) : base(context) { }
    }
}