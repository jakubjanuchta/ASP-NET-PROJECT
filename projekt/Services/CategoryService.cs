using Microsoft.EntityFrameworkCore;
using projekt.Models;

namespace projekt.Services;

public interface ICategoryService
{
    Task<IEnumerable<Category>> GetAll();
    Task<Category> GetById(int id);
    Task Add(Category category);
    Task<Category> Update(int id, Category category);
    Task Delete(int id);
}

public class CategoryService : ICategoryService
{
    private readonly AppDbContext _context;

    public CategoryService(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Category>> GetAll() => await _context.Categories.ToListAsync();
    
    public async Task<Category> GetById(int id) => await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
    public async Task Add(Category category)
    {
        await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();
    }
    public  async Task<Category> Update(int id, Category category)
    {
        var dbResult = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
        if (dbResult != null)
        {
            dbResult.Name = category.Name;
        }
        _context.Update(dbResult);
        await _context.SaveChangesAsync();
        return category;
    }
    public async Task Delete(int id)
    {
        var result = await _context.Categories.FirstOrDefaultAsync(i => i.Id == id);
        _context.Categories.Remove(result);
        await _context.SaveChangesAsync();
    }
}