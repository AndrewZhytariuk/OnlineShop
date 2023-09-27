using OnlineShop.ItemsManagerService.Kafka.Consumer;
using OnlineShop.ItemsManagerService.Services;
using MessageBroker.Kafka.Lib;
using OnlineShop.CategoryData.Models;
using OnlineShop.ItemsManagerService.Services.Interfaces;
using MessageBroker.Kafka.Lib.Option.ConsumersOption;
using MessageBroker.Kafka.Lib.Interfaces;
using OnlineShop.ItemsManagerService.Kafka.Handlers;
using OnlineShop.CategoryData.Repository.Base.Interfaces;
using OnlineShop.CategoryData.Repository;
using OnlineShop.CategoryData.Models.Interfaces;
using OnlineShop.CategoryData.Interfaces;

namespace OnlineShop.ItemsManagerService.AppStart.ConfigureServices
{
    public static class ConfigureServicesControllers
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IRepos<Item>, ItemsRepository>();
            services.AddScoped<IServeces<Item>, ItemService>();

            services.AddScoped<IEventHandler<ItemAdd>, CategoryAddEventHandler>();
            services.AddScoped<IEventHandler<IIdentifiable>, CategoryDeleteEventHandler>();
            services.AddScoped<IEventHandler<ItemUpdate>, CategoryUpdateEventHandler>();

            var _services = services.BuildServiceProvider();

            services.AddSingleton<IBaseEventConsumer<ItemAdd>>(
            new CategoryAddEventConsumer(
                _services.GetRequiredService<IEventHandler<ItemAdd>>(),
                _services.GetRequiredService<ILogger<ItemAdd>>(),
                _services.GetRequiredService<BaseConsumerKafksSettings>()
                ));

            services.AddSingleton<IBaseEventConsumer<ItemUpdate>>(
            new CategoryUpdateEventConsumer(
                _services.GetRequiredService<IEventHandler<ItemUpdate>>(),
                _services.GetRequiredService<ILogger<ItemUpdate>>(),
                _services.GetRequiredService<BaseConsumerKafksSettings>()
                ));

            services.AddSingleton<IBaseEventConsumer<IIdentifiable>>(
            new CategoryDeleteEventConsumer(
                _services.GetRequiredService<IEventHandler<IIdentifiable>>(),
                _services.GetRequiredService<ILogger<IIdentifiable>>(),
                _services.GetRequiredService<BaseConsumerKafksSettings>()
                ));

            //services.Scan(scan => scan
            // .FromAssemblyOf<ItemIventConsumer>()
            //.AddClasses(classes => classes.AssignableTo(typeof(IBaseEventConsumer<>))).AsImplementedInterfaces().WithTransientLifetime()
            //.FromAssemblyOf<ItemService>()
            //.AddClasses(classes => classes.AssignableTo(typeof(CategoryData.Repository.Base.Interfaces.IRepos<>))).AsImplementedInterfaces().WithTransientLifetime()
            //);
        }
    }
}
