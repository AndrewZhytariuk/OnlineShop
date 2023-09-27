using OnlineShop.Lib.Options;
using OnlineShop.Lib.Serveces.UserManagementService.Models;
using OnlineShop.Library.Common.Models;

namespace OnlineShop.Library.Clients.UserManagementService
{
    public interface ILoginClient
    {
        Task<UserManagementServiceToken> GetApiTokenByClientSeceret(IdentityServerApiOptions options);

        Task<UserManagementServiceToken> GetApiTokenByUsernameAndPassword(IdentityServerUserNamePassword options);
    }
}
