using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoListService.Domain.Models;

namespace ToDoListService.Domain.Abstractions.Repositories;

public interface IUsersRepository
{
    Task<int> CreateAsync(User user);
    Task<User> UpdateAsync(User user);
    Task<int> DeleteAsync(int id);
    Task<IEnumerable<User>> GetAllAsync();
    Task<bool> IsUserExistAsync(int id);
}