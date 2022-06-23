using Microsoft.AspNetCore.Mvc;
using ModuleItem;
using TaskItem;
using Especialidad.Data;
using UsersItem;

namespace UsersController;

[ApiController]
[Route("[Controller]")]

public class UserController : ControllerBase
{
    private readonly DataContext _context;
    private readonly UserRepository userRepository;
    public UserController(DataContext dataContext)
    {
        this.userRepository=new UserRepository(dataContext);
        _context = dataContext;
    }

    [HttpGet]
    public ActionResult<List<UserItems>> Get(){
        return Ok(userRepository.Get());
    //return Ok (_context.UserItem);
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult<UserItems> Get(int DniUser)
    {
    var UserItems = _context.UserItem.Find(DniUser); // linq pasar parametros
        return UserItems == null? NotFound()
            : Ok(UserItems);
    }
    /*[HttpGet]
    public ActionResult<List<CarritoItems>> Get()
    {
        List<CarritoItems> carrito = _context.CarritoItem.ToList();
        return carrito == null? NoContent()
            : Ok(carrito);
    }*/

    [HttpPost]
    public ActionResult<UserItems> Post([FromBody] UserItems userItems)
    {
        /* UserItems existingUserItems= _context.UserItem.Find(user.dni_user);
        if (existingUserItems != null)
        {
            return Conflict("Ya existe un elemento ");
        }
        _context.UserItem.Add(user);
        _context.SaveChanges();

        string resourceUrl = Request.Path.ToString() + "/" + user.dni_user;
        return Created(resourceUrl, user);*/
        return Ok (userRepository.Post(userItems));
    }

    [HttpPut("{id:int}")]
    public ActionResult<UserItems> Update([FromBody] UserItems user, int DniUser)
    {
        UserItems carritotItemToUpdate = _context.UserItem.Find(DniUser);
        if (carritotItemToUpdate == null)
        {
            return NotFound("Elemento del carrito no encontrado");
        }
        carritotItemToUpdate.NameUser = user.NameUser;
        carritotItemToUpdate.DniUser = user.DniUser;
        _context.SaveChanges();
        string resourceUrl = Request.Path.ToString() + "/" + user.DniUser;

        return Created(resourceUrl, user);
    }
    
    [HttpDelete("{id:int}")]
    public ActionResult Delete(int DniUser)
    {
        UserItems userItemToDelete = _context.UserItem.Find(DniUser);
        if (userItemToDelete == null)
        {
            return NotFound("Elemento del usuarios no encontrado");
        }
        _context.UserItem.Remove(userItemToDelete);
        _context.SaveChanges();
        return Ok(userItemToDelete);
    }
}