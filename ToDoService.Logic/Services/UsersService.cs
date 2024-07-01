using ToDoListService.Domain.Abstractions.Repositories;
using ToDoListService.Domain.Models;
using ToDoService.Core.Interfaces;
using ToDoService.Logic.Exceptions;

namespace ToDoService.Core.Services;

public class UsersService(IUsersRepository usersRepository) : IUsersService
{
    public Task<int> CreateUser(User user)
        => usersRepository.CreateAsync(user);

    public async Task DeleteUserAsync(int id)
    {
        if (!await usersRepository.IsUserExistAsync(id))
            throw new NotFoundException($"user with id: {id} not found");

        await usersRepository.DeleteAsync(id);
    }

    public async Task<User> UpdateUserAsync(User user)
    {
        if (!await usersRepository.IsUserExistAsync(user.Id))
            throw new NotFoundException($"user with id: {user.Id} not found");

        return await usersRepository.UpdateAsync(user);
    }

    public async Task<IEnumerable<User>> GetUsersAsync() => await usersRepository.GetAllAsync();
}