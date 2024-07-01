using System;
using System.Collections.Generic;
using ToDoListService.Domain.Enums;

namespace ToDoListService.Domain.Models;

public class Priority
{
    public Level Level { get; set; }
    public ICollection<ToDoItem> Items { get; set; } = Array.Empty<ToDoItem>();
}