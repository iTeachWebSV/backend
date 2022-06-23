using Microsoft.AspNetCore.Mvc;
using ModuleItem;
using Especialidad.Data;
namespace ModuleController;

[ApiController]
[Route("[Controller]")]

public class ModuleController : ControllerBase
{
    private readonly DataContext _context;
    private readonly ModuleRepository moduleRepository;
    public ModuleController(DataContext dataContext)
    {
        this.moduleRepository=new ModuleRepository(dataContext);
        _context = dataContext;
    }

    [HttpGet]
    public ActionResult<List<ModuleItems>> Get(){
        return Ok(moduleRepository.Get());
    //return Ok (_context.UserItem);
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult<ModuleItems> Get(int IdModule)
    {
    var ModuleItems = _context.ModuleItem.Find(IdModule);
        return ModuleItems == null? NotFound()
            : Ok(ModuleItems);
    }

 [HttpPost]
    public ActionResult<ModuleItems> Post([FromBody] ModuleItems moduleItems)
    {
       
        return Ok (moduleRepository.Post(moduleItems));
    }
    

    [HttpPut("{id:int}")]
    public ActionResult<ModuleItems> Update([FromBody] ModuleItems asignatura, int IdModule)
    {
        ModuleItems moduleItemToUpdate = _context.ModuleItem.Find(IdModule);
        if (moduleItemToUpdate == null)
        {
            return NotFound("Elemento del Especialidad no encontrado");
        }
        moduleItemToUpdate.NameModule = asignatura.NameModule;
        moduleItemToUpdate.EspModule = asignatura.EspModule;
        moduleItemToUpdate.Descripcion = asignatura.Descripcion;
        moduleItemToUpdate.IdModule = asignatura.IdModule;
        _context.SaveChanges();
        string resourceUrl = Request.Path.ToString() + "/" + asignatura.IdModule;

        return Created(resourceUrl, asignatura);
    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int IdModule)
    {
        ModuleItems moduleItemToDelete = _context.ModuleItem.Find(IdModule);
        if (moduleItemToDelete == null)
        {
            return NotFound("Elemento del Especialidad no encontrado");
        }
        _context.ModuleItem.Remove(moduleItemToDelete);
        _context.SaveChanges();
        return Ok(moduleItemToDelete);
    }
}