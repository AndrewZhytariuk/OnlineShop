using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.ApiService.Authorization;
using OnlineShop.Lib.Clients;
using OnlineShop.Lib.Constants;
using OnlineShop.Lib.Serveces.ArticlesService.Models;

namespace OnlineShop.ApiService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class OrderedArticlesController : ControllerWithClientAuthorization<IRepoClient<OrderedArticle>>
    {
        public OrderedArticlesController(IRepoClient<OrderedArticle> client, IClientAuthorization clientAuthorization) : base(client, clientAuthorization) { }

        [HttpPost(RepoActions.Add)]
        public async Task<IActionResult> Add([FromBody] OrderedArticle entity)
        {
            var articleId = await Client.Add(entity);
            return Ok(articleId);
        }

        [HttpPost(RepoActions.AddRange)]
        public async Task<IActionResult> Add([FromBody] IEnumerable<OrderedArticle> entitis)
        {

            var articleIds = await Client.AddRange(entitis);

            return Ok(articleIds);
        }

        [HttpGet]
        public async Task<IActionResult> GetOne(Guid id)
        {
            var article = await Client.GetOne(id);

            return Ok(article);
        }

        [HttpGet(RepoActions.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var article = await Client.GetAll();

            return Ok(article);
        }

        [HttpPost(RepoActions.Update)]
        public async Task<IActionResult> Update([FromBody] OrderedArticle entry)
        {
            var result  = await Client.Update(entry);

            return Ok(result);
        }

        [HttpPost(RepoActions.Remove)]
        public async Task<IActionResult> Remove([FromBody] Guid id)
        {
            await Client.Remove(id);

            return NoContent();
        }

        [HttpPost(RepoActions.RemoveRange)]
        public async Task<IActionResult> Remove([FromBody] IEnumerable<Guid> guids)
        {
            await Client.RemoveRange(guids);

            return NoContent();
        }

    }
}
