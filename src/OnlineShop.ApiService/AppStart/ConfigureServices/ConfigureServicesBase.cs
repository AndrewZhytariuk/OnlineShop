using OnlineShop.Lib.Options;

namespace OnlineShop.ApiService.AppStart.ConfigureServices
{
    public static class ConfigureServicesBase
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<IdentityServerApiOptions>(configuration.GetSection(IdentityServerApiOptions.SectionName));
            services.Configure<ServiceAdressOptions>(configuration.GetSection(ServiceAdressOptions.SectionName));
        }
    }
}
