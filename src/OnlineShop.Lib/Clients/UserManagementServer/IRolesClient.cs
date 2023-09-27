using Microsoft.AspNetCore.Identity;
using OnlineShop.Lib.Serveces.UserManagementService;

namespace OnlineShop.Lib.Clients.UserManagementServer
{
    public interface IRolesClient
    {
        Task<UserManagementServiceResponse<IdentityRole>> Get(string name);
        Task<UserManagementServiceResponse<IEnumerable<IdentityRole>>> GetAll();
        Task<IdentityResult> Add(IdentityRole role);
        public Task<IdentityResult> Update(IdentityRole role);
        public Task<IdentityResult> Remove(IdentityRole role);
    }
}
