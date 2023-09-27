using OnlineShop.CategoryData.DbContexts;
using OnlineShop.CategoryData.Models;
using OnlineShop.CategoryData.Repository.Base;

namespace OnlineShop.CategoryData.Repository
{
    public class ItemsRepository : BaseRepo<Item>
    {
        public ItemsRepository(ItemsDbContext context) : base(context)
        {
            Table = Context.Items;
        }

        //public override async Task<Article> GetOneAsync(Guid id)
        //    => await Task.Run(() => Table.Include(nameof(Article.PriceLists))
        //    .FirstOrDefault(entity => entity.Id == id));

        //public override async Task<IEnumerable<Article>> GetAllAsync()
        //    => await Table.Include(nameof(Article.PriceLists)).ToListAsync();
    }
}
