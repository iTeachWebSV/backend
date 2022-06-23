using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnrollmentItem
{
public class EnrollmentItems {
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int IdEnroll {get; set;}
    public int Role {get; set;}
    public int Semester {get; set;}
    public string? NameEnrole {get; set;}
    public string? NameUser {get; set;}
    public string? NameModule {get; set;}
    public string? EspModule {get; set;}
    public string? Description {get; set;}
    public DateTime LastModified {get; set;}
    public bool isActive {get; set;}

    }
}