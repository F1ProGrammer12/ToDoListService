using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoListService.Domain.Models;

namespace ToDoListService.Dal.EF.Configurations;

public class PriorityConfiguration : IEntityTypeConfiguration<Priority>
{
    public void Configure(EntityTypeBuilder<Priority> builder)
    {
        builder.ToTable("Priorities").HasKey(p => p.Level);
    }
}