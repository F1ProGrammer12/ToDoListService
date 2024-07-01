using ToDoListService.Domain.Models;
using ToDoListService.Host.Dto.ToDoItemDto;
using ToDoService.Host.Dto.ToDoItemDto;
using ToDoService.Host.Dto.UserDto;

namespace ToDoService.Host.Extensions;

public static class MappingExtensions
{
    public static ToDoItem ToTDItem(this CreateToDoItemRequest request) => new ()
    {
        Title = request.Title,
        Description = request.Description,
        PriorityId = request.PriorityId,
        UserId = request.UserId,
        DueDate = request.DueDate,
    };

    public static User ToUser(this CreateUserRequest request) => new()
    {
        Name = request.Name,
    };

    public static User ToUser(this UpdateUserRequest request) => new()
    {
        Id = request.Id,
        Name = request.Name,
    };

    public static ToDoItem ToTDItem(this UpdateToDoItemRequest request) => new()
    {
        Id = request.Id,
        Title = request.Title,
        Description = request.Description,
        DueDate = request.DueDate,
        PriorityId = request.PriorityId
    };
}