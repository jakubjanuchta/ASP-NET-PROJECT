using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace projekt.Models;

public class Furniture
{
    [HiddenInput]
    public int Id { get; set; }
    [Required]
    [Display(Name = "Name")]
    public string Label { get; set; }
    [Required]
    [Display(Name = "Production Date")]
    [DataType(DataType.Date)]
    public DateTime ProductionDate { get; set; }
    [Display(Name = "Image Link")]
    public string? ImageLink { get; set; }
    public DateTime Created { get; set; }
}