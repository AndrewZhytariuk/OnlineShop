using IdentityServer4.AccessTokenValidation;
using Microsoft.IdentityModel.Tokens;
using OnlineShop.Lib.Options;

namespace OnlineShop.ApiService.AppStart.ConfigureServices
{
    public static class ConfigureServicesAuthentication
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            var serviceAddressOptions = new ServiceAdressOptions();
            configuration.GetSection(ServiceAdressOptions.SectionName).Bind(serviceAddressOptions);

            services.AddAuthentication(
                IdentityServerAuthenticationDefaults.AuthenticationScheme)
                .AddJwtBearer(IdentityServerAuthenticationDefaults.AuthenticationScheme, options =>
                {
                    options.Authority = serviceAddressOptions.IdentityServer;
                    //options.ApiName = $"{serviceAddressOptions.IdentityServer}/resources";
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters() { ValidateAudience = false };
                });
        }
    }
}
