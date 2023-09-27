using OnlineShop.Lib.Migrations;
using OnlineShop.Lib.Repositories;
using OnlineShop.Lib.Serveces.ArticlesService.Models;

namespace OnlineShop.Lib.Serveces.ArticlesService.Repo
{
    public class PriceListsRepo : BaseRepo<PriceList>
    {
        public PriceListsRepo(OrdersDbContext context) : base(context)
        {
            Table = Context.PriceList;
        }
    }
}
