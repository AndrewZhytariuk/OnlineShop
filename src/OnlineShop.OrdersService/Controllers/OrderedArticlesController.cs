using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Lib.Repositories;
using OnlineShop.Lib.Repositories.Interfaces;
using OnlineShop.Lib.Serveces.ArticlesService.Models;

namespace OnlineShop.OrdersService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class OrderedArticlesController : RepoControllerBase<OrderedArticle>
    {
        public OrderedArticlesController(IRepos<OrderedArticle> repos, ILogger<OrderedArticle> loger) : base(repos, loger) { }

        protected override void UpdateProperties(OrderedArticle scope, OrderedArticle destination)
        {
            destination.Name = scope.Name;
            destination.Description = scope.Description;

            if (destination.Price != scope.Price)
            {
                destination.PriceListName = "Manualy assigned";
            }

            destination.Price = scope.Price;
            destination.Quantity = scope.Quantity;
        }
    }
}
