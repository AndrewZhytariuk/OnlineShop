using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShop.OrdersService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [AllowAnonymous]
    public class HealthChekerController : ControllerBase
    {
        [HttpGet]
        public string Checked() => "Service is online";
    }
}
