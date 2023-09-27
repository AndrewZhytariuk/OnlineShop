using OnlineShop.ApiService.Authorization;
using OnlineShop.Lib.Clients.ArticlesService;
using OnlineShop.Lib.Clients.IdentityServer;
using OnlineShop.Lib.Clients.OrdersService;
using OnlineShop.Lib.Clients.UserManagementServer;
using OnlineShop.Lib.Clients;
using OnlineShop.Lib.Serveces.ArticlesService.Models;
using OnlineShop.Lib.Serveces.OrdersService.Models;
using OnlineShop.CategoryData.Models;
using OnlineShop.Lib.Clients.CategoryMicroServece;
using MessageBroker.Kafka.Lib;
using OnlineShop.ApiService.Kafka.Producers.ItemProducers;
using OnlineShop.CategoryData.Models.Interfaces;
using OnlineShop.CategoryData.Interfaces;

namespace OnlineShop.ApiService.AppStart.ConfigureServices
{
    public static class ConfigureServicesControllers
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IRolesClient, RolesClient>();
            services.AddTransient<IUsersClient, UsersClient>();
            services.AddTransient<IIdentityServerClient, IdentityServerClient>();
            services.AddTransient<IClientAuthorization, HttpClientAuthorization>();
            services.AddTransient<IRepoClient<Article>, ArticlesClient>();
            services.AddTransient<IRepoClient<PriceList>, PriceListClient>();
            services.AddTransient<IRepoClient<OrderedArticle>, OrdersArticlesClient>();
            services.AddTransient<IRepoClient<Item>, CategoryClient>();
            services.AddTransient<IRepoClient<Order>, OrderedClient>();

            services.AddSingleton<IBaseEventProducer<ItemAdd>, ItemAddEventProducer>();
            services.AddSingleton<IBaseEventProducer<ItemUpdate>, ItemUpdateEventProducer>();
            services.AddSingleton<IBaseEventProducer<IIdentifiable>, ItemDeleteEventProducer>();

        }
    }
}
