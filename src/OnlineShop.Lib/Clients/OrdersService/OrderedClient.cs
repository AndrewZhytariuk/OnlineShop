using Microsoft.Extensions.Options;
using OnlineShop.Lib.Options;
using OnlineShop.Lib.Serveces.OrdersService.Models;

namespace OnlineShop.Lib.Clients.OrdersService
{
    public class OrderedClient : RepoClientBase<Order>
    {
        public OrderedClient (HttpClient client, IOptions<ServiceAdressOptions> options) : base(client, options) { }
        protected override void InitializeClient(IOptions<ServiceAdressOptions> options)
        {
            HttpClient.BaseAddress = new Uri(options.Value.OrdersService);
        }

        protected override void InitializizeClient()
        {
            ControllerName = "OrderedArticles";
        }
    }
}
