using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace projekt.Models;

public class ApplicationUser : IdentityUser
{
    [Display(Name = "Name")]

    public string FullName { get; set; }
}