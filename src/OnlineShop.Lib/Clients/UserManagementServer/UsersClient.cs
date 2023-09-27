using OnlineShop.Lib.Constants;
using Microsoft.AspNetCore.Identity;
using OnlineShop.Lib.Requests;
using Microsoft.Extensions.Options;
using OnlineShop.Lib.Options;
using OnlineShop.Lib.Serveces.UserManagementService;
using OnlineShop.Lib.Serveces.UserManagementService.Models;

namespace OnlineShop.Lib.Clients.UserManagementServer
{
    public class UsersClient : UserManagementBaseClient, IUsersClient
    {
        public UsersClient(HttpClient client, IOptions<ServiceAdressOptions> options) : base(client, options) { }
       
        public async Task<UserManagementServiceResponse<ApplicationUser>> Get(string name)
            => await SendGetRequest<ApplicationUser>($"{UsersControllerRoutes.ControllerName}/name={name}");

        public async Task<UserManagementServiceResponse<IEnumerable<ApplicationUser>>> GetAll()
            => await SendGetRequest<IEnumerable<ApplicationUser>>($"/{UsersControllerRoutes.ControllerName}/{RepoActions.GetAll}");

        public async Task<IdentityResult> Update(ApplicationUser user)
            =>await SendPostRequest(user, $"{UsersControllerRoutes.ControllerName}/{RepoActions.Update}");

        public async Task<IdentityResult> Add(CreateUserRequest request)
            => await SendPostRequest(request, $"{UsersControllerRoutes.ControllerName}/{RepoActions.Add}");
        
        public async Task<IdentityResult> ChangePassword(UserPasswordChangeRequest request)
            => await SendPostRequest(request, $"{UsersControllerRoutes.ControllerName}/{UsersControllerRoutes.ChangePassword}");
        
        public async Task<IdentityResult> Remove(ApplicationUser user)
            => await SendPostRequest(user, $"{UsersControllerRoutes.ControllerName}/{RepoActions.Remove}");

        public async Task<IdentityResult> AddRole(AddRemoveRoleRequest request)
            => await SendPostRequest(request, $"{UsersControllerRoutes.ControllerName}/{UsersControllerRoutes.AddToRole}");
        
        public async Task<IdentityResult> AddToRoles(AddRemoveRolesRequest request)
            => await SendPostRequest(request, $"{UsersControllerRoutes.ControllerName}/{UsersControllerRoutes.AddToRoles}");
       
        public async Task<IdentityResult> RemoveFromRole(AddRemoveRoleRequest request)
            => await SendPostRequest(request, $"{UsersControllerRoutes.ControllerName}/{UsersControllerRoutes.RemoveFromRole}");
        
        public async Task<IdentityResult> RemoveFromRoles(AddRemoveRolesRequest request)
            => await SendPostRequest(request, $"{UsersControllerRoutes.ControllerName}/{UsersControllerRoutes.RemoveFromRoles}");
    }
}
