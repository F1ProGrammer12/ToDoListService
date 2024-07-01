using System.ComponentModel.DataAnnotations;
using ToDoListService.Domain.Enums;

namespace ToDoListService.Host.Dto.ToDoItemDto;

public class GetFilteredToDoItemsRequest
{
    [Required]
    [Range(0, 1)]
    public bool IsCompleted { get; set; }

    [Required]
    [Range(1, 3)]
    public Level Priority { get; set; }
}