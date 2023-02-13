using Microsoft.EntityFrameworkCore;
using projekt.Models;

namespace projekt.Services;

public interface IFurnitureService
{
    Task<IEnumerable<Furniture?>> GetAll();
    Task<Furniture?> GetById(int id);
    Task Add(FurnitureViewModel furniture);
    Task<FurnitureViewModel> Update(int id, FurnitureViewModel furniture);
    Task Delete(int id);
    Task<FurnitureDropDownVM> GetDropDownsValues();
}

public class FurnitureService : IFurnitureService
{
    private readonly AppDbContext _context;

    public FurnitureService(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Furniture?>> GetAll() => await _context.Furnitures
        .Include(x=>x.Company)
        .Include(x=>x.Creator)
        .Include(x=>x.Category)
        .ToListAsync();
    
    public async Task<Furniture?> GetById(int id) => await _context.Furnitures
        .Include(x=>x.Company)
        .Include(x=>x.Creator)
        .Include(x=>x.Category)
        .FirstOrDefaultAsync(c => c.Id == id);
    public async Task Add(FurnitureViewModel furniture)
    {
        var newFurniture = new Furniture()
        {
            Name = furniture.Name,
            ImageURL = furniture.ImageURL,
            ProductionDate = furniture.ProductionDate,
            CompanyId = furniture.CompanyId,
            CreatorId = furniture.CreatorId,
            CategoryId = furniture.CategoryId
        };
        await _context.Furnitures.AddAsync(newFurniture);
        await _context.SaveChangesAsync();
    }
    public  async Task<FurnitureViewModel> Update(int id, FurnitureViewModel furniture)
    {
        var dbFurniture = await _context.Furnitures.FirstOrDefaultAsync(x => x.Id == id);
        if (dbFurniture != null)
        {
            dbFurniture.Name = furniture.Name;
            dbFurniture.ImageURL = furniture.ImageURL;
            dbFurniture.ProductionDate = furniture.ProductionDate;
            dbFurniture.CompanyId = furniture.CompanyId;
            dbFurniture.CreatorId = furniture.CreatorId;
            dbFurniture.CategoryId = furniture.CategoryId;
            _context.Update(dbFurniture);
            await _context.SaveChangesAsync();
        }
            
        return furniture;
    }
    public async Task Delete(int id)
    {
        var result = await _context.Furnitures.FirstOrDefaultAsync(i => i.Id == id);
        _context.Furnitures.Remove(result);
        await _context.SaveChangesAsync();
    }

    public async Task<FurnitureDropDownVM> GetDropDownsValues()
    {
        var response = new FurnitureDropDownVM()
        {
            Categories = await _context.Categories.OrderBy(n => n.Name).ToListAsync(),
            Companies = await _context.Companies.OrderBy(n => n.Name).ToListAsync(),
            Creators = await _context.Creators.OrderBy(n => n.FirstName).ToListAsync()
        };

        return response;
    }
}