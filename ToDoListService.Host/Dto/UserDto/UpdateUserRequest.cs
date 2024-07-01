using System.ComponentModel.DataAnnotations;
using ToDoListService.Domain.Models;

namespace ToDoService.Host.Dto.UserDto;

public class UpdateUserRequest
{
    [Required]
    [Range(0, int.MaxValue)]
    public int Id { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 3)]
    public string Name { get; set; } = null!;
}