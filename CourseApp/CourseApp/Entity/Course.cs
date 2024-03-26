using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;

namespace CourseApp.Entity
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        public string CourseName { get; set; } = null!;
        public List<Student> Students { get; set; } = new List<Student>();
    }
}
