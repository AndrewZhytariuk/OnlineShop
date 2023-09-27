namespace OnlineShop.ApiService.AppStart.ConfigureServices
{
    public static class ConfigureServicesCors
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors(option =>
                    {
                        option.AddDefaultPolicy(policyBuilder =>
                        {
                            policyBuilder.WithOrigins("https://localhost:").AllowAnyHeader().AllowAnyMethod();
                            policyBuilder.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod();
                        });
                    });
        }
    }
}
