using OnlineShop.Lib.Constants;

namespace OnlineShop.ApiService.AppStart.ConfigureServices
{
    public static class ConfigureServicesAuthorization
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthorization(options =>
                    {
                        options.AddPolicy("ApiScope", policy =>
                        {
                            policy.RequireAuthenticatedUser();
                            policy.RequireClaim("scope", IdConstants.WebScope);
                        });
                    });
        }
    }
}
