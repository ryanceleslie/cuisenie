using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Data.Seed;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureKeyVault;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;

namespace API
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var logger = services.GetRequiredService<IAppLogger<RecipeSeed>>();

                try
                {
                    var context = services.GetRequiredService<CuisenieContext>();
                    await RecipeSeed.SeedAsync(context, logger);
                }
                catch (Exception ex)
                {
                    logger.Error(ex, ex.Message);
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, config) =>
                {
                    // Azure Key Vault required for the DB connection string
                    // Need environment variables for eventual Azure AppSettings override
                    config.AddJsonFile("azurekeyvault.json", optional: true, reloadOnChange: true)
                        .AddEnvironmentVariables();
                    var builtConfig = config.Build();

                    var azureServiceTokenProvider = new AzureServiceTokenProvider();
                    var keyVaultClient = new KeyVaultClient(
                        new KeyVaultClient.AuthenticationCallback(
                            azureServiceTokenProvider.KeyVaultTokenCallback));

                    config.AddAzureKeyVault(
                        $"https://{builtConfig["azureKeyVault:name"]}.vault.azure.net/",
                        keyVaultClient,
                        new DefaultKeyVaultSecretManager());
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
