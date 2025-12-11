using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Developer_Task_Manager.Models;

namespace Developer_Task_Manager.Pages_Categories
{
    public class DetailsModel : PageModel
    {
        private readonly Developer_Task_Manager.Models.AppDbContext _context;

        public DetailsModel(Developer_Task_Manager.Models.AppDbContext context)
        {
            _context = context;
        }

        public Category Category { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .Include(c => c.Tasks)
                .FirstOrDefaultAsync(m => m.CategoryID == id);

            if (category == null)
            {
                return NotFound();
            }
            else
            {
                Category = category;
            }
            return Page();
        }
    }
}
