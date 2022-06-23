using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UsersItem
{
public class UserItems {
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int IdModule {get; set;}
    public int IdEnroll {get; set;}
    public int IdTask {get; set;}
    public int IdClass {get; set;}
    public int DniUser {get; set;}
    public int Role {get;set;}
    public bool isActive {get;set;}
    public DateTime LastModified {get; set;}
    public string? NameUser {get; set;}

    public string? SurnameUser {get; set;}
    public string? EmailUser {get; set;}
    public string? Password {get; set;}    
    }
}