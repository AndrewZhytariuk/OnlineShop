using Microsoft.AspNetCore.Authorization;
using OnlineShop.CategoryData.Models;
using Microsoft.AspNetCore.Mvc; 
using OnlineShop.ItemsManagerService.Services.Interfaces;
using OnlineShop.Lib.Constants;

namespace OnlineShop.ItemsManagerService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [AllowAnonymous]
    public class CategoryController : ControllerBase
    {
        private readonly IServeces<Item> serveces;
        public CategoryController(IServeces<Item> itemService)
        {
            serveces = itemService;
        }

        [HttpGet(RepoActions.GetAll)]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
             var result = await serveces.GetAllAsync();

            return Ok(result);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetOne(Guid id)
        {
            var result = await serveces.GetOneAsync(id);

            return Ok(result);
        }
    }
}
