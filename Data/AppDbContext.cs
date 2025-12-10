using Microsoft.EntityFrameworkCore;
using Developer_Task_Manager.Models;

namespace Developer_Task_Manager.Data;

/// <summary>
/// Entity Framework Core database context for the Developer Task Manager.
/// Manages database connections and entity configurations.
/// </summary>
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    /// <summary>Projects table - parent entity for tasks</summary>
    public DbSet<Project> Projects { get; set; }

    /// <summary>Categories table - classifies tasks</summary>
    public DbSet<Category> Categories { get; set; }

    /// <summary>TaskItems table - main work items linked to projects and categories</summary>
    public DbSet<TaskItem> TaskItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure composite key for TaskItem
        modelBuilder.Entity<TaskItem>()
            .HasKey(e => new { e.ProjectId, e.TaskId });
    }
}
