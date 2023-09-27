using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Lib.Requests;
using OnlineShop.Lib.Constants;
using OnlineShop.Lib.Logging;
using OnlineShop.Lib.Serveces.UserManagementService.Models;

namespace OnlineShop.UserManagementService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<UsersController> _logger;

        public UsersController(UserManager<ApplicationUser> userManager, ILogger<UsersController> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }

        [HttpPost(RepoActions.Add)]
        public async Task<IActionResult> Add(CreateUserRequest request)
        {
            try
            {
                var result = await _userManager.CreateAsync(request.User, request.Password);

                return Ok(result);
            } 
            catch (Exception ex)
            {
                _logger.LogError(new LogEntry()
                    .WithClass(nameof(UsersController))
                    .WithMethod(nameof(RepoActions.Add))
                    .WithComment(ex.ToString())
                    .WithParameters($"{nameof(request.User.Id)}: {request.User.Id}")
                    .ToString()
                    );

                return StatusCode(500, LoggingConstans.InternalServerErrorMessage);
            }
        }

        [HttpPost(RepoActions.Update)]
        public async Task<IActionResult> Update(ApplicationUser user)
        {
            try
            {
                var userForUpdate = await _userManager.FindByNameAsync(user.UserName);

                if (userForUpdate == null)
                    return BadRequest(IdentityResult.Failed(new IdentityError() { Description = $"User: {user.UserName} was not found." }));

                userForUpdate.DefaultAddress = user.DefaultAddress;
                userForUpdate.DeliveryAddress = user.DeliveryAddress;
                userForUpdate.FirstName = user.FirstName;
                userForUpdate.LastName = user.LastName;
                userForUpdate.PhoneNumber = user.PhoneNumber;
                userForUpdate.Email = user.Email;

                var result = await _userManager.UpdateAsync(userForUpdate);

                return Ok(result);
            } 
            catch(Exception ex)
            {
                _logger.LogError(new LogEntry()
                    .WithClass(nameof(UsersController))
                    .WithMethod(nameof(RepoActions.Update))
                    .WithComment(ex.ToString())
                    .WithParameters($"{nameof(user.Id)}: {user.Id}")
                    .ToString()
                    );

                return StatusCode(500, LoggingConstans.InternalServerErrorMessage);
            }
        }

        [HttpPost(RepoActions.Remove)]
        public async Task<IActionResult> Remove(ApplicationUser user)
        {
            try
            {
                var result = await _userManager.DeleteAsync(user);

                return Ok(result);
            }
            catch(Exception ex)
            {
                _logger.LogError(new LogEntry()
                    .WithClass(nameof(UsersController))
                    .WithMethod(nameof(RepoActions.Remove))
                    .WithComment(ex.ToString())
                    .WithParameters($"{nameof(user.Id)}: {user.Id}")
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
                var result = _userManager.Users
                    //.Include(u => u.DefaultAddress)
                    //.Include(u => u.DeliveryAddress)
                    .FirstOrDefault(u => u.UserName == name);

                return Ok(result);
            }
            catch(Exception ex)
            {
                _logger.LogError(new LogEntry()
                    .WithClass(nameof(UsersController))
                    .WithMethod(nameof(Get))
                    .WithComment(ex.ToString())
                    .WithParameters($"{nameof(name)}: {name}")
                    .ToString()
                );

                return StatusCode(500, LoggingConstans.InternalServerErrorMessage);
            }
        }

        [HttpGet(RepoActions.GetAll)]
        public IActionResult Get()
        {
            try
            {
                var result = _userManager.Users
                   // .Include(u => u.DefaultAddress)
                   // .Include(u => u.DeliveryAddress)
                    .AsEnumerable();

                return Ok(result);
            }
            catch(Exception ex) 
            {
                _logger.LogError(new LogEntry()
                    .WithClass(nameof(UsersController))
                    .WithMethod(nameof(RepoActions.GetAll))
                    .WithComment(ex.ToString())
                    .WithParameters((LoggingConstants.NoParameters))
                    .ToString()
                    );

                return StatusCode(500, LoggingConstans.InternalServerErrorMessage);
            }
        }

        [HttpPost(UsersControllerRoutes.ChangePassword)]
        public async Task<IActionResult> ChangePassword(UserPasswordChangeRequest request)
        {
            try
            {

                var user = await _userManager.FindByNameAsync(request.UserName);

                if (user == null)
                    return BadRequest(IdentityResult.Failed(new IdentityError() { Description = $"User: {user.UserName} was not found." }));

                var result = await _userManager.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);

                return Ok(result);
            }
            catch(Exception ex)
            {
                _logger.LogError(new LogEntry()
                    .WithClass(nameof(UsersController))
                    .WithMethod(nameof(ChangePassword))
                    .WithComment(ex.ToString())
                    .WithParameters($"{nameof(request.UserName)}: {request.UserName}")
                    .ToString()
                );

                return StatusCode(500, LoggingConstans.InternalServerErrorMessage);
            }
        }

        [HttpPost(UsersControllerRoutes.AddToRole)]
        public async Task<IActionResult> AddRole(AddRemoveRoleRequest request)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(request.UserName);

                if (user == null)
                    return BadRequest(IdentityResult.Failed(new IdentityError() { Description = $"User: {user.UserName} was not found." }));

                var result = await _userManager.AddToRoleAsync(user, request.RoleName);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(new LogEntry()
                    .WithClass(nameof(UsersController))
                    .WithMethod(nameof(UsersControllerRoutes.AddToRole))
                    .WithComment(ex.ToString())
                    .WithParameters($"{nameof(request.UserName)}: {request.UserName}")
                    .ToString()
                    ) ;

                return StatusCode(500, LoggingConstans.InternalServerErrorMessage);
            }
        }

        [HttpPost(UsersControllerRoutes.AddToRoles)]
        public async Task<IActionResult> AddToRoles(AddRemoveRolesRequest request)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(request.UserName);

                if (user == null)
                    return BadRequest(IdentityResult.Failed(new IdentityError() { Description = $"User: {user.UserName} was not found." }));

                var result = await _userManager.AddToRolesAsync(user, request.RoleNames);

                return Ok(result);
            }
            catch (Exception ex) 
            {
                _logger.LogError(new LogEntry()
                    .WithClass(nameof(UsersController))
                    .WithMethod(nameof(UsersControllerRoutes.AddToRoles))
                    .WithComment(ex.ToString())
                    .WithParameters($"{nameof(request.UserName)}: {request.UserName}")
                    .ToString()
                );

                return StatusCode(500, LoggingConstans.InternalServerErrorMessage);
            }
        }


        [HttpPost(UsersControllerRoutes.RemoveFromRole)]
        public async Task<IActionResult> RemoveFromRole(AddRemoveRoleRequest request)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(request.UserName);

                if (user == null)
                    return BadRequest(IdentityResult.Failed(new IdentityError() { Description = $"User: {user.UserName} was not found." }));

                var result = await _userManager.RemoveFromRoleAsync(user, request.RoleName);

                return Ok(result);
            }
            catch(Exception ex)
            {
                _logger.LogError(new LogEntry()
                    .WithClass(nameof(UsersController))
                    .WithMethod(nameof(UsersControllerRoutes.RemoveFromRole))
                    .WithComment(ex.ToString())
                    .WithParameters($"{nameof(request.UserName)}: {request.UserName}")
                    .ToString()
                );

                return StatusCode(500, LoggingConstans.InternalServerErrorMessage);
            }
        }

        [HttpPost(UsersControllerRoutes.RemoveFromRoles)]
        public async Task<IActionResult> RemoveFromRoles(AddRemoveRolesRequest request)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(request.UserName);

                if (user == null)
                    return BadRequest(IdentityResult.Failed(new IdentityError() { Description = $"User: {user.UserName} was not found." }));

                var result = await _userManager.RemoveFromRolesAsync(user, request.RoleNames);

                return Ok(result);
            }
            catch(Exception ex)
            {
                _logger.LogError(new LogEntry()
                    .WithClass(nameof(UsersController))
                    .WithMethod(nameof(UsersControllerRoutes.RemoveFromRoles))
                    .WithComment(ex.ToString())
                    .WithParameters($"{nameof(request.UserName)}: {request.UserName}")
                    .ToString()
                );

                return StatusCode(500, LoggingConstans.InternalServerErrorMessage);
            }
        }
    }
}
