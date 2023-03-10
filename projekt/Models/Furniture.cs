using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace projekt.Models;

public class Furniture
{
    [Key]
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

    public int CompanyId { get; set; }

    [Display(Name = "Company")]
    [Required(ErrorMessage = "Company is required")]
    [ForeignKey("CompanyId")]
    public Company Company { get; set; }

    public int CreatorId { get; set; }

    [Display(Name = "Creator")]
    [Required(ErrorMessage = "Creator is required")]
    [ForeignKey("CreatorId")]
    public Creator Creator { get; set; }

    public int CategoryId { get; set; }

    [Display(Name = "Category")]
    [Required(ErrorMessage = "Category is required")]
    [ForeignKey("CategoryId")]
    public Category Category { get; set; }
}