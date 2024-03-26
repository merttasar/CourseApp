using CourseApp.Entity;
using System.ComponentModel.DataAnnotations;

namespace CourseApp;

public class CourseCreateViewModel
{
    public int CourseId { get; set; }
    [Required]
    [Display(Name = "Course Name")]
    public string? CourseName { get; set; }

}
