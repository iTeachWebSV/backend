using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModuleItem

{
public class ModuleItems {
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int IdModule {get; set;}
    public string? NameModule {get; set;}
    public string? EspModule {get; set;}
    public DateTime LastModified {get; set;}  
    public bool isActive {get; set;}  
    public string Descripcion {get; set;}  
    }
}