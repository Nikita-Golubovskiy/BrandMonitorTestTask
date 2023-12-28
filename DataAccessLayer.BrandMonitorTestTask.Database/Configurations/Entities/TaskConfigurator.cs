using DataAccessLayer.BrandMonitorTestTask.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.BrandMonitorTestTask.Database.Configurations.Entities;

/// <summary>
/// EF Core model configuration providing class for <see cref="Task">Task</see> entity.
/// </summary>
internal sealed class TaskConfigurator : IEntityTypeConfiguration<Task>
{
    /// <summary>
    /// <see cref="Task">Task</see> EF Core entity configuration applying method.
    /// </summary>
    /// <param name="builder">Corresponding EF Core entity configuration builder reference value.</param>
    public void Configure(EntityTypeBuilder<Task> builder)
    {
        builder.ToTable("Tasks");

        builder
            .HasKey(entity => entity.ID);

        builder
            .Property(entity => entity.ID)
            .HasColumnName("TaskID")
            .HasColumnType("nvarchar")
            .HasMaxLength(36)
            .IsRequired()
            .ValueGeneratedNever();

        builder
            .Property(entity => entity.State)
            .HasColumnType("nvarchar")
            .IsRequired()
            .HasMaxLength(256);

        builder
            .Property(entity => entity.CurrentDateTime)
            .HasColumnType("datetime")
            .IsRequired();
    }
}