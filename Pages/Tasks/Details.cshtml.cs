using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Developer_Task_Manager.Models;

namespace Developer_Task_Manager.Pages_Tasks
{
    public class DetailsModel : PageModel
    {
        private readonly Developer_Task_Manager.Models.AppDbContext _context;

        public DetailsModel(Developer_Task_Manager.Models.AppDbContext context)
        {
            _context = context;
        }

        public TaskItem TaskItem { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskitem = await _context.TaskItems
                .Include(t => t.Project)
                .Include(t => t.Category)
                .FirstOrDefaultAsync(m => m.TaskItemID == id);

            if (taskitem == null)
            {
                return NotFound();
            }
            else
            {
                TaskItem = taskitem;
            }
            return Page();
        }
    }
}
