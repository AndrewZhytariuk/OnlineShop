
namespace OnlineShop.ApiService.AppStart.Configures
{
    public static class ConfigureCommon
    {
        public static void Configure(IApplicationBuilder app)
        {
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();//.RequireAuthorization("ApiScope");
            });
        }
    }
}
