using Developer_Task_Manager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Developer_Task_Manager.Pages_Tasks;

public class CreateModel : PageModel
{
    private readonly Developer_Task_Manager.Models.AppDbContext _context;

    public CreateModel(Developer_Task_Manager.Models.AppDbContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "Name");
        ViewData["ProjectID"] = new SelectList(_context.Projects, "ProjectID", "Name");
        return Page();
    }

    [BindProperty]
    public TaskItem TaskItem { get; set; } = default!;

    // For more information, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        // Remove validation for navigation properties (populated by EF Core)
        ModelState.Remove("TaskItem.Project");
        ModelState.Remove("TaskItem.Category");

        if (!ModelState.IsValid)
        {
            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "Name");
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ProjectID", "Name");
            return Page();
        }

        TaskItem.CreatedAt = DateTime.Now;
        TaskItem.UpdatedAt = DateTime.Now;
        _context.TaskItems.Add(TaskItem);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
