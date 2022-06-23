using Microsoft.AspNetCore.Mvc;
using TaskItem;
using ClassItem;
using Especialidad.Data;


namespace ClassController;

[ApiController]
[Route("[Controller]")]

public class ClassController : ControllerBase
{
    private readonly DataContext _context;
    private readonly ClassRepository classRepository;
    public ClassController(DataContext dataContext)
    {
        this.classRepository=new ClassRepository(dataContext);
        _context = dataContext;
    }

    [HttpGet]
    public ActionResult<List<ClassItems>> Get(){
        return Ok(classRepository.Get());
    //return Ok (_context.UserItem);
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult<ClassItems> Get(int IdClass)
    {
    var ClassItems = _context.ClassItem.Find(IdClass);
        return ClassItems == null? NotFound()
            : Ok(ClassItems);
    }

 [HttpPost]
    public ActionResult<ClassItems> Post([FromBody] ClassItems classItems)
    {
       
        return Ok (classRepository.Post(classItems));
    }
    /*[HttpGet]
    public ActionResult<List<CarritoItems>> Get()
    {
        List<CarritoItems> carrito = _context.CarritoItem.ToList();
        return carrito == null? NoContent()
            : Ok(carrito);
    }*/

   /* [HttpPost]
    public ActionResult<DawItems> Post([FromBody] DawItems nombre_daw)
    {
         DawItems existingDawItems= _context.DawItem.Find(nombre_daw.id_daw);
        if (existingDawItems != null)
        {
            return Conflict("Ya existe un elemento ");
        }
        _context.DawItem.Add(nombre_daw);
        _context.SaveChanges();

        string resourceUrl = Request.Path.ToString() + "/" + nombre_daw.id_daw;
        return Created(resourceUrl, nombre_daw);
    }*/

    [HttpPut("{id:int}")]
    public ActionResult<ClassItems> Update([FromBody] ClassItems classes, int IdClass)
    {
        ClassItems classItemToUpdate = _context.ClassItem.Find(IdClass);
        if (classItemToUpdate == null)
        {
            return NotFound("Elemento del Especialidad no encontrado");
        }
        classItemToUpdate.NameSemester = classes.NameSemester;
        classItemToUpdate.IdClass = classes.IdClass;
        _context.SaveChanges();
        string resourceUrl = Request.Path.ToString() + "/" + classes.IdClass;

        return Created(resourceUrl, classes);
    }
    
    [HttpDelete("{id:int}")]
    public ActionResult Delete(int IdClass)
    {
        ClassItems classItemToDelete = _context.ClassItem.Find(IdClass);
        if (classItemToDelete == null)
        {
            return NotFound("Elemento del Especialidad no encontrado");
        }
        _context.ClassItem.Remove(classItemToDelete);
        _context.SaveChanges();
        return Ok(classItemToDelete);
    }
}