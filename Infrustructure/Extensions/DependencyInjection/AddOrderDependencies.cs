using GoodsApi.Repositories;
using GoodsApi.Services;

namespace GoodsApi.Infrustructure.Extensions.DependencyInjection;

public static partial class OrderDependenciesExtension
{
    public static IServiceCollection AddOrderDependencies(this IServiceCollection services)
    {
        services.AddTransient<OrderRepo>();
        services.AddTransient<OrderService>();
        services.AddTransient<Generators>();

        return services;
    }
}

