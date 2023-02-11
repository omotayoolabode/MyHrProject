using System.ComponentModel.DataAnnotations;

namespace MyHrProject.Models;

public class Staff
{
    [Display(Name = "Staff Id")]
    [Key]
    public Guid Id { get; set; }
    [Display(Name = "First Name")]
    public string? FirstName { get; set; } 
    [Display(Name = "Middle Name")]
    public string? MiddleName {get; set;}
    [Display(Name = "Last Name")]
    public string? LastName { get; set; }
    
}