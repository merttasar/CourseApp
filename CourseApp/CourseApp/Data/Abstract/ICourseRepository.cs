using CourseApp.Entity;

namespace CourseApp.Data.Abstract
{
    public interface ICourseRepository
    {
        public IQueryable<Course> Courses { get; }
        public void CreateCourse(Course course);
        public void RemoveCourse(Course course);
        public void UpdateCourse(Course course);
    }
}
