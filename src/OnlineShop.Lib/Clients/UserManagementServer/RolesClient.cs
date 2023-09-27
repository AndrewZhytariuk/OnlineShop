using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using OnlineShop.Lib.Constants;
using OnlineShop.Lib.Options;
using OnlineShop.Lib.Serveces.UserManagementService;

namespace OnlineShop.Lib.Clients.UserManagementServer
{
    public class RolesClient : UserManagementBaseClient, IRolesClient
    {
        public RolesClient(HttpClient client, IOptions<ServiceAdressOptions> options) : base(client, options) { }

        public async Task<UserManagementServiceResponse<IdentityRole>> Get(string name)
            => await SendGetRequest<IdentityRole>($"{RolesControllerRoutes.ControllerName}?name={name}");

        public async Task<UserManagementServiceResponse<IEnumerable<IdentityRole>>> GetAll()
            => await SendGetRequest<IEnumerable<IdentityRole>>($"{RolesControllerRoutes.ControllerName}/{RepoActions.GetAll}");

        public async Task<IdentityResult> Add(IdentityRole role)
            => await SendPostRequest(role, $"{RolesControllerRoutes.ControllerName}/{RepoActions.Add}");

        public async Task<IdentityResult> Update(IdentityRole role)
            => await SendPostRequest(role, $"{RolesControllerRoutes.ControllerName}/{RepoActions.Update}");

        public async Task<IdentityResult> Remove(IdentityRole role)
            => await SendPostRequest(role, $"{RolesControllerRoutes.ControllerName}/{RepoActions.Remove}");
    }
}
