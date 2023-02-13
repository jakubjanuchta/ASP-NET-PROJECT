using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using projekt.Models;
using projekt.Models.Data.Static;
using projekt.Services;

namespace projekt.Controllers;
[Authorize(Roles = UserRoles.Admin)]
public class CreatorController : Controller
{
    private readonly ICreatorService _creatorService;

    public CreatorController(ICreatorService creatorService)
    {
        _creatorService = creatorService;
    }
    
    
    public async Task<IActionResult> Index()
    {
        var result = await _creatorService.GetAll();
        return View(result);
    }
    public async Task<IActionResult> Details(int id)
    {
        var result = await _creatorService.GetById(id);
        return View(result);
    }
    
    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([Bind("FirstName,SecondName,Bio")]Creator creator)
    {
        if (!ModelState.IsValid)
        {
            return View(creator);
        }
        await _creatorService.Add(creator);
        return RedirectToAction(nameof(Index));
    }
    
    public async Task<IActionResult> Update(int id)
    {
        var result = await _creatorService.GetById(id);
        if (result == null) return View("NotFound");
        return View(result);
    }
    
    [HttpPost]
    public async Task<IActionResult> Update(int id, [Bind("FirstName,SecondName,Bio")] Creator creator)
    {
        if (!ModelState.IsValid)
        {
            return View(creator);
        }
        await _creatorService.Update(id, creator);
        return RedirectToAction(nameof(Index));
    }
    
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _creatorService.GetById(id);
        if (result == null) return View("NotFound");
        return View(result);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var result = await _creatorService.GetById(id);
        if (result == null) return View("NotFound");
        await _creatorService.Delete(id);
        return RedirectToAction(nameof(Index));
    }
}