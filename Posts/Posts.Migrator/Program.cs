using Posts.Migrator;
using Posts.Repositories;

var builder = Host.CreateDefaultBuilder(args);
builder.ConfigureServices((context, services) =>
                          {
                              services.AddRepositories(context.Configuration.GetConnectionString("Default")!);
                              services.AddHostedService<MigrationService>();
                          });

var host = builder.Build();
host.Run();