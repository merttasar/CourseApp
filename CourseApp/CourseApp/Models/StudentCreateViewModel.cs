using CourseApp.Entity;
using System.ComponentModel.DataAnnotations;

namespace CourseApp.Models
{
    public class StudentCreateViewModel
    {

        public int StudentId { get; set; }
        [Required]
        [Display(Name = "Firstname")]
        public string? FirstName { get; set; }
        [Required]
        [Display(Name = ("Lastname"))]
        public string? LastName { get; set; }
        [Required]
        [Display(Name = "Birthdate")]
        public DateOnly BirthDate { get; set; }
        public int[] CourseIds { get; set; }
        public List<Course> Courses { get; set; } = new List<Course>();
    }
}
