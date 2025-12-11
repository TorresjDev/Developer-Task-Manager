using System.ComponentModel.DataAnnotations;

namespace Developer_Task_Manager.Models;

/// <summary>
/// Represents a project that contains multiple tasks.
/// A project is a parent entity in the one-to-many relationship with Tasks.
/// </summary>
public class Project
{
    public int ProjectID { get; set; } // Primary Key

    [StringLength(100)]
    [Display(Name = "Project Name")]
    public string Name { get; set; } = string.Empty;

    [StringLength(500)]
    public string Description { get; set; } = string.Empty;

    [Display(Name = "Created At")]
    [DataType(DataType.DateTime)]
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    // Navigation property - One Project has many Tasks
    public List<TaskItem>? Tasks { get; set; } = default!;
}
