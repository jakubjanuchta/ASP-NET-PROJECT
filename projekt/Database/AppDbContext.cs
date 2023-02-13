using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using projekt.Models;
using Microsoft.EntityFrameworkCore;

namespace projekt.Models;

public class AppDbContext: IdentityDbContext<ApplicationUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    
    
    public DbSet<Furniture> Furnitures { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Creator> Creators { get; set; }
 
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}