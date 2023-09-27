using OnlineShop.Lib.Serveces.UserManagementService.Models;

namespace OnlineShop.Lib.Requests
{
    public class CreateUserRequest
    {
        public ApplicationUser User { get; set; }

        public string Password { get; set; }
    }
}
