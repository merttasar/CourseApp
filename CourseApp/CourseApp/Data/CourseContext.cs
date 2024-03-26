using CourseApp.Entity;
using Microsoft.EntityFrameworkCore;

namespace CourseApp.Data
{
    public class CourseContext : DbContext
    {
        public CourseContext(DbContextOptions<CourseContext> options) : base(options) { }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
