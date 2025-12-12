using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Developer_Task_Manager.Models;

namespace Developer_Task_Manager.Pages_Projects
{
    public class IndexModel : PageModel
    {
        private readonly Developer_Task_Manager.Models.AppDbContext _context;

        public IndexModel(Developer_Task_Manager.Models.AppDbContext context)
        {
            _context = context;
        }

        public IList<Project> Project { get;set; } = default!;

        // Paging support
        [BindProperty(SupportsGet = true)]
        public int PageNum { get; set; } = 1;
        public int PageSize { get; set; } = 5;
        public int TotalPages { get; set; }

        // Sorting support
        [BindProperty(SupportsGet = true)]
        public string CurrentSort { get; set; } = "name_asc";

        // Search support
        [BindProperty(SupportsGet = true)]
        public string CurrentSearch { get; set; } = string.Empty;

        public async Task OnGetAsync()
        {
            var query = _context.Projects.Select(p => p);

            if (!string.IsNullOrEmpty(CurrentSearch))
            {
                query = query.Where(p => p.Name.ToUpper().Contains(CurrentSearch.ToUpper())
                                    || p.Description.ToUpper().Contains(CurrentSearch.ToUpper()));
            }

            switch (CurrentSort)
            {
                case "name_asc":
                    query = query.OrderBy(p => p.Name);
                    break;
                case "name_desc":
                    query = query.OrderByDescending(p => p.Name);
                    break;
                case "description_asc":
                    query = query.OrderBy(p => p.Description);
                    break;
                case "description_desc":
                    query = query.OrderByDescending(p => p.Description);
                    break;
                case "created_asc":
                    query = query.OrderBy(p => p.CreatedAt);
                    break;
                case "created_desc":
                    query = query.OrderByDescending(p => p.CreatedAt);
                    break;
                default:
                    // Default sort
                    query = query.OrderBy(p => p.Name);
                    break;
            }

            TotalPages = (int)Math.Ceiling(query.Count() / (double)PageSize);

            Project = await query.Skip((PageNum - 1) * PageSize).Take(PageSize).ToListAsync();
        }
    }
}
