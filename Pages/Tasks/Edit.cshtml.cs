using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Developer_Task_Manager.Models;

namespace Developer_Task_Manager.Pages_Tasks
{
    public class EditModel : PageModel
    {
        private readonly Developer_Task_Manager.Models.AppDbContext _context;

        public EditModel(Developer_Task_Manager.Models.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TaskItem TaskItem { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskitem =  await _context.TaskItems.FirstOrDefaultAsync(m => m.TaskItemID == id);
            if (taskitem == null)
            {
                return NotFound();
            }
            TaskItem = taskitem;
           ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "Name");
           ViewData["ProjectID"] = new SelectList(_context.Projects, "ProjectID", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
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

            TaskItem.UpdatedAt = DateTime.Now;
            _context.Attach(TaskItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskItemExists(TaskItem.TaskItemID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TaskItemExists(int id)
        {
            return _context.TaskItems.Any(e => e.TaskItemID == id);
        }
    }
}
