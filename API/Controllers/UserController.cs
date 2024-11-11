using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Interfaces;
using BusinessLogic.DTO;
using Microsoft.AspNetCore.Authorization;
using API.Models;
using BusinessLogic.DTO.Auth;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class UsersController(IUserService userService, ILogger<UsersController> logger) : ControllerBase
{
    [HttpPost]
    [Route("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login(LoginDto loginDto)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid payload");
            var success = await userService.CheckUserPasswordAsync(loginDto);
            if (success)
            {
                var token = await userService.GetTokenByEmailAddressAsync(loginDto.Email);
                var response = new LoginResponseDto { Token = token };
                return Ok(response);
            }
            return BadRequest("Invalid credentials");
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPost]
    [Route("register")]
    [AllowAnonymous]
    public async Task<IActionResult> Register(RegistrationDto registrationDto)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid payload");
            var success = await userService.CreateUserAsync(registrationDto);
            if (success)
            {
                return Ok("User created successfully");
            }
            return BadRequest("User already exists");

        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet]
    [Route("get-user-data/{id}")]
    public async Task<IActionResult> GetUserData(string id)
    {
        try
        {
            var user = await userService.GetUserDataByIdAsync(id);
            return Ok(user);
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message);
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
            var user = await userService.GetUserByIdAsync(id);
            return Ok(user);
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet]
    [Route("get-users")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<TableViewModel<UserDto>>> GetUsers([FromQuery] string filter = "", [FromQuery] int page = 1, [FromQuery] int pageSize = 10, [FromQuery] string sortField = "id", [FromQuery] string sortOrder = "asc")
    {
        try
        {
            var usersWithCount = await userService.GetUsersAsync(filter, page, pageSize, sortField, sortOrder);

            var tableViewModel = new TableViewModel<UserDto>
            {
                Data = usersWithCount.Item1,
                TotalCount = usersWithCount.Item2
            };
            return Ok(tableViewModel);
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message);
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
            var roles = await userService.GetRolesAsync();
            return Ok(roles);
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message);
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
            var roles = await userService.GetRolesNamesAsync();
            return Ok(roles);
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPut]
    [Route("update-user")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateUser(UserDto userDto)
    {
        try
        {
            var success = await userService.UpdateUserAsync(userDto);
            if (success)
            {
                return Ok("User updated successfully");
            }
            return BadRequest("User not updated");
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPut]
    [Route("set-user-role")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> SetUserRole([FromBody] EditUserRolesDto setRoleDTO)
    {
        try
        {
            var success = await userService.SetUserRole(setRoleDTO);
            if (success)
            {
                return Ok("Role set successfully");
            }
            return BadRequest("Role not set");
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPut]
    [Route("remove-user-role")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> RemoveUserRole([FromBody] EditUserRolesDto removeRoleDTO)
    {
        try
        {
            var success = await userService.RemoveRole(removeRoleDTO);
            if (success)
            {
                return Ok("Role removed successfully");
            }
            return BadRequest("Role not removed");
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}
