using OnlineShop.CategoryData.DbContexts;
using OnlineShop.CategoryData.Models;
using OnlineShop.CategoryData.Repository.Base;

namespace OnlineShop.CategoryData.Repository
{
    public class PriceRepository : BaseRepo<Price>
    {
        public PriceRepository(ItemsDbContext context) : base(context)
        {
            Table = Context.Prices;
        }
    }
}
