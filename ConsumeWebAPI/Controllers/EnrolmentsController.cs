using ConsumeWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

public class EnrolmentsController : Controller
{
    private readonly EnrolmentService _enrolmentService;

    public EnrolmentsController(EnrolmentService enrolmentService)
    {
        _enrolmentService = enrolmentService;
    }

    public async Task<IActionResult> Index()
    {
        var enrolments = await _enrolmentService.GetEnrolmentsAsync();
        return View(enrolments);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Enrolment enrolment)
    {
        if (ModelState.IsValid)
        {
            await _enrolmentService.CreateEnrolmentAsync(enrolment);
            return RedirectToAction("Index");
        }
        return View(enrolment);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var enrolment = await _enrolmentService.GetEnrolmentByIdAsync(id);
        if (enrolment == null) return NotFound();
        return View(enrolment);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Enrolment enrolment)
    {
        if (ModelState.IsValid)
        {
            await _enrolmentService.UpdateEnrolmentAsync(enrolment);
            return RedirectToAction("Index");
        }
        return View(enrolment);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var enrolment = await _enrolmentService.GetEnrolmentByIdAsync(id);
        if (enrolment == null) return NotFound();
        return View(enrolment);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _enrolmentService.DeleteEnrolmentAsync(id);
        return RedirectToAction("Index");
    }
}
