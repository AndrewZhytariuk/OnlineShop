using OnlineShop.Lib.Clients;

namespace OnlineShop.ApiService.Authorization
{
    public interface IClientAuthorization
    {
        Task Authorize(IHttpClientContainer clientContainer);
    }
}
