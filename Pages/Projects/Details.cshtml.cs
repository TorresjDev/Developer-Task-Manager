using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Developer_Task_Manager.Data;
using Developer_Task_Manager.Models;

namespace Developer_Task_Manager.Pages_Projects
{
    public class DetailsModel : PageModel
    {
        private readonly Developer_Task_Manager.Data.AppDbContext _context;

        public DetailsModel(Developer_Task_Manager.Data.AppDbContext context)
        {
            _context = context;
        }

        public Project Project { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects.FirstOrDefaultAsync(m => m.ProjectId == id);

            if (project is not null)
            {
                Project = project;

                return Page();
            }

            return NotFound();
        }
    }
}
