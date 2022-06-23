using Microsoft.AspNetCore.Mvc;
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
    }

    [HttpPost]
    public ActionResult<UserItems> Post([FromBody] UserItems userItems)
    {

        return Ok (userRepository.Post(userItems));
    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int IdModule)
    {
        UserItems userItemToDelete = _context.UserItem.Find(IdModule);
        if (userItemToDelete == null)
        {
            return NotFound("Elemento del usuarios no encontrado");
        }
        _context.UserItem.Remove(userItemToDelete);
        _context.SaveChanges();
        return Ok(userItemToDelete);
    }
}