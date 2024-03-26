using CourseApp.Data.Abstract;
using CourseApp.Entity;

namespace CourseApp.Data.Concrete
{
    public class EfCourseRepository : ICourseRepository
    {
        public CourseContext _context;
        public EfCourseRepository(CourseContext context)
        {
            _context = context;
        }
        public IQueryable<Course> Courses => _context.Courses;

        public void CreateCourse(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
        }

        public void RemoveCourse(Course course)
        {
            _context.Courses.Remove(course);
            _context.SaveChanges();
        }

        public void UpdateCourse(Course course)
        {
            var result = _context.Courses.FirstOrDefault(i => i.CourseId == course.CourseId);
            if (result != null)
            {
                result.CourseId = course.CourseId;
                result.CourseName = course.CourseName;
                _context.SaveChanges();
            }
        }
    }
}
