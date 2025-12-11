using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Developer_Task_Manager.Models;

namespace Developer_Task_Manager.Pages;

public class IndexModel : PageModel
{
    private readonly AppDbContext _context;

    public IndexModel(AppDbContext context)
    {
        _context = context;
    }

    // Dashboard statistics
    public int TotalProjects { get; set; }
    public int TotalCategories { get; set; }
    public int TotalTasks { get; set; }
    public int TasksToDo { get; set; }
    public int TasksInProgress { get; set; }
    public int TasksDone { get; set; }

    public async Task OnGetAsync()
    {
        TotalProjects = await _context.Projects.CountAsync();
        TotalCategories = await _context.Categories.CountAsync();
        TotalTasks = await _context.TaskItems.CountAsync();
        TasksToDo = await _context.TaskItems.CountAsync(t => t.Status == "To Do");
        TasksInProgress = await _context.TaskItems.CountAsync(t => t.Status == "In Progress");
        TasksDone = await _context.TaskItems.CountAsync(t => t.Status == "Done");
    }
}
