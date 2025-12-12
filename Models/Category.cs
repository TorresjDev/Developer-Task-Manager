using System.ComponentModel.DataAnnotations;

namespace Developer_Task_Manager.Models;

/// <summary>
/// Represents a category for classifying tasks.
/// A category is a parent entity in the one-to-many relationship with Tasks.
/// </summary>
public class Category
{
    public int CategoryID { get; set; } // Primary Key

    [StringLength(50)]
    [Display(Name = "Category Name")]
    public string Name { get; set; } = string.Empty;

    [StringLength(300)]
    public string Description { get; set; } = string.Empty;

    // Navigation property - One Category has many Tasks
    public List<TaskItem>? Tasks { get; set; } = default!;
}
