using System.ComponentModel.DataAnnotations;

namespace projekt.Models;

public class Company
{
    [Key]
    public int Id { get; set; }
    
    [Display(Name = "Company Name")]
    [Required(ErrorMessage = "Company Name is required")]
    public string Name { get; set; }
    
    [Display(Name = "Company Address")]
    [Required(ErrorMessage = "Company Address required")]
    public string Address { get; set; }
    
    [Display(Name = "Company phone number")]
    [DataType(DataType.PhoneNumber)]
    [Required(ErrorMessage = "Not a valid phone number")]
    public string PhoneNumber { get; set; }
}