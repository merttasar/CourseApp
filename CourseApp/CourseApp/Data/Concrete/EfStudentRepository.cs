using CourseApp.Data.Abstract;
using CourseApp.Entity;
using Microsoft.EntityFrameworkCore;

namespace CourseApp.Data.Concrete
{
    public class EfStudentRepository : IStudentRepository
    {
        public CourseContext _context;
        public EfStudentRepository(CourseContext context)
        {
            _context = context;
        }
        public IQueryable<Student> Students => _context.Students;

        public void CrateStudent(Student student)
        {


            _context.Students.Add(new Student
            {
                StudentId = student.StudentId,
                FirstName = student.FirstName,
                LastName = student.LastName,
                BirthDate = student.BirthDate,
                Courses = student.Courses
            });
            _context.SaveChanges();
        }

        public void RemoveStudent(Student student)
        {
            _context.Students.Remove(student);
            _context.SaveChanges();
        }

        public void UpdateStudent(Student student)
        {
            var entity = _context.Students.Include(x => x.Courses).FirstOrDefault(i => i.StudentId == student.StudentId);
            if (entity != null)
            {
                entity.FirstName = student.FirstName;
                entity.LastName = student.LastName;
                entity.BirthDate = student.BirthDate;

                entity.Courses = student.Courses;

                _context.SaveChanges();
            }
        }

    }
}
