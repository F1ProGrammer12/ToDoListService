using Microsoft.AspNetCore.Mvc;
using ToDoListService.Domain.Models;
using ToDoListService.Host.Dto.ToDoItemDto;
using ToDoService.Host.Dto.ToDoItemDto;
using ToDoService.Host.Extensions;
using ToDoService.Logic.Interfaces;

namespace ToDoListService.Host.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ToDoItemsController(IToDoItemsService toDoItemsService) : ControllerBase
{
    [HttpPost("create")]
    public async Task<ActionResult> CreateToDoItem([FromBody] CreateToDoItemRequest request)
        => Ok($"{await toDoItemsService.CreateToDoItem(request.ToTDItem())}");

    [HttpPost("update")]
    public async Task<ActionResult> UpdateToDoItem([FromBody] UpdateToDoItemRequest request)
    {
        await toDoItemsService.UpdateToDoItemAsync(request.ToTDItem());
        return Ok();
    }

    [HttpDelete("delete")]
    public async Task<ActionResult> DeleteToDoItem([FromBody] DeleteToDoItemRequest request)
    {
        await toDoItemsService.DeleteToDoItemAsync(request.Id);
        return Ok();
    }

    [HttpGet("get_all")]
    public async Task<ActionResult<IEnumerable<ToDoItem>>> GetToDoItems()
        => Ok(await toDoItemsService.GetToDoItems());
    
    [HttpPost("assign_item")]
    public async Task<ActionResult> AssignToDoItem([FromBody] AssignToDoItemRequest request)
    {
        await toDoItemsService.AssignToDoItemAsync(request.ToDoItemId, request.UserId);
        return Ok();
    }

    [HttpPost("get_filtered")]
    public async Task<ActionResult<IEnumerable<ToDoItem>>> GetFilteredToDoItems([FromBody] GetFilteredToDoItemsRequest request)
        => Ok(await toDoItemsService.GetFilteredToDoItems(request.IsCompleted, request.Priority));

    [HttpPost("is_completed")]
    public async Task<ActionResult> IsCompletedToDoItem([FromBody] IsCompletedToDoItemRequest request)
    {
        await toDoItemsService.IsCompletedToDoItem(request.Id);
        return Ok();
    }
}