using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using OnlineShop.Lib.Constants;
using OnlineShop.Lib.Logging;

namespace OnlineShop.UserManagementService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class RolesController: ControllerBase
    {
        private readonly RoleManager<IdentityRole> _rolerManager;
        private readonly ILogger<RolesController> _logger;
        public RolesController(RoleManager<IdentityRole> rolerManager, ILogger<RolesController> logger)
        {
            _rolerManager = rolerManager;
            _logger = logger;
        }

        [HttpPost(RepoActions.Add)]
        public async Task<IActionResult> Add(IdentityRole role)
        {
            try
            {
                var result = await _rolerManager.CreateAsync(role);

                return Ok(result);
            } 
            catch (Exception ex) 
            {
                _logger.LogError(new LogEntry()
                    .WithClass(nameof(RolesController))
                    .WithMethod(nameof(RepoActions.Add))
                    .WithOperation(ex.ToString())
                    .WithParameters($"{nameof(role.Id)}: {role.Id}")
                    .ToString()
                    );

                return StatusCode(500, LoggingConstans.InternalServerErrorMessage);
            }
        }

        [HttpPost(RepoActions.Update)]
        public async Task<IActionResult> Update(IdentityRole role)
        {
            try
            {
                var roleForUpdate = await _rolerManager.FindByIdAsync(role.Id);

                if (roleForUpdate == null)
                    return BadRequest(IdentityResult.Failed(new IdentityError() { Description = $"Role: {role.Name} was not found." }));

                roleForUpdate.Name = role.Name;
                var result = await _rolerManager.UpdateAsync(roleForUpdate);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(new LogEntry()
                    .WithClass(nameof(RolesController))
                    .WithMethod(nameof(RepoActions.Update))
                    .WithOperation(ex.ToString())
                    .WithParameters($"{nameof(role.Id)}: {role.Id}")
                    .ToString()
                    );

                return StatusCode(500, LoggingConstans.InternalServerErrorMessage);
            }
        }

        [HttpPost(RepoActions.Remove)]
        public async Task<IActionResult> Remove(IdentityRole role)
        {
            try
            {
                var result = await _rolerManager.DeleteAsync(role);

                return Ok(result);
            }
            catch(Exception ex)
            {
                _logger.LogError( new LogEntry()
                    .WithClass(nameof(RolesController))
                    .WithMethod(nameof(RepoActions.Remove))
                    .WithOperation(ex.ToString())
                    .WithParameters($"{nameof(role.Id)}: {role.Id}")
                    .ToString()
                    );

                return StatusCode(500, LoggingConstans.InternalServerErrorMessage);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get(string name)
        {
            try
            {
                var result = await _rolerManager.FindByNameAsync(name);

                return Ok(result);
            }
            catch(Exception ex)
            {
                _logger.LogError(new LogEntry()
                    .WithClass(nameof(RolesController))
                    .WithMethod(nameof(Get))
                    .WithOperation(ex.ToString())
                    .WithParameters($"{nameof(name)}: {name}")
                    .ToString()
                    );

                return StatusCode(500, LoggingConstans.InternalServerErrorMessage);
            }
        }

        [HttpGet(RepoActions.GetAll)]
        public IActionResult GetAll()
        {
            try
            {
                var result = _rolerManager.Roles.AsEnumerable();
                return Ok(result);
            }
            catch(Exception ex)
            {
                _logger.LogError(new LogEntry()
                    .WithClass(nameof(RolesController))
                    .WithMethod(nameof(RepoActions.GetAll))
                    .WithOperation(ex.ToString())
                    .WithParameters(LoggingConstants.NoParameters)
                    .ToString()
                    );

                return StatusCode(500, LoggingConstans.InternalServerErrorMessage);
            }
        }
    }
}

