using System;
using System.Collections.Generic;

namespace ToDoListService.Domain.Models;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public ICollection<ToDoItem> Items { get; set; } = Array.Empty<ToDoItem>();
}