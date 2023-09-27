using OnlineShop.CategoryData.DbContexts;
using OnlineShop.CategoryData.Models;
using OnlineShop.CategoryData.Repository.Base;

namespace OnlineShop.CategoryData.Repository
{
    public class ProductRepository : BaseRepo<Product>
    {
        public ProductRepository(ItemsDbContext context) : base(context)
        {
            Table = Context.Products;
        }
    }
}
