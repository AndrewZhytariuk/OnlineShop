using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.ItemsManagerService.Kafka.Consumer;
using OnlineShop.ItemsManagerService.Services;

namespace OnlineShop.ItemsManagerService.Controllers
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
