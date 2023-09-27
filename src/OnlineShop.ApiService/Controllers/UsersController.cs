using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.ApiService.Authorization;
using OnlineShop.Lib.Clients.UserManagementServer;
using OnlineShop.Lib.Constants;
using OnlineShop.Lib.Requests;
using OnlineShop.Lib.Serveces.UserManagementService.Models;

namespace OnlineShop.ApiService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class UsersController : ControllerWithClientAuthorization<IUsersClient>
    {
        public UsersController(IUsersClient usersClient, IClientAuthorization clientAuthorization) : base(usersClient, clientAuthorization) { }

        [HttpPost(RepoActions.Add)]
        public async Task<IdentityResult> Add(CreateUserRequest request)
        {
            var result = await Client.Add(request);
            return result;
        }

        [HttpPost(RepoActions.Update)]
        public async Task<IdentityResult> Update(ApplicationUser user)
        {

            var result = await Client.Update(user);

            return result;
        }

        [HttpPost(RepoActions.Remove)]
        public async Task<IdentityResult> Remove(ApplicationUser user)
        {
            var result = await Client.Remove(user);

            return result;
        }

        [HttpGet]
        public async Task<ApplicationUser> Get(string name)
        {
            var result =  await Client.Get(name);

            return result.Payload;
        }

        [HttpGet(RepoActions.GetAll)]
        public async Task<IEnumerable<ApplicationUser>> Get()
        {
            var result = await Client.GetAll();

            return result.Payload;
        }

        [HttpPost(UsersControllerRoutes.ChangePassword)]
        public async Task<IdentityResult> ChangePassword(UserPasswordChangeRequest request)
        {

            var result = await Client.ChangePassword(request);

            return result;
        }

        [HttpPost(UsersControllerRoutes.AddToRole)]
        public async Task<IdentityResult> AddRole(AddRemoveRoleRequest request)
        {
            var result = await Client.AddRole(request);

            return result;
        }

        [HttpPost(UsersControllerRoutes.AddToRoles)]
        public async Task<IdentityResult> AddToRoles(AddRemoveRolesRequest request)
        {
            var result = await Client.AddToRoles(request);

            return result;
        }


        [HttpPost(UsersControllerRoutes.RemoveFromRole)]
        public async Task<IdentityResult> RemoveFromRole(AddRemoveRoleRequest request)
        {
            var result = await Client.RemoveFromRole(request);

            return result;
        }

        [HttpPost(UsersControllerRoutes.RemoveFromRoles)]
        public async Task<IdentityResult> RemoveFromRoles(AddRemoveRolesRequest request)
        {
            var result = await Client.RemoveFromRoles(request);

            return result;
        }
    }
}
