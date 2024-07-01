using ToDoListService.Domain.Abstractions.Repositories;
using ToDoListService.Domain.Enums;
using ToDoListService.Domain.Models;
using ToDoService.Logic.Exceptions;
using ToDoService.Logic.Interfaces;

namespace ToDoService.Logic.Services;

public class ToDoItemsService(IToDoItemsRepository toDoItemsRepository, IUsersRepository usersRepository) : IToDoItemsService
{
    public Task<int> CreateToDoItem(ToDoItem item) => toDoItemsRepository.CreateAsync(item);

    public async Task<ToDoItem> UpdateToDoItemAsync(ToDoItem item)
    {
        var toDoItem = await toDoItemsRepository.GetItem(item.Id)
            ?? throw new NotFoundException($"item with id: {item.Id} not found");

        toDoItem.Title = item.Title;
        toDoItem.PriorityId = item.PriorityId;
        toDoItem.DueDate = item.DueDate;

        if (!string.IsNullOrWhiteSpace(item.Description))
            toDoItem.Description = item.Description;
        
        return await toDoItemsRepository.UpdateAsync(toDoItem);        
    }

    public async Task DeleteToDoItemAsync(int id)
    {
        if (!await toDoItemsRepository.IsItemExistAsync(id))
            throw new NotFoundException($"item with id: {id} not found");

        await toDoItemsRepository.DeleteAsync(id);
    }

    public Task<IEnumerable<ToDoItem>> GetToDoItems() => toDoItemsRepository.GetAllAsync();

    public async Task AssignToDoItemAsync(int itemId, int userId)
    {
        if (itemId < 1)
            throw new RequestContentException($"Unexpexted value for item id: {itemId}");
        if (!await toDoItemsRepository.IsItemExistAsync(itemId))
            throw new NotFoundException($"item with id: {itemId} not found");

        if (userId < 1)
            throw new RequestContentException($"Unexpexted value for user id: {userId}");
        if (!await usersRepository.IsUserExistAsync(userId))
            throw new NotFoundException($"user with id: {userId} not found");

        await toDoItemsRepository.AssignUserAsync(itemId, userId);
    }

    public Task<IEnumerable<ToDoItem>> GetFilteredToDoItems(bool isCompleted, Level priority)
        => toDoItemsRepository.GetFilteredItemsAsync(isCompleted, priority);

    public async Task IsCompletedToDoItem(int id)
    {
        if (!await toDoItemsRepository.IsItemExistAsync(id))
            throw new NotFoundException($"item with id: {id} not found");

        await toDoItemsRepository.ItemIsCompleted(id);
    }
}