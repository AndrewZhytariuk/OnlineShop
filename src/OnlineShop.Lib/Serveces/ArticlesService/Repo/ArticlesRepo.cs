using Microsoft.EntityFrameworkCore;
using OnlineShop.Lib.Migrations;
using OnlineShop.Lib.Repositories;
using OnlineShop.Lib.Serveces.ArticlesService.Models;

namespace OnlineShop.Lib.Serveces.ArticlesService.Repo
{
    public class ArticlesRepo : BaseRepo<Article>
    {
        public ArticlesRepo(OrdersDbContext context) : base(context)
        {
            Table = Context.Articles;
        }

        //public override async Task<Article> GetOneAsync(Guid id)
        //    => await Task.Run(() => Table.Include(nameof(Article.PriceLists))
        //    .FirstOrDefault(entity => entity.Id == id));

        //public override async Task<IEnumerable<Article>> GetAllAsync()
        //    => await Table.Include(nameof(Article.PriceLists)).ToListAsync();
    }
}
