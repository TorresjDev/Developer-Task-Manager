using Microsoft.EntityFrameworkCore;

namespace Developer_Task_Manager.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
    {

    }

    public DbSet<Project> Projects { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<TaskItem> TaskItems { get; set; }
}
