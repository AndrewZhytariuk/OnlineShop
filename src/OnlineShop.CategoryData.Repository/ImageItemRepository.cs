using OnlineShop.CategoryData.DbContexts;
using OnlineShop.CategoryData.Models;
using OnlineShop.CategoryData.Repository.Base;

namespace OnlineShop.CategoryData.Repository
{
    public class ImageItemRepository : BaseRepo<ImageItem>
    {
        public ImageItemRepository(ItemsDbContext context) : base(context)
        {
            Table = Context.ImageItem;
        }
    }
}
