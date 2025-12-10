using System.ComponentModel.DataAnnotations;

namespace Developer_Task_Manager.Models;

/// <summary>
/// Represents a category for classifying tasks.
/// A category is a parent entity in the one-to-many relationship with Tasks.
/// </summary>
public class Category
{
    [Key]
    public int CategoryId { get; set; }

    [Required(ErrorMessage = "Category name is required")]
    [StringLength(50, ErrorMessage = "Category name cannot exceed 50 characters")]
    [Display(Name = "Category Name")]
    public string Name { get; set; } = string.Empty;

    [StringLength(200, ErrorMessage = "Description cannot exceed 200 characters")]
    public string Description { get; set; } = string.Empty;

    // Navigation property - One Category has many Tasks
    public List<TaskItem> Tasks { get; set; } = new();
}
