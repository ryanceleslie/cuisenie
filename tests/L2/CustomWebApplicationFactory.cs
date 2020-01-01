using Microsoft.AspNetCore.Mvc.Testing;
using API;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace L2
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Testing");

            builder.ConfigureServices(services =>
            {
                services.AddEntityFrameworkInMemoryDatabase();

                // Create a new service provider.
                var provider = services
                    .AddEntityFrameworkInMemoryDatabase()
                    .BuildServiceProvider();

                // Add a database context (ApplicationDbContext) using an in-memory 
                // database for testing.
                services.AddDbContext<MealPlannerContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryDbForTesting");
                    options.UseInternalServiceProvider(provider);
                });

                // Build the service provider.
                var sp = services.BuildServiceProvider();

                // Create a scope to obtain a reference to the database
                // context (ApplicationDbContext).
                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var db = scopedServices.GetRequiredService<MealPlannerContext>();
                    var loggerFactory = scopedServices.GetRequiredService<ILoggerFactory>();

                    var logger = scopedServices
                        .GetRequiredService<ILogger<CustomWebApplicationFactory<TStartup>>>();

                    // Ensure the database is created.
                    db.Database.EnsureCreated();

                    //TODO eventually I do want to seed the DB with data
                    //try
                    //{
                    //    // Seed the database with test data.
                    //    CatalogContextSeed.SeedAsync(db, loggerFactory).Wait();

                    //    // seed sample user data
                    //    var userManager = scopedServices.GetRequiredService<UserManager<ApplicationUser>>();
                    //    var roleManager = scopedServices.GetRequiredService<RoleManager<IdentityRole>>();
                    //    AppIdentityDbContextSeed.SeedAsync(userManager, roleManager).Wait();
                    //}
                    //catch (Exception ex)
                    //{
                    //    logger.LogError(ex, $"An error occurred seeding the " +
                    //        "database with test messages. Error: {ex.Message}");
                    //}
                }
            });
        }
    }
}
