using System;
using ToDoListService.Domain.Enums;

namespace ToDoListService.Domain.Models;

public class ToDoItem
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime DueDate { get; set; }

    public Level PriorityId { get; set; }
    public Priority Priority { get; set; } = null!;

    public int? UserId { get; set; }
    public User? User { get; set; }
}