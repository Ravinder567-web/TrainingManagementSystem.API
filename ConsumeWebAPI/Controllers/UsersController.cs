using ConsumeWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

public class UsersController : Controller
{
    private readonly UserService _userService;

    public UsersController(UserService userService)
    {
        _userService = userService;
    }

    public async Task<IActionResult> Index()
    {
        var users = await _userService.GetUsersAsync();
        return View(users);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(User user)
    {
        if (ModelState.IsValid)
        {
            await _userService.CreateUserAsync(user);
            return RedirectToAction("Index");
        }
        return View(user);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var user = await _userService.GetUserByIdAsync(id);
        if (user == null) return NotFound();
        return View(user);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(User user)
    {
        if (ModelState.IsValid)
        {
            await _userService.UpdateUserAsync(user);
            return RedirectToAction("Index");
        }
        return View(user);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var user = await _userService.GetUserByIdAsync(id);
        if (user == null) return NotFound();
        return View(user);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _userService.DeleteUserAsync(id);
        return RedirectToAction("Index");
    }
}
