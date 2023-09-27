using OnlineShop.Lib.Migrations;
using OnlineShop.Lib.Repositories;
using OnlineShop.Lib.Serveces.ArticlesService.Models;

namespace OnlineShop.Lib.Serveces.OrdersService.Repo
{
    public class OrdersArticlesRepo : BaseRepo<OrderedArticle>
    {
        public OrdersArticlesRepo(OrdersDbContext context) : base(context)
        {
            Table = context.OrderedArticles;
        }
    }
}
