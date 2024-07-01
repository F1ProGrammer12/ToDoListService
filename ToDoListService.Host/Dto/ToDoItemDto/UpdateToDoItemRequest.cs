using System.ComponentModel.DataAnnotations;
using ToDoListService.Domain.Enums;

namespace ToDoListService.Host.Dto.ToDoItemDto;

public class UpdateToDoItemRequest
{
    [Required]
    [Range(0, int.MaxValue)]
    public int Id { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string Title { get; set; } = null!;
    public string? Description { get; set; }

    [Required]
    [DataType(DataType.DateTime)]
    public DateTime DueDate { get; set; }

    [Required]
    [Range(1, 3)]
    public Level PriorityId { get; set; }
}