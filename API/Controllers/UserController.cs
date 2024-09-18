using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Interfaces;
using BusinessLogic.DTO;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        [Route("get-users")]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var users = await _userService.GetUsersAsync();
                return Ok(users);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("get-roles")]
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
        [Route("set-user-role")]
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
