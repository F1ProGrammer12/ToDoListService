using Microsoft.EntityFrameworkCore;
using ToDoListService.Domain.Models;

namespace ToDoListService.Dal.EF;

public class TDListDbContext : DbContext
{
    public TDListDbContext(DbContextOptions<TDListDbContext> options) : base(options)
    {
#if DEBUG
        Database.EnsureCreated();
#endif
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Priority> Priorities { get; set; }
    public DbSet<ToDoItem> ToDoItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TDListDbContext).Assembly);

        modelBuilder.Entity<Priority>().HasData(
            new { Level = Domain.Enums.Level.Low, Items = Array.Empty<ToDoItem>() },
            new { Level = Domain.Enums.Level.Medium, Items = Array.Empty<ToDoItem>() },
            new { Level = Domain.Enums.Level.High, Items = Array.Empty<ToDoItem>() });

        base.OnModelCreating(modelBuilder);
    }
}