using OnlineShop.CategoryData.DbContexts;
using OnlineShop.CategoryData.Models;
using OnlineShop.CategoryData.Repository.Base;

namespace OnlineShop.CategoryData.Repository
{
    public class ImageProductRepository : BaseRepo<ImageProduct>
    {
        public ImageProductRepository(ItemsDbContext context) : base(context)
        {
            Table = Context.ImageProduct;
        }
    }
}
