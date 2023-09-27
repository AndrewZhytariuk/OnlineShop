using OnlineShop.Lib.Clients.ArticlesService;
using OnlineShop.Lib.Clients.CategoryMicroServece;
using OnlineShop.Lib.Clients.IdentityServer;
using OnlineShop.Lib.Clients.UserManagementServer;
using OnlineShop.Lib.Serveces.ArticlesService.Models;
using OnlineShop.Lib.Serveces.OrdersService.Models;

namespace OnlineShop.ApiService.AppStart.ConfigureServices
{
    public static class ConfigureServicesClient
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient<UsersClient>();
            services.AddHttpClient<RolesClient>();
            services.AddHttpClient<IdentityServerClient>();
            services.AddHttpClient<ArticlesClient>();
            services.AddHttpClient<PriceListClient>();
            services.AddHttpClient<OrderedArticle>();
            services.AddHttpClient<CategoryClient>();
            services.AddHttpClient<Order>();
        }
    }
}
