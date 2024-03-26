using CourseApp.Data.Abstract;
using CourseApp.Entity;
using CourseApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CourseApp.Controllers
{
    public class StudentController : Controller
    {
        public readonly IStudentRepository _studentRepository;
        public readonly ICourseRepository _courseRepository;
        public StudentController(IStudentRepository studentRepository, ICourseRepository courseRepository)
        {
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
        }
        public IActionResult Index()
        {
            var users = _studentRepository.Students.ToList();
            return View(users);
        }
        public IActionResult CreateStudent()
        {
            ViewBag.Courses = _courseRepository.Courses.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult CreateStudent(StudentCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var courses = _courseRepository.Courses.Where(x => model.CourseIds.Contains(x.CourseId)).ToList();
                _studentRepository.CrateStudent(
                    new Student { FirstName = model.FirstName, LastName = model.LastName, BirthDate = model.BirthDate, Courses = courses });
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public async Task<IActionResult> RemoveStudent(int? id)
        {
            if (id != null)
            {
                var result = await _studentRepository.Students.FirstOrDefaultAsync(i => i.StudentId == id);
                if (result != null)
                {
                    _studentRepository.RemoveStudent(result);
                    return RedirectToAction("Index");

                }
            }
            return View("index");
        }
        public IActionResult UpdateStudent(int? id)
        {
            if (id != null)
            {
                var result = _studentRepository.Students.Include(x => x.Courses).FirstOrDefault(i => i.StudentId == id);
                ViewBag.Courses = _courseRepository.Courses.ToList();
                return View(result);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult UpdateStudent(StudentCreateViewModel student)
        {

            if (student != null)
            {
                var item = _courseRepository.Courses.Where(i => student.CourseIds.Contains(i.CourseId)).ToList();
                var studentUpdate = new Student { StudentId = student.StudentId, FirstName = student.FirstName, LastName = student.LastName, BirthDate = student.BirthDate, Courses = item };
                _studentRepository.UpdateStudent(studentUpdate);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

        }
    }
}
