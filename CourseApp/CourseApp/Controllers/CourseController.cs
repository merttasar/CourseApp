using CourseApp.Data.Abstract;
using CourseApp.Entity;
using CourseApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CourseApp.Controllers
{
    public class CourseController : Controller
    {
        public readonly ICourseRepository _courseRepository;
        public CourseController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
        public IActionResult Index()
        {
            var courses = _courseRepository.Courses.ToList();

            return View(courses);
        }
        public IActionResult CreateCourse()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCourse(CourseCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                _courseRepository.CreateCourse(new Course
                {
                    CourseName = model.CourseName
                });
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public async Task<IActionResult> RemoveCourse(int? id)
        {
            if (id != null)
            {
                var result = await _courseRepository.Courses.FirstOrDefaultAsync(i => i.CourseId == id);
                if (result != null)
                {
                    _courseRepository.RemoveCourse(result);
                    return RedirectToAction("Index");
                }

            }
            return RedirectToAction("Index");
        }
        public IActionResult UpdateCourse(int? id)
        {
            if (id != null)
            {
                var result = _courseRepository.Courses.FirstOrDefault(i => i.CourseId == id);
                return View("UpdateCourse", result);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public IActionResult UpdateCourse(Course course)
        {
            if (course != null)
            {
                var courseUpdate = new Course
                {
                    CourseId = course.CourseId,
                    CourseName = course.CourseName
                };
                _courseRepository.UpdateCourse(courseUpdate);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

    }
}
