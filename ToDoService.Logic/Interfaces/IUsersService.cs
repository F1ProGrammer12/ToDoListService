using ToDoListService.Domain.Models;

namespace ToDoService.Core.Interfaces;

public interface IUsersService
{
    Task<int> CreateUser(User user);
    Task<User> UpdateUserAsync(User user);
    Task DeleteUserAsync(int id);
    Task<IEnumerable<User>> GetUsersAsync();
}