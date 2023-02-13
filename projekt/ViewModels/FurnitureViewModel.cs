using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projekt.Models;

public class FurnitureViewModel
{
    public int Id { get; set; }
    
    [Display(Name = "Furniture")]
    [Required(ErrorMessage = "Furniture is required")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Furniture must be between 3 and 50 chars")]
    public string Name { get; set; }
    
    [Display(Name = "Furniture Image")]
    [Required(ErrorMessage = "Furniture Image is required")]
    public string ImageURL { get; set; }
    
    [Display(Name = "Production Date")]
    [Required(ErrorMessage = "Production Date is required")]
    public DateTime ProductionDate { get; set; }
    
    
    [Display(Name = "Company")]
    [Required(ErrorMessage = "Company is required")]
    public int CompanyId { get; set; }

    
    
    [Display(Name = "Creator")]
    [Required(ErrorMessage = "Creator is required")]
    public int CreatorId { get; set; }

    
    
    [Display(Name = "Category")]
    [Required(ErrorMessage = "Category is required")]
    public int CategoryId { get; set; }
}