using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoListService.Domain.Models;

namespace ToDoListService.Dal.EF.Configurations;

public class ToDoItemConfiguration : IEntityTypeConfiguration<ToDoItem>
{
    public void Configure(EntityTypeBuilder<ToDoItem> builder)
    {
        builder.ToTable("ToDoItems").HasKey(i => i.Id);
        builder.Property(i => i.Title).HasMaxLength(100).IsRequired();
        builder.HasOne(i => i.Priority).WithMany(p => p.Items).HasForeignKey(x => x.PriorityId);
        builder.HasIndex(p => p.PriorityId);
        builder.HasOne(i => i.User).WithMany(p => p.Items).HasForeignKey(x => x.UserId);
        builder.HasIndex(i => i.UserId).HasFilter(null);
    }
}