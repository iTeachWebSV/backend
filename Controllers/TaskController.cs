using Microsoft.AspNetCore.Mvc;
using TaskItem;
using Especialidad.Data;

namespace TaskController;

[ApiController]
[Route("[Controller]")]



public class TaskController : ControllerBase
{
    private readonly DataContext _context;
    private readonly TaskRepository taskRepository;
    public TaskController(DataContext dataContext)
    {
        this.taskRepository=new TaskRepository(dataContext);
        _context = dataContext;
    }

    [HttpGet]
    
    public ActionResult<List<TaskItems>> Get(){
        return Ok(taskRepository.Get());
    //return Ok (_context.UserItem);
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult<TaskItems> Get(int IdTask)
    {
    var TaskItems = _context.TaskItem.Find(IdTask);
        return TaskItems == null? NotFound()
            : Ok(TaskItems);
    }

 [HttpPost]
    public ActionResult<TaskItems> Post([FromBody] TaskItems taskItems)
    {
       
        return Ok (taskRepository.Post(taskItems));
    }

    /*[HttpGet]
    public ActionResult<List<CarritoItems>> Get()
    {
        List<CarritoItems> carrito = _context.CarritoItem.ToList();
        return carrito == null? NoContent()
            : Ok(carrito);
    }*/

    /*[HttpPost]
    public ActionResult<GradesItems> Post([FromBody] GradesItems calificacion )
    {
         GradesItems existingGradesItems= _context.GradesItem.Find(calificacion.id_ab);
        if (existingGradesItems != null)
        {
            return Conflict("Ya existe un elemento ");
        }
        
        _context.GradesItem.Add(calificacion);
        _context.SaveChanges();

        string resourceUrl = Request.Path.ToString() + "/" + calificacion.id_ab +calificacion.id_dam+calificacion.id_daw;
        return Created(resourceUrl, calificacion);
    }
*/
    [HttpPut("{id:int}")]
    public ActionResult<TaskItems> Update([FromBody] TaskItems notas, int IdTask )
    {
        TaskItems taskItemToUpdate = _context.TaskItem.Find(IdTask);
        if (taskItemToUpdate == null)
        {
            return NotFound("Elemento del Especialidad no encontrado");
        }
        taskItemToUpdate.ScoreTask = notas.ScoreTask;
        taskItemToUpdate.IdTask = notas.IdTask;
        
        _context.SaveChanges();
        string resourceUrl = Request.Path.ToString() + "/" + notas.IdTask;

        return Created(resourceUrl, notas);
    }
    
    [HttpDelete("{id:int}")]
    public ActionResult Delete(int ScoreTask)
    {
        TaskItems taskItemToDelete = _context.TaskItem.Find(ScoreTask);
        if (taskItemToDelete == null)
        {
            return NotFound("Elemento del Especialidad no encontrado");
        }
        _context.TaskItem.Remove(taskItemToDelete);
        _context.SaveChanges();
        return Ok(taskItemToDelete);
    }
}