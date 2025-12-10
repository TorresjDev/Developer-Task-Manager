using System.ComponentModel.DataAnnotations;

namespace Developer_Task_Manager.Models;

/// <summary>
/// Represents a project that contains multiple tasks.
/// A project is a parent entity in the one-to-many relationship with Tasks.
/// </summary>
public class Project
{
    [Key]
    public int ProjectId { get; set; }

    [Required(ErrorMessage = "Project name is required")]
    [StringLength(100, ErrorMessage = "Project name cannot exceed 100 characters")]
    [Display(Name = "Project Name")]
    public string Name { get; set; } = string.Empty;

    [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
    public string Description { get; set; } = string.Empty;

    [Display(Name = "Created At")]
    [DataType(DataType.DateTime)]
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    // Navigation property - One Project has many Tasks
    public List<TaskItem> Tasks { get; set; } = new();
}
