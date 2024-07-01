using System.ComponentModel.DataAnnotations;

namespace ToDoListService.Host.Dto.ToDoItemDto;

public class IsCompletedToDoItemRequest
{
    [Required]
    [Range(1, int.MaxValue)]
    public int Id { get; set; }
}