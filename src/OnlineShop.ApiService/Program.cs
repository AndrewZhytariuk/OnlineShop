using NLog.Web;
using OnlineShop.ApiService.AppStart.Configures;
using OnlineShop.ApiService.AppStart.ConfigureServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

ConfigureServicesKafka.ConfigureServices(builder.Services, builder.Configuration);
ConfigureServicesClient.ConfigureServices(builder.Services);
ConfigureServicesControllers.ConfigureServices(builder.Services);

ConfigureServicesBase.ConfigureServices(builder.Services, builder.Configuration);
ConfigureServicesCors.ConfigureServices(builder.Services, builder.Configuration);

ConfigureServicesAuthentication.ConfigureServices(builder.Services, builder.Configuration);
ConfigureServicesAuthorization.ConfigureServices(builder.Services);

builder.Logging.ClearProviders();
builder.Host.UseNLog();

var app = builder.Build();

ConfigureEndpoints.Configure(app, app.Environment);
ConfigureCommon.Configure(app);

app.MapRazorPages();
app.Run();
