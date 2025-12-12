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
    public class IndexModel : PageModel
    {
        private readonly Developer_Task_Manager.Models.AppDbContext _context;

        public IndexModel(Developer_Task_Manager.Models.AppDbContext context)
        {
            _context = context;
        }

        public IList<TaskItem> TaskItem { get; set; } = default!;

        // Paging support
        [BindProperty(SupportsGet = true)]
        public int PageNum { get; set; } = 1;
        public int PageSize { get; set; } = 7;
        public int TotalPages { get; set; }

        // Sorting support
        [BindProperty(SupportsGet = true)]
        public string CurrentSort { get; set; } = "title_asc";

        // Search support
        [BindProperty(SupportsGet = true)]
        public string CurrentSearch { get; set; } = string.Empty;

        // Filter support
        [BindProperty(SupportsGet = true)]
        public string PriorityFilter { get; set; } = string.Empty;

        [BindProperty(SupportsGet = true)]
        public string StatusFilter { get; set; } = string.Empty;

        public async Task OnGetAsync()
        {
            var query = _context.TaskItems
                .Include(t => t.Category)
                .Include(t => t.Project)
                .Select(t => t);

            if (!string.IsNullOrEmpty(CurrentSearch))
            {
                query = query.Where(t => t.Title.ToUpper().Contains(CurrentSearch.ToUpper())
                                    || t.Priority.ToUpper().Contains(CurrentSearch.ToUpper())
                                    || t.Status.ToUpper().Contains(CurrentSearch.ToUpper())
                                    || t.Assignee.ToUpper().Contains(CurrentSearch.ToUpper())
                                    || t.Project.Name.ToUpper().Contains(CurrentSearch.ToUpper())
                                    || t.Category.Name.ToUpper().Contains(CurrentSearch.ToUpper()));
            }

            // Priority filter
            if (!string.IsNullOrEmpty(PriorityFilter))
            {
                query = query.Where(t => t.Priority == PriorityFilter);
            }

            // Status filter
            if (!string.IsNullOrEmpty(StatusFilter))
            {
                query = query.Where(t => t.Status == StatusFilter);
            }

            switch (CurrentSort)
            {
                case "title_asc":
                    query = query.OrderBy(t => t.Title);
                    break;
                case "title_desc":
                    query = query.OrderByDescending(t => t.Title);
                    break;
                case "priority_asc":
                    // Custom order: Low (1), Medium (2), High (3)
                    query = query.OrderBy(t => t.Priority.ToUpper() == "LOW" ? 1 : 
                                               t.Priority.ToUpper() == "MEDIUM" ? 2 : 
                                               t.Priority.ToUpper() == "HIGH" ? 3 : 4);
                    break;
                case "priority_desc":
                    query = query.OrderByDescending(t => t.Priority.ToUpper() == "LOW" ? 1 : 
                                                         t.Priority.ToUpper() == "MEDIUM" ? 2 : 
                                                         t.Priority.ToUpper() == "HIGH" ? 3 : 4);
                    break;
                case "status_asc":
                    // Custom order: To Do (1), In Progress (2), Done (3)
                    query = query.OrderBy(t => t.Status.ToUpper() == "TO DO" ? 1 : 
                                             t.Status.ToUpper() == "IN PROGRESS" ? 2 : 
                                             t.Status.ToUpper() == "DONE" ? 3 : 4);
                    break;
                case "status_desc":
                    query = query.OrderByDescending(t => t.Status.ToUpper() == "TO DO" ? 1 : 
                                                         t.Status.ToUpper() == "IN PROGRESS" ? 2 : 
                                                         t.Status.ToUpper() == "DONE" ? 3 : 4);
                    break;
                case "project_asc":
                    query = query.OrderBy(t => t.Project.Name);
                    break;
                case "project_desc":
                    query = query.OrderByDescending(t => t.Project.Name);
                    break;
                case "category_asc":
                    query = query.OrderBy(t => t.Category.Name);
                    break;
                case "category_desc":
                    query = query.OrderByDescending(t => t.Category.Name);
                    break;
                case "duedate_asc":
                    query = query.OrderBy(t => t.DueDate);
                    break;
                case "duedate_desc":
                    query = query.OrderByDescending(t => t.DueDate);
                    break;
                case "assignee_asc":
                    query = query.OrderBy(t => t.Assignee);
                    break;
                case "assignee_desc":
                    query = query.OrderByDescending(t => t.Assignee);
                    break;
                default:
                    // Default sort
                    query = query.OrderBy(t => t.Title);
                    break;
            }

            TotalPages = (int)Math.Ceiling(query.Count() / (double)PageSize);

            TaskItem = await query.Skip((PageNum - 1) * PageSize).Take(PageSize).ToListAsync();
        }
    }
}
