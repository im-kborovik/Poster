using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Posts.Repositories;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<PostDbContext>(options =>
                                             {
                                                 options.UseSqlServer(connectionString,
                                                                      builder =>
                                                                      {
                                                                          builder.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
                                                                      });
                                             })
                .AddEntityFrameworkSqlServer();

        services.AddScoped<IPostRepository, PostRepository>();

        return services;
    }
}