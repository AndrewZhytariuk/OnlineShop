using Microsoft.AspNetCore.Identity;

namespace OnlineShop.Lib.Serveces.UserManagementService.Responses
{
    public class IdentityResultDto
    {
        public bool Succeeded { get; set; }

        public IEnumerable<IdentityError> Errors { get; set; }
    }
}
