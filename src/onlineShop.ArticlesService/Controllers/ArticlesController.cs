using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OnlineShop.Lib.Repositories;
using OnlineShop.Lib.Repositories.Interfaces;
using OnlineShop.Lib.Serveces.ArticlesService.Models;

namespace OnlineShop.ArticlesService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [AllowAnonymous]
    //[Authorize(AuthenticationSchemes = "Bearer")]
    public class ArticlesController : RepoControllerBase<Article>
    {
        public ArticlesController(IRepos<Article> articlesRepo, ILogger<Article> logger): base(articlesRepo, logger) { }

        protected override void UpdateProperties(Article scope, Article destination)
        {
            destination.Name = scope.Name;
            destination.Description = scope.Description;
        }
    }
}
