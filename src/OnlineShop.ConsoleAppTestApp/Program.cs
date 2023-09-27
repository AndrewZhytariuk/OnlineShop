using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Lib.Options;
using OnlineShop.Lib.Clients.UserManagementServer;
using OnlineShop.Lib.Clients.IdentityServer;

namespace OnlineShop.ConsoleAppTestApp;

class Program 
{
    static async Task<int> Main(string[] args)
    {
        var buider = new HostBuilder()
            .ConfigureServices((hostContext, serveces) =>
            {

                serveces.AddTransient<AuthenticationServeceTest>();

                var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

                IConfiguration configuration = configurationBuilder.Build();

                serveces.AddHttpClient<IdentityServerClient>();
                serveces.AddHttpClient<RolesClient>();
                serveces.AddHttpClient<UsersClient>();

                serveces.Configure<IdentityServerApiOptions>(configuration.GetSection(IdentityServerApiOptions.SectionName));
                serveces.Configure<ServiceAdressOptions>(configuration.GetSection(ServiceAdressOptions.SectionName));
            })
            .ConfigureLogging(logging =>
            {
                logging.AddConsole();
                logging.SetMinimumLevel(LogLevel.Information);
            })
            .UseConsoleLifetime();

        var host = buider.Build();

        using (var serviceScope = host.Services.CreateScope())
        {
            var services = serviceScope.ServiceProvider;

            try
            {
                var service = services.GetRequiredService<AuthenticationServeceTest>();

                var rolesResult = await service.RunRolesClientTests(args);
                var userReesult = await service.RunUsersClientTest(args);

                Console.WriteLine(rolesResult);
                Console.WriteLine(userReesult);

            } catch (Exception ex) 
            {
                Console.WriteLine($"Error occured: {ex.Message}");
            }
        }
         Console.ReadKey();

        return 0;
    }
}