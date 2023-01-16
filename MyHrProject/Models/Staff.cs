using System.ComponentModel.DataAnnotations;

namespace MyHrProject.Models;

public class Staff
{
    [Display(Name = "Staff Id")]
    [Key]
    public Guid Id { get; set; }
    [Display(Name = "First Name")]
    public string FirstName { get; set; }  
}