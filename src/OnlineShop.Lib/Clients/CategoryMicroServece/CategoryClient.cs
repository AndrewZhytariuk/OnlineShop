using Microsoft.Extensions.Options;
using OnlineShop.CategoryData.Models;
using OnlineShop.Lib.Options;

namespace OnlineShop.Lib.Clients.CategoryMicroServece
{
    public class CategoryClient : RepoClientBase<Item>
    {
        public CategoryClient(HttpClient client, IOptions<ServiceAdressOptions> options) : base(client, options) { }
        protected override void InitializeClient(IOptions<ServiceAdressOptions> options)
        {
            HttpClient.BaseAddress = new Uri(options.Value.CategoryService);
        }

        protected override void InitializizeClient()
        {
            ControllerName = "Category";
        }
    }
}
