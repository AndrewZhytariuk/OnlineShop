using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShop.ArticlesService.Controller
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
