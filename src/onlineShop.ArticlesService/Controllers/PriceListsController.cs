using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Lib.Repositories;
using OnlineShop.Lib.Repositories.Interfaces;
using OnlineShop.Lib.Serveces.ArticlesService.Models;

namespace OnlineShop.ArticlesService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class PriceListsController : RepoControllerBase<PriceList>
    {
        public PriceListsController(IRepos<PriceList> repos, ILogger<PriceList> logger): base(repos, logger) { }

        protected override void UpdateProperties(PriceList scope, PriceList destination)
        {
            destination.Name = scope.Name;
            destination.Price = scope.Price;
            destination.ValidForm = scope.ValidForm;
            destination.ValidTo = scope.ValidTo;
        }
    }
}
