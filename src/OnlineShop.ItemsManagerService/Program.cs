using Microsoft.Extensions.DependencyInjection;
using OnlineShop.CategoryData.Repository;
using OnlineShop.ItemsManagerService.AppStart.Configures;
using OnlineShop.ItemsManagerService.AppStart.ConfigureServices;
using OnlineShop.ItemsManagerService.Controllers;
using OnlineShop.ItemsManagerService.Kafka.Consumer;
using OnlineShop.ItemsManagerService.Kafka.Handlers;
using OnlineShop.ItemsManagerService.Services;
using OnlineShop.Lib.Clients.CategoryMicroServece;
using OnlineShop.Lib.Serveces.ArticlesService.Repo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

//var categoryAdressesTopics = new CategoryAdressesTopics();
//builder.Configuration.GetSection(CategoryAdressesTopics.SectionName).Bind(categoryAdressesTopics);

ConfigureServicesBase.ConfigureServices(builder.Services, builder.Configuration);
ConfigureServicesKafka.ConfigureServices(builder.Services, builder.Configuration);
ConfigureServicesControllers.ConfigureServices(builder.Services);

//builder.Services.AddTransient<ItemIventConsumer>();

var app = builder.Build();

ConfigureEndpoints.Configure(app, app.Environment);
ConfigureCommon.Configure(app);

app.MapRazorPages();

app.Run();
