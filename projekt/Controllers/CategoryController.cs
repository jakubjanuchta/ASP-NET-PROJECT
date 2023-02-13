using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using projekt.Models;
using projekt.Models.Data.Static;
using projekt.Services;

namespace projekt.Controllers;
[Authorize(Roles = UserRoles.Admin)]
public class CategoryController : Controller
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    
    
    public async Task<IActionResult> Index()
    {
        var result = await _categoryService.GetAll();
        return View(result);
    }
    public async Task<IActionResult> Details(int id)
    {
        var result = await _categoryService.GetById(id);
        return View(result);
    }
    
    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([Bind("Name")]Category category)
    {
        if (!ModelState.IsValid)
        {
            return View(category);
        }
        await _categoryService.Add(category);
        return RedirectToAction(nameof(Index));
    }
    
    public async Task<IActionResult> Update(int id)
    {
        var result = await _categoryService.GetById(id);
        if (result == null) return View("NotFound");
        return View(result);
    }
    
    [HttpPost]
    public async Task<IActionResult> Update(int id, [Bind("Name")] Category category)
    {
        if (!ModelState.IsValid)
        {
            return View(category);
        }
        await _categoryService.Update(id, category);
        return RedirectToAction(nameof(Index));
    }
    
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _categoryService.GetById(id);
        if (result == null) return View("NotFound");
        return View(result);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var result = await _categoryService.GetById(id);
        if (result == null) return View("NotFound");
        await _categoryService.Delete(id);
        return RedirectToAction(nameof(Index));
    }
}