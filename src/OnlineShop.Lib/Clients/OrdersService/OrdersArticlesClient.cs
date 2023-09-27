using Microsoft.Extensions.Options;
using OnlineShop.Lib.Options;
using OnlineShop.Lib.Serveces.ArticlesService.Models;

namespace OnlineShop.Lib.Clients.OrdersService
{
    public class OrdersArticlesClient : RepoClientBase<OrderedArticle>
    {
        public OrdersArticlesClient (HttpClient client, IOptions<ServiceAdressOptions> options) :base(client, options) { }
        protected override void InitializeClient(IOptions<ServiceAdressOptions> options)
        {
            HttpClient.BaseAddress = new Uri(options.Value.ArticleService);
        }

        protected override void InitializizeClient()
        {
            ControllerName = "OrdersArticles";
        }
    }
}
