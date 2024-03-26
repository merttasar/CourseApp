using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;

namespace CourseApp.Entity
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateOnly BirthDate { get; set; }
        public List<Course> Courses { get; set; } = new List<Course>();
    }
}
