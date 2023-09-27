namespace OnlineShop.ItemsManagerService.AppStart.Configures
{
    public static class ConfigureCommon
    {
        public static void Configure(IApplicationBuilder app)
        {
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
           // app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();//.RequireAuthorization("ApiScope");
            });

        }
    }
}
