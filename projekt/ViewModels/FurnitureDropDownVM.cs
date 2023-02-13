namespace projekt.Models;

public class FurnitureDropDownVM
{
    public List<Category> Categories { get; set; }
    public List<Creator> Creators { get; set; }
    public List<Company> Companies { get; set; }
    public FurnitureDropDownVM()
    {
        Creators = new List<Creator>();
        Categories = new List<Category>();
        Companies = new List<Company>();
    }
}