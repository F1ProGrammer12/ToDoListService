namespace ToDoListService.Host.Dto.ToDoItemDto;

public class AssignToDoItemRequest
{
    public int ToDoItemId { get; set; }
    public int UserId { get; set; }
}