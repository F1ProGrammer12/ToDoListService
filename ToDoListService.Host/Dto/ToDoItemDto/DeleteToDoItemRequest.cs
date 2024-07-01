using System.ComponentModel.DataAnnotations;

namespace ToDoService.Host.Dto.ToDoItemDto;

public class DeleteToDoItemRequest
{
    [Required]
    [Range(1, int.MaxValue)]
    public int Id { get; set; }
}