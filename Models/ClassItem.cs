using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassItem
{
public class ClassItems {
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int IdClass {get; set;}
    public string? NameSemester {get; set;}
    public string? NameUser {get; set;}
     public string? NameModule {get; set;}
      public string? NameEnroll {get; set;}
    public int Semester {get; set;}
    public int Role {get; set;}
    public DateTime LastModified {get; set;}
    public bool isActive {get; set;}  
    }
}