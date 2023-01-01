using projekt.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using projekt.Models;

namespace projekt.Controllers;

public class FurnitureController : Controller
{

    private static AppDbContext _context = new AppDbContext();
    // GET
    public IActionResult Index()
    {
        return View(_context.Furnitures.ToList());
    }

    public IActionResult Edit([FromRoute] int id)
    {
        Furniture? foundFurniture = _context.Furnitures.Find(id);
        if (foundFurniture is not null)
        {
            return View(foundFurniture);
        }

        return RedirectToAction(nameof(Index));
    }
    [HttpPost]
    public IActionResult Edit([FromForm] Furniture furniture)
    {
        if (ModelState.IsValid)
        {
            Furniture? foundFurniture = _context.Furnitures.Find(furniture.Id);
            if (foundFurniture is not null)
            {
                foundFurniture.Label = furniture.Label;
                foundFurniture.ProductionDate = furniture.ProductionDate;
                foundFurniture.ImageLink = furniture.ImageLink;
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
        }
        return View();
    }

    [HttpPost]
    public IActionResult Create([FromForm] Furniture furniture)
    {
        if (ModelState.IsValid)
        {
            _context.Furnitures.Add(furniture);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        return View();
    }

    public IActionResult Create()
    {
        return View();
    }

    public IActionResult Delete([FromRoute] int id)
    {
        Furniture? foundFurniture = _context.Furnitures.Find(id);
        _context.Furnitures.Remove(foundFurniture);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Details([FromRoute] int id)
    {
        Furniture? foundFurniture = _context.Furnitures.Find(id);
        return foundFurniture is not null ? View(foundFurniture) : RedirectToAction(nameof(Index));
    }
}