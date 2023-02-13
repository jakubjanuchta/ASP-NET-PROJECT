using System.ComponentModel.DataAnnotations;

namespace projekt.Models;

public class Category
{
    [Key]
    public int Id { get; set; }
    
    [Display(Name = "Category Name")]
    [Required(ErrorMessage = "Category name is required")]
    public string Name { get; set; }
}