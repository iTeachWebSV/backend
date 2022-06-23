using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskItem
{
public class TaskItems {
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int IdTask {get; set;}
    public string? NameTask {get; set;}
    public string? EspModule {get; set;}
    public string? NameModule{get; set;}
    public string? NameUser {get; set;}
    public int ScoreTask {get; set;}    
    public int Role {get; set;}  
    }
}