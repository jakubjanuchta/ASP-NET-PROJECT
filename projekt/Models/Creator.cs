using System.ComponentModel.DataAnnotations;

namespace projekt.Models;

public class Creator
{
    [Key]
    public int Id { get; set; }
    
    [Display(Name = "First Name")]
    [Required(ErrorMessage = "First Name is required")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "First Name must be between 3 and 50 chars")]
    public string FirstName { get; set; }
    
    [Display(Name = "Second Name")]
    [Required(ErrorMessage = "Second Name is required")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Second Name must be between 3 and 50 chars")]
    public string SecondName { get; set; }
    
    [Display(Name = "Biography")]
    [Required(ErrorMessage = "Biography is required")]
    public string Bio { get; set; }
}