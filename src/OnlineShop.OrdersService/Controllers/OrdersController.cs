using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Lib.Repositories;
using OnlineShop.Lib.Repositories.Interfaces;
using OnlineShop.Lib.Serveces.OrdersService.Models;

namespace OnlineShop.OrdersService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class OrdersController : RepoControllerBase<Order>
    {
        public OrdersController(IRepos<Order> repos, ILogger<Order> loger) : base(repos, loger) { }
        protected override void UpdateProperties(Order scope, Order destination)
        {
            destination.AddressId = scope.AddressId;
            destination.UserId = scope.UserId;
            destination.Articles = scope.Articles;
            destination.Modified = scope.Modified;
        }
    }
}
