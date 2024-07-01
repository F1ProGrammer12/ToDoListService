using Microsoft.EntityFrameworkCore;
using ToDoListService.Dal.EF;
using ToDoListService.Domain.Abstractions.Repositories;
using ToDoListService.Domain.Models;

namespace ToDoService.Dal.Repositories;

public class UsersRepository(TDListDbContext dbContext) : IUsersRepository
{
    public async Task<int> CreateAsync(User user)
    {
        await dbContext.Users.AddAsync(user);
        await dbContext.SaveChangesAsync();
        return user.Id;
    }

    public async Task<int> DeleteAsync(int id)
    {
        await dbContext.Users.Where(u => u.Id == id).ExecuteDeleteAsync();
        return id;
    }

    public async Task<User> UpdateAsync(User user)
    {
        await dbContext.Users.Where(u => u.Id == user.Id).ExecuteUpdateAsync(u => u.SetProperty(p => p.Name, user.Name));
        return user;
    }

    public async Task<IEnumerable<User>> GetAllAsync()
        => await dbContext.Users.AsNoTracking().ToArrayAsync();

    public Task<bool> IsUserExistAsync(int id) => dbContext.Users.AsNoTracking().AnyAsync(user => user.Id == id);
}