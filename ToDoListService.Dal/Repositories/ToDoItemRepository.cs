using Microsoft.EntityFrameworkCore;
using ToDoListService.Dal.EF;
using ToDoListService.Domain.Abstractions.Repositories;
using ToDoListService.Domain.Enums;
using ToDoListService.Domain.Models;

namespace ToDoService.Dal.Repositories;

public class ToDoItemRepository(TDListDbContext dbContext) : IToDoItemsRepository
{
    public async Task<int> CreateAsync(ToDoItem item)
    {
        await dbContext.ToDoItems.AddAsync(item);
        await dbContext.SaveChangesAsync();
        return item.Id;
    }

    public async Task<int> DeleteAsync(int id)
    {
        await dbContext.ToDoItems.Where(u => u.Id == id).ExecuteDeleteAsync();
        return id;
    }

    public async Task<ToDoItem> UpdateAsync(ToDoItem item)
    {
        dbContext.ToDoItems.Update(item);
        await dbContext.SaveChangesAsync();
        return item;
    }

    public async Task<IEnumerable<ToDoItem>> GetAllAsync()
        => await dbContext.ToDoItems.AsNoTracking().ToArrayAsync();

    public async Task<IEnumerable<ToDoItem>> GetFilteredItemsAsync(bool isCompleted, Level priority)
        => await dbContext.ToDoItems.AsNoTracking()
            .Where(item => item.IsCompleted == isCompleted && item.PriorityId == priority)
            .ToArrayAsync();

    public async Task<ToDoItem?> GetItem(int id)
        => await dbContext.ToDoItems.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);

    public Task<bool> IsItemExistAsync(int id)
        => dbContext.ToDoItems.AsNoTracking().AnyAsync(i => i.Id == id);

    public Task AssignUserAsync(int itemId, int userId)
        => dbContext.ToDoItems
            .Where(item => item.Id == itemId)
            .ExecuteUpdateAsync(item => item.SetProperty(b => b.UserId, userId));

    public async Task ItemIsCompleted(int id)
        => await dbContext.ToDoItems.Where(i => i.Id == id).ExecuteUpdateAsync(i => i.SetProperty(p => p.IsCompleted, true));
}