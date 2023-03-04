using System.ComponentModel.DataAnnotations;

namespace MyHrProject.Models;

public class Staff
{
    [Display(Name = "Staff Id")] [Key] public Guid Id { get; set; }
    [Display(Name = "First Name")] public string FirstName { get; set; }
    [Display(Name = "Middle Name")] public string? MiddleName { get; set; }
    [Display(Name = "Last Name")] public string LastName { get; set; }

    [Display(Name = "Mailing Address")] public string Address { get; set; }

    [Display(Name = "Work Phone Number")]
    [DataType(DataType.PhoneNumber)]
    public string WorkPhoneNumber { get; set; }

    [DataType(DataType.PhoneNumber)]
    [Display(Name = "Personal Phone Number")]
    public string PersonalPhoneNumber { get; set; }

    [Display(Name = "Email Address")]
    [DataType(DataType.EmailAddress)]
    public string Emailaddress { get; set; }

    [Display(Name = "Date of Birth")]
    [DataType(DataType.Date)]
    public DateTime DateOfBirth { get; set; }

    [Display(Name = "Emergency Contact Full Name")]
    public string EmergencyContactFullName { get; set; }

    [Display(Name = "Emergency Contact Phone Number")]
    public string EmergencyContactPhoneNumber { get; set; }

    [Display(Name = "Relationship to Employee")]
    public string RelationshipToEmployee { get; set; }

    [Display(Name = "Job Title")] public string JobTitle { get; set; }

    [Display(Name = "Department")] public string Department { get; set; }
}