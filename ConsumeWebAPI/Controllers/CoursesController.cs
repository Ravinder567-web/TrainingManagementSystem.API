using ConsumeWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

public class CoursesController : Controller
{
    private readonly CourseService _courseService;

    public CoursesController(CourseService courseService)
    {
        _courseService = courseService;
    }

    public async Task<IActionResult> Index()
    {
        var courses = await _courseService.GetCoursesAsync();
        return View(courses);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Course course)
    {
        if (ModelState.IsValid)
        {
            await _courseService.CreateCourseAsync(course);
            return RedirectToAction("Index");
        }
        return View(course);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var course = await _courseService.GetCourseByIdAsync(id);
        if (course == null) return NotFound();
        return View(course);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Course course)
    {
        if (ModelState.IsValid)
        {
            await _courseService.UpdateCourseAsync(course);
            return RedirectToAction("Index");
        }
        return View(course);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var course = await _courseService.GetCourseByIdAsync(id);
        if (course == null) return NotFound();
        return View(course);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _courseService.DeleteCourseAsync(id);
        return RedirectToAction("Index");
    }
}
