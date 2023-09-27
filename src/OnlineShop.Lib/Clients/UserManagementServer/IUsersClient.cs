using Microsoft.AspNetCore.Identity;
using OnlineShop.Lib.Requests;
using OnlineShop.Lib.Serveces.UserManagementService;
using OnlineShop.Lib.Serveces.UserManagementService.Models;

namespace OnlineShop.Lib.Clients.UserManagementServer
{
    public interface IUsersClient
    {
        Task<UserManagementServiceResponse<ApplicationUser>> Get(string name);
        Task<UserManagementServiceResponse<IEnumerable<ApplicationUser>>> GetAll();
        Task<IdentityResult> Update(ApplicationUser user);
        Task<IdentityResult> Add(CreateUserRequest request);
        Task<IdentityResult> ChangePassword(UserPasswordChangeRequest request);
        Task<IdentityResult> Remove(ApplicationUser user);
        Task<IdentityResult> AddRole(AddRemoveRoleRequest request);
        Task<IdentityResult> AddToRoles(AddRemoveRolesRequest request);
        Task<IdentityResult> RemoveFromRole(AddRemoveRoleRequest request);
        Task<IdentityResult> RemoveFromRoles(AddRemoveRolesRequest request);
    }
}
