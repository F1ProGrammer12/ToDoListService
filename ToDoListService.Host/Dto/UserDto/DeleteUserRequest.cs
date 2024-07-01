using System.ComponentModel.DataAnnotations;

namespace ToDoService.Host.Dto.UserDto;

public class DeleteUserRequest
{
    [Required]
    [Range(0, int.MaxValue)]
    public int Id { get; set; }
}