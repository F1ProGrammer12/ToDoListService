using Microsoft.AspNetCore.Mvc;
using ToDoListService.Domain.Models;
using ToDoService.Core.Interfaces;
using ToDoService.Host.Dto.UserDto;
using ToDoService.Host.Extensions;

namespace ToDoListService.Host.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(IUsersService userService) : ControllerBase
{
    [HttpPost("create")]
    public async Task<ActionResult> CreateUserAsync([FromBody] CreateUserRequest request)
        => Ok($"{await userService.CreateUser(request.ToUser())}");

    [HttpPost("update")]
    public async Task<ActionResult> UpdateUser([FromBody] UpdateUserRequest request)
    {
        await userService.UpdateUserAsync(request.ToUser());
        return Ok();
    }

    [HttpDelete("delete")]
    public async Task<ActionResult> DeleteUser([FromBody] DeleteUserRequest request)
    {
        await userService.DeleteUserAsync(request.Id);
        return Ok();
    }

    [HttpGet("get_all")]
    public async Task<ActionResult<IEnumerable<User>>> Users()
        => Ok(await userService.GetUsersAsync());
}