using System.ComponentModel.DataAnnotations;

namespace Developer_Task_Manager.Models;

/// <summary>
/// Represents a task assigned to a project and category.
/// Named TaskItem to avoid conflict with System.Threading.Tasks.Task.
/// This is a child entity with foreign key relationships to Project and Category.
/// </summary>
public class TaskItem
{
    [Key]
    public int TaskId { get; set; }

    [Required(ErrorMessage = "Task title is required")]
    [StringLength(150, ErrorMessage = "Title cannot exceed 150 characters")]
    public string Title { get; set; } = string.Empty;

    [StringLength(1000, ErrorMessage = "Description cannot exceed 1000 characters")]
    public string Description { get; set; } = string.Empty;

    [Required]
    [StringLength(20)]
    public string Priority { get; set; } = "Medium"; // Low, Medium, High

    [Required]
    [StringLength(20)]
    public string Status { get; set; } = "To Do"; // To Do, In Progress, Done

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
    [Required(ErrorMessage = "Please select a project")]
    public int ProjectId { get; set; }

    [Display(Name = "Category")]
    [Required(ErrorMessage = "Please select a category")]
    public int CategoryId { get; set; }

    // Navigation Properties
    public Project Project { get; set; } = default!;
    public Category Category { get; set; } = default!;
}
