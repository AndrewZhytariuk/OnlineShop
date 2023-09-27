using Microsoft.Extensions.Options;
using OnlineShop.Lib.Options;
using OnlineShop.Lib.Serveces.ArticlesService.Models;

namespace OnlineShop.Lib.Clients.ArticlesService
{
    public class ArticlesClient : RepoClientBase<Article>
    {
        public ArticlesClient(HttpClient client, IOptions<ServiceAdressOptions> options) : base(client, options) { }

        protected override void InitializeClient(IOptions<ServiceAdressOptions> options)
        {
            HttpClient.BaseAddress = new Uri(options.Value.ArticleService);
        }

        protected override void InitializizeClient()
        {
            ControllerName = "Articles";
        }
    }
}
