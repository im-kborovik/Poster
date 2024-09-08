using Microsoft.Extensions.DependencyInjection;

namespace Posts.Services;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IPostService, PostService>();
        return services;
    }
}