using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestTask.Data;

public class Contact
{
    [Key]
    public int ContactId { get; set; }
    [Display(Name = "Enter the name")]
    public String Name { get; set; } = String.Empty;
    
    [Display(Name = "Enter the surname")]
    public String Surname { get; set; } = string.Empty;

    [Display(Name = "Enter the phone number")]
    public String MobilePhone { get; set; } = String.Empty;
    [Display(Name = "Enter the job title")]
    public String JobTitle { get; set; } = String.Empty;
    [Display(Name = "Enter the birth date")]
    public DateTime BirthDate { get; set; }
}