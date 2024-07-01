using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoListService.Domain.Models;

namespace ToDoListService.Dal.EF.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users").HasKey(t => t.Id);
        builder.Property(u => u.Name).HasMaxLength(50).IsRequired();
    }
}