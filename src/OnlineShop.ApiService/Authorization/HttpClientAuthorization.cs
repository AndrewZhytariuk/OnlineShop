using Microsoft.Extensions.Options;
using OnlineShop.Lib.Clients;
using OnlineShop.Lib.Clients.IdentityServer;
using OnlineShop.Lib.Options;
using IdentityModel.Client;

namespace OnlineShop.ApiService.Authorization
{
    public class HttpClientAuthorization : IClientAuthorization
    {
        private readonly IIdentityServerClient _identityServerClient;
        private readonly IdentityServerApiOptions _identityServerApiOptions;

        public HttpClientAuthorization(
         IIdentityServerClient identityServerClient,
         IOptions<IdentityServerApiOptions> options)
        {
            _identityServerClient = identityServerClient;
            _identityServerApiOptions = options.Value;
        }

        public async Task Authorize(IHttpClientContainer clientContainer)
        {
            if (clientContainer == null)
                return;

            var token = await _identityServerClient.GetApiToken(_identityServerApiOptions);
            clientContainer.HttpClient.SetBearerToken(token.AccessToken);
        }
    }
}
