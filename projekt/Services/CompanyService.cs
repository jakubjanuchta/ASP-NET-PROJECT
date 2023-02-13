using Microsoft.EntityFrameworkCore;
using projekt.Models;

namespace projekt.Services;

public interface ICompanyService
{
    Task<IEnumerable<Company>> GetAll();
    Task<Company> GetById(int id);
    Task Add(Company company);
    Task<Company> Update(int id, Company company);
    Task Delete(int id);
}

public class CompanyService : ICompanyService
{
    private readonly AppDbContext _context;

    public CompanyService(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Company>> GetAll() => await _context.Companies.ToListAsync();
    
    public async Task<Company> GetById(int id) => await _context.Companies.FirstOrDefaultAsync(c => c.Id == id);
    public async Task Add(Company company)
    {
        await _context.Companies.AddAsync(company);
        await _context.SaveChangesAsync();
    }
    public  async Task<Company> Update(int id, Company company)
    {
        var dbResult =await  _context.Companies.FirstOrDefaultAsync(x => x.Id == id);
        if (dbResult != null)
        {
            dbResult.Name = company.Name;
            dbResult.Address = company.Address;
            dbResult.PhoneNumber = company.PhoneNumber;
        }
        _context.Update(dbResult);
        await _context.SaveChangesAsync();
        return company;
    }
    public async Task Delete(int id)
    {
        var result = await _context.Companies.FirstOrDefaultAsync(i => i.Id == id);
        _context.Companies.Remove(result);
        await _context.SaveChangesAsync();
    }
}