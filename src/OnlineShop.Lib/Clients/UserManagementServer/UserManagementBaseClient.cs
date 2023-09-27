using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using OnlineShop.Lib.Options;
using OnlineShop.Lib.Serveces.UserManagementService;
using OnlineShop.Lib.Serveces.UserManagementService.Responses;
using System.Text;

namespace OnlineShop.Lib.Clients.UserManagementServer
{
    public abstract class UserManagementBaseClient : IDisposable, IHttpClientContainer
    {
        public HttpClient HttpClient { get; set; }

        public UserManagementBaseClient(HttpClient client, IOptions<ServiceAdressOptions> options)
        {
            HttpClient = client;
            HttpClient.BaseAddress = new Uri(options.Value.UserManagementServer);
        }

        protected async Task<IdentityResult> SendPostRequest<TRequest>(TRequest request, string path)
        {
            var jsonContent = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var requestResult = await HttpClient.PostAsync(path, httpContent);

            IdentityResult result;

            if (requestResult.IsSuccessStatusCode)
            {
                var responseJson = await requestResult.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<IdentityResultDto>(responseJson);
                result = HandlerResponse(response);
            }
            else
            {
                result = IdentityResult.Failed(
                    new IdentityError()
                    {
                        Code = requestResult.StatusCode.ToString(),
                        Description = requestResult.ReasonPhrase
                    }
                );
            }

            return result;
        } 

        protected async Task<UserManagementServiceResponse<TResalt>> SendGetRequest<TResalt>(string request)
        {
            var requestResult = await HttpClient.GetAsync(request);

            UserManagementServiceResponse<TResalt> result;

            if (requestResult.IsSuccessStatusCode)
            {
                var response = await requestResult.Content.ReadAsStringAsync();
                if (string.IsNullOrEmpty(response))
                {
                    result = new UserManagementServiceResponse<TResalt>()
                    {
                        Code = requestResult.StatusCode.ToString(),
                        Description = requestResult.ReasonPhrase
                    };
                }
                else
                {
                    var payload = JsonConvert.DeserializeObject<TResalt>(response);
                    result = new UserManagementServiceResponse<TResalt>()
                    {
                        Code = requestResult.StatusCode.ToString(),
                        Description = requestResult.ReasonPhrase,
                        Payload = payload
                    };
                }
            }
            else
            {
                result = new UserManagementServiceResponse<TResalt>()
                {
                    Code = requestResult.StatusCode.ToString(),
                    Description = requestResult.ReasonPhrase
                };
            }

            return result;
        }

        public IdentityResult HandlerResponse(IdentityResultDto response)
        {
            if (response.Succeeded)
                return IdentityResult.Success;

            return IdentityResult.Failed(response.Errors.ToArray());
        }

        public void Dispose()
        {
            HttpClient.Dispose();
        }
    }
}
