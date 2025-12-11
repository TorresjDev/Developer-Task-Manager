using System.ComponentModel.DataAnnotations;

namespace Developer_Task_Manager.Models;

/// <summary>
/// Represents a task assigned to a project and category.
/// Named TaskItem to avoid conflict with System.Threading.Tasks.Task.
/// </summary>
public class TaskItem
{
    public int TaskItemID { get; set; } // Primary Key

    [StringLength(150)]
    [Display(Name = "Task Title")]
    public string Title { get; set; } = string.Empty;

    [StringLength(1000)]
    public string Description { get; set; } = string.Empty;

    [StringLength(20)]
    [Display(Name = "Priority")]
    public string Priority { get; set; } = string.Empty; // Low, Medium, High

    [StringLength(20)]
    [Display(Name = "Status")]
    public string Status { get; set; } = string.Empty; // To Do, In Progress, Done

    [StringLength(50)]
    public string Assignee { get; set; } = string.Empty;

    [Display(Name = "Due Date")]
    [DataType(DataType.Date)]
    public DateTime? DueDate { get; set; }

    [Display(Name = "Created At")]
    [DataType(DataType.DateTime)]
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    [Display(Name = "Updated At")]
    [DataType(DataType.DateTime)]
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    // Foreign Keys
    [Display(Name = "Project")]
    public int ProjectID { get; set; }

    [Display(Name = "Category")]
    public int CategoryID { get; set; }

    // Navigation Properties
    public Project Project { get; set; } = default!;
    public Category Category { get; set; } = default!;
}
