using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Developer_Task_Manager.Data;
using Developer_Task_Manager.Models;

namespace Developer_Task_Manager.Pages_Tasks
{
    public class DeleteModel : PageModel
    {
        private readonly Developer_Task_Manager.Data.AppDbContext _context;

        public DeleteModel(Developer_Task_Manager.Data.AppDbContext context)
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

            var taskitem = await _context.TaskItems.FirstOrDefaultAsync(m => m.ProjectId == id);

            if (taskitem is not null)
            {
                TaskItem = taskitem;

                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskitem = await _context.TaskItems.FindAsync(id);
            if (taskitem != null)
            {
                TaskItem = taskitem;
                _context.TaskItems.Remove(TaskItem);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
