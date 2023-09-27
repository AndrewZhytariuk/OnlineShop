using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using OnlineShop.Lib.Options;
using OnlineShop.Lib.Serveces.IdentityServer;

namespace OnlineShop.Lib.Clients.IdentityServer
{
    public class IdentityServerClient : IIdentityServerClient
    {
        public HttpClient httpClient { get; set; }
        public IdentityServerClient(HttpClient client, IOptions<ServiceAdressOptions> options) 
        {
            httpClient = client;
            httpClient.BaseAddress = new Uri(options.Value.IdentityServer);
        }

        public async Task<Token> GetApiToken(IdentityServerApiOptions options)
        {
            List<KeyValuePair<string, string>> keyValues = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("scope", options.Scope),
                new KeyValuePair<string, string>("client_secret", options.ClientSecret),
                new KeyValuePair<string, string>("grant_type", options.GrantType),
                new KeyValuePair<string, string>("client_id", options.CliendId)
            };

            var content = new FormUrlEncodedContent(keyValues);
            var response = await httpClient.PostAsync("/connect/token", content);
            var responeContent = await response.Content.ReadAsStringAsync();

            var token = JsonConvert.DeserializeObject<Token>(responeContent);

            return token;
        }
    }
}
