using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using projekt.Models;
using projekt.Models.Data.Static;
using projekt.Services;

namespace projekt.Controllers;

[Authorize(Roles = UserRoles.Admin)]
public class CompanyController : Controller
{
    private readonly ICompanyService _companyService;

    public CompanyController(ICompanyService companyService)
    {
        _companyService = companyService;
    }
    
    
    public async Task<IActionResult> Index()
    {
        var result = await _companyService.GetAll();
        return View(result);
    }
    public async Task<IActionResult> Details(int id)
    {
        var result = await _companyService.GetById(id);
        return View(result);
    }
    
    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([Bind("Name,Address,PhoneNumber")]Company company)
    {
        if (!ModelState.IsValid)
        {
            return View(company);
        }
        await _companyService.Add(company);
        return RedirectToAction(nameof(Index));
    }
    
    public async Task<IActionResult> Update(int id)
    {
        var result = await _companyService.GetById(id);
        if (result == null) return View("NotFound");
        return View(result);
    }
    
    [HttpPost]
    public async Task<IActionResult> Update(int id, [Bind("Name,Address,PhoneNumber")] Company company)
    {
        if (!ModelState.IsValid)
        {
            return View(company);
        }
        await _companyService.Update(id, company);
        return RedirectToAction(nameof(Index));
    }
    
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _companyService.GetById(id);
        if (result == null) return View("NotFound");
        return View(result);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var result = await _companyService.GetById(id);
        if (result == null) return View("NotFound");
        await _companyService.Delete(id);
        return RedirectToAction(nameof(Index));
    }
}