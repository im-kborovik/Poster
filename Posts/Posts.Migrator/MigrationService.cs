using Microsoft.EntityFrameworkCore;
using Posts.Repositories;

namespace Posts.Migrator;

internal sealed class MigrationService(IHostApplicationLifetime applicationLifetime, IServiceProvider serviceProvider, ILogger<MigrationService> logger) : IHostedService
{
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        try
        {
            using var serviceScope = serviceProvider.CreateScope();
            var context = serviceScope.ServiceProvider.GetRequiredService<PostDbContext>();
            await context.Database.EnsureCreatedAsync(cancellationToken);
            await context.Database.MigrateAsync(cancellationToken);
        }
        catch (Exception e)
        {
            logger.LogError(e, "Error during migration process.");
        }
        finally
        {
            applicationLifetime.StopApplication();
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}