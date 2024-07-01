using ToDoListService.Domain.Enums;
using ToDoListService.Domain.Models;

namespace ToDoService.Logic.Interfaces;

public interface IToDoItemsService
{
    Task<int> CreateToDoItem(ToDoItem item);
    Task<ToDoItem> UpdateToDoItemAsync(ToDoItem item);
    Task DeleteToDoItemAsync(int id);
    Task<IEnumerable<ToDoItem>> GetToDoItems();
    Task AssignToDoItemAsync(int itemId, int userId);
    Task<IEnumerable<ToDoItem>> GetFilteredToDoItems(bool isCompleted, Level priority);
    Task IsCompletedToDoItem(int id);
}