using Microsoft.EntityFrameworkCore;
using projekt.Models;

namespace projekt.Services;

public interface ICreatorService
{
    Task<IEnumerable<Creator>> GetAll();
    Task<Creator> GetById(int id);
    Task Add(Creator creator);
    Task<Creator> Update(int id, Creator creator);
    Task Delete(int id);
}

public class CreatorService : ICreatorService
{
    private readonly AppDbContext _context;

    public CreatorService(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Creator>> GetAll() => await _context.Creators.ToListAsync();
    
    public async Task<Creator> GetById(int id) => await _context.Creators.FirstOrDefaultAsync(c => c.Id == id);
    public async Task Add(Creator creator)
    {
        await _context.Creators.AddAsync(creator);
        await _context.SaveChangesAsync();
    }
    public  async Task<Creator> Update(int id, Creator creator)
    {
        var dbResult = await _context.Creators.FirstOrDefaultAsync(x => x.Id == id);
        if (dbResult != null)
        {
            dbResult.FirstName = creator.FirstName;
            dbResult.SecondName = creator.SecondName;
            dbResult.Bio = creator.Bio;
        }
        _context.Update(dbResult);
        await _context.SaveChangesAsync();
        return creator;
    }
    public async Task Delete(int id)
    {
        var result = await _context.Creators.FirstOrDefaultAsync(i => i.Id == id);
        _context.Creators.Remove(result);
        await _context.SaveChangesAsync();
    }
}