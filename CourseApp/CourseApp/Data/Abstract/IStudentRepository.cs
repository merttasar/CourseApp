using CourseApp.Entity;

namespace CourseApp.Data.Abstract
{
    public interface IStudentRepository
    {
        public IQueryable<Student> Students { get; }
        void CrateStudent(Student student);
        void RemoveStudent(Student student);
        void UpdateStudent(Student student);
    }
}
