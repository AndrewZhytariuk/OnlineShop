using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Lib.Requests;
using OnlineShop.Library.Clients.UserManagementService;
using OnlineShop.Library.Common.Models;

namespace OnlineShop.ApiService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [AllowAnonymous]
    public class LoginController : ControllerBase
    {
        protected ILoginClient LoginClient;

        public LoginController(ILoginClient loginClient)
        {
            LoginClient = loginClient;
        }

        [AllowAnonymous]
        [HttpPost("")]
        public async  Task<IActionResult> LoginByUSerNameAndPassword([FromBody] LoginRequest request)
        {
            var option = new IdentityServerUserNamePassword()
            {
               UserName = request.UserName,
               Password = request.Password
            };

            var token = await LoginClient.GetApiTokenByUsernameAndPassword(option);
            return Ok(token);
        }

    }
}
