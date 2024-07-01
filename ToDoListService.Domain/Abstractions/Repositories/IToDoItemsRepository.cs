using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoListService.Domain.Enums;
using ToDoListService.Domain.Models;

namespace ToDoListService.Domain.Abstractions.Repositories;

public interface IToDoItemsRepository
{
    Task<int> CreateAsync(ToDoItem item);
    Task<ToDoItem> UpdateAsync(ToDoItem item);
    Task<int> DeleteAsync(int id);
    Task<IEnumerable<ToDoItem>> GetAllAsync();
    Task<IEnumerable<ToDoItem>> GetFilteredItemsAsync(bool isCompleted, Level priority);
    Task<bool> IsItemExistAsync(int id);
    Task AssignUserAsync(int itemId, int userId);
    Task ItemIsCompleted(int id);
    Task<ToDoItem?> GetItem(int id);
}