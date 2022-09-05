using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RecipesApp.Infrastructure.Context;
using RecipesApp.IntegrationTests.Utils;

namespace RecipesApp.IntegrationTests
{
    public class CustomWebApplicationFactory<TStartup>
                : WebApplicationFactory<TStartup> where TStartup : class
    {
        private SqliteConnection _connection;

        public CustomWebApplicationFactory()
        {
            _connection = new SqliteConnection("DataSource=:memory:");
            _connection.Open();
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var serviceDescriptor = services
                    .SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<DataContext>));
                services.Remove(serviceDescriptor);

                // Create a new service provider.
                var serviceProvider = new ServiceCollection()
                    .AddEntityFrameworkSqlite()
                    .BuildServiceProvider();

                services.AddDbContext<DataContext>(options =>
                {
                    options.UseSqlite(_connection);
                    options.UseInternalServiceProvider(serviceProvider);
                }, ServiceLifetime.Scoped);

                // Build the service provider.
                var sp = services.BuildServiceProvider();

                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;

                    var db = scopedServices.GetRequiredService<DataContext>();

                    db.Database.EnsureDeleted();
                    db.Database.EnsureCreated();

                    InMemoryDbSeeder.SeedData(db);
                }
            });
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _connection.Close();
            _connection.Dispose();
        }
    }
}
