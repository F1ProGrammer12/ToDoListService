using System.ComponentModel.DataAnnotations;

namespace ToDoService.Host.Dto.UserDto;
public class CreateUserRequest
{
    [Required]
    [StringLength(50, MinimumLength = 3)]
    public string Name { get; set; } = null!;
}