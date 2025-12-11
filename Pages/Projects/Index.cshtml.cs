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
    public class IndexModel : PageModel
    {
        private readonly Developer_Task_Manager.Data.AppDbContext _context;

        public IndexModel(Developer_Task_Manager.Data.AppDbContext context)
        {
            _context = context;
        }

        public IList<Project> Project { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Project = await _context.Projects.ToListAsync();
        }
    }
}
