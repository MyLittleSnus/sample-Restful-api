using GoodsApi.Repositories;
using GoodsApi.Services.OrderService;

namespace GoodsApi.Infrustructure.Extensions.DependencyInjection;

public static partial class OrderDependenciesExtension
{
    public static IServiceCollection AddOrderDependencies(this IServiceCollection services)
    {
        services.AddTransient<OrderRepo>();
        services.AddTransient<IOrderService, OrderService>();
        services.AddTransient<Generators>();

        return services;
    }
}

