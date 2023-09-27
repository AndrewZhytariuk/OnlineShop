using Microsoft.EntityFrameworkCore;
using OnlineShop.CategoryData.DbContexts;
using OnlineShop.CategoryData.Repository;
using OnlineShop.CategoryData.Models;
using OnlineShop.CategoryData.Repository.Base.Interfaces;

namespace OnlineShop.ItemsManagerService.AppStart.ConfigureServices
{
    public class ConfigureServicesBase
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
           services.AddDbContext<ItemsDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString(Lib.Constants.ConnectionName.CategoryConnection)));

            //services.AddTransient<ItemsRepository>();
            //services.Scan(scan => scan
            //    .FromAssemblyOf<ItemsRepository>()
            //    .AddClasses(classes => classes.AssignableTo(typeof(CategoryData.Repository.Base.Interfaces.IRepos<>))).AsImplementedInterfaces().WithSingletonLifetime()
            //);
        }
    }
}
 