using projekt.Models;
using Microsoft.EntityFrameworkCore;

namespace projekt.Models;

public class AppDbContext: DbContext
{
    public DbSet<Furniture> Furnitures { get; set; }
    private string DbPath;
    public AppDbContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "furnitures.db");
    }
    
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data Source={DbPath}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Furniture>().HasData(
            new Furniture() {Id= 1, Label = "ASP.NET 6.0.0", ProductionDate = DateTime.Parse("2022-02-13"), Created = DateTime.Now},
            new Furniture() {Id= 2, Label = "C# 10.0", ProductionDate = DateTime.Parse("2022-02-13"), Created = DateTime.Now},
            new Furniture() {Id= 3, Label = "Java 19", ProductionDate = DateTime.Parse("2021-12-23"), Created = DateTime.Now},
            new Furniture() {Id= 4, Label = "JavaScript", ProductionDate = DateTime.Parse("2022-08-05"), Created = DateTime.Now},
            new Furniture() {Id= 5, Label = "Node.js", ProductionDate = DateTime.Parse("2019-10-10"), Created = DateTime.Now}
        );
    }
    
    
}