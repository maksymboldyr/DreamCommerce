using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Interfaces;
using BusinessLogic.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using API.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UsersController> _logger;

        public UsersController(IUserService userService, ILogger<UsersController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginDTO model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid payload");
                var success = await _userService.CheckUserPasswordAsync(model);
                if (success)
                {
                    var token = await _userService.GetTokenByEmailAddressAsync(model.Email);
                    var response = new LoginResponseDTO { Token = token };
                    return Ok(response);
                }
                return BadRequest("Invalid credentials");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegistrationDTO model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid payload");
                var success = await _userService.CreateUserAsync(model);
                if (success)
                {
                    return Ok("User created successfully");
                }
                return BadRequest("User already exists");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetUser(string id)
        {
            try
            {
                var user = await _userService.GetUserByIdAsync(id);
                return Ok(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("get-users")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<TableViewModel<UserDTO>>> GetUsers([FromQuery] int page = 1, [FromQuery] int pageSize = 10, [FromQuery] string sortField = "id", [FromQuery] string sortOrder = "asc")
        {
            try
            {
                var usersWithCount = await _userService.GetUsersAsync(page, pageSize, sortField, sortOrder);

                var tableViewModel = new TableViewModel<UserDTO>
                {
                    Data = usersWithCount.Item1,
                    TotalCount = usersWithCount.Item2
                };
                return Ok(tableViewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("get-roles")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetRoles()
        {
            try
            {
                var roles = await _userService.GetRolesAsync();
                return Ok(roles);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("get-role-names")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetRoleNames()
        {
            try
            {
                var roles = await _userService.GetRolesNamesAsync();
                return Ok(roles);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("update-user")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateUser(UserDTO user)
        {
            try
            {
                var success = await _userService.UpdateUserAsync(user);
                if (success)
                {
                    return Ok("User updated successfully");
                }
                return BadRequest("User not updated");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("set-user-role")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> SetUserRole([FromBody] EditUserRolesDTO setRoleDTO)
        {
            try
            {
                var success = await _userService.SetUserRole(setRoleDTO);
                if (success)
                {
                    return Ok("Role set successfully");
                }
                return BadRequest("Role not set");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        
        [HttpPut]
        [Route("remove-user-role")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RemoveUserRole([FromBody] EditUserRolesDTO removeRoleDTO)
        {
            try
            {
                var success = await _userService.RemoveRole(removeRoleDTO);
                if (success)
                {
                    return Ok("Role removed successfully");
                }
                return BadRequest("Role not removed");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
