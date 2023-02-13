using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using projekt.Models;
using projekt.Models.Data.Static;
using projekt.Services;

namespace projekt.Controllers;

[Authorize(Roles = UserRoles.Admin)]
public class FurnitureController : Controller
{
    private readonly IFurnitureService _furnitureService;

    public FurnitureController(IFurnitureService furnitureService)
    {
        _furnitureService = furnitureService;
    }


    [AllowAnonymous]
    public async Task<IActionResult> Index()
    {
        var result = await _furnitureService.GetAll();
        return View(result);
    }

    [AllowAnonymous]
    public async Task<IActionResult> Details(int id)
    {
        var result = await _furnitureService.GetById(id);
        return View(result);
    }
    [AllowAnonymous]
    public async Task<IActionResult> Buy()
    {
        return View();
    }

    public async Task<IActionResult> Create()
    {
        var dropdown = await _furnitureService.GetDropDownsValues();

        ViewBag.Creators = new SelectList(dropdown.Creators, "Id", "FirstName");
        ViewBag.Companies = new SelectList(dropdown.Companies, "Id", "Name");
        ViewBag.Categories = new SelectList(dropdown.Categories, "Id", "Name");

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(FurnitureViewModel furniture)
    {
        if (!ModelState.IsValid)
        {
            var dropdown = await _furnitureService.GetDropDownsValues();

            ViewBag.Creators = new SelectList(dropdown.Creators, "Id", "FirstName");
            ViewBag.Companies = new SelectList(dropdown.Companies, "Id", "Name");
            ViewBag.Categories = new SelectList(dropdown.Categories, "Id", "Name");

            return View(furniture);
        }

        await _furnitureService.Add(furniture);
        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Update(int id)
    {
        var details = await _furnitureService.GetById(id);
        if (details == null) return View("NotFound");

        var response = new FurnitureViewModel()
        {
            Id = details.Id,
            Name = details.Name,
            ImageURL = details.ImageURL,
            ProductionDate = details.ProductionDate,
            CompanyId = details.CompanyId,
            CreatorId = details.CreatorId,
            CategoryId = details.CategoryId,
        };

        var dropdown = await _furnitureService.GetDropDownsValues();

        ViewBag.Creators = new SelectList(dropdown.Creators, "Id", "FirstName");
        ViewBag.Companies = new SelectList(dropdown.Companies, "Id", "Name");
        ViewBag.Categories = new SelectList(dropdown.Categories, "Id", "Name");

        return View(response);
    }

    [HttpPost]
    public async Task<IActionResult> Update(int id, FurnitureViewModel furniture)
    {
        if (id != furniture.Id) return View("NotFound");

        if (!ModelState.IsValid)
        {
            var dropdown = await _furnitureService.GetDropDownsValues();

            ViewBag.Creators = new SelectList(dropdown.Creators, "Id", "FirstName");
            ViewBag.Companies = new SelectList(dropdown.Companies, "Id", "Name");
            ViewBag.Categories = new SelectList(dropdown.Categories, "Id", "Name");

            return View(furniture);
        }

        await _furnitureService.Update(id, furniture);
        return RedirectToAction(nameof(Index));
    }
}