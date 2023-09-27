using OnlineShop.CategoryData.Models;
using OnlineShop.CategoryData.Repository.Base.Interfaces;

namespace OnlineShop.ItemsManagerService.Services
{
    public class ItemService : BaseServices<Item>
    {
        public ItemService(IRepos<Item> baseRepo) : base(baseRepo) { }
    }
}
