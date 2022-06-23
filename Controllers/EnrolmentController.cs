using Microsoft.AspNetCore.Mvc;
using EnrollmentItem;
using Especialidad.Data;


namespace EnrollmentController;

[ApiController]
[Route("[Controller]")]

public class EnrollmentController : ControllerBase
{
    private readonly DataContext _context;
    private readonly EnrollmentRepository enrollmentRepository;
    public EnrollmentController(DataContext dataContext)
    {
        this.enrollmentRepository=new EnrollmentRepository(dataContext);
        _context = dataContext;
    }

    [HttpGet]
    public ActionResult<List<EnrollmentItems>> Get(){
        return Ok(enrollmentRepository.Get());
    //return Ok (_context.UserItem);
    }

    [HttpGet]
    [Route("/{NameUser}")]
    public ActionResult<EnrollmentItems> GetByUser(string NameUser)
    {
        return  Ok(enrollmentRepository.GetByUser(NameUser));
    }

    [HttpGet]
    [Route("/search/byModule/{NameModule}")]
    public ActionResult<EnrollmentItems> GetByModule(string NameModule)
    {
        return  Ok(enrollmentRepository.GetByModule(NameModule));
    }
    [HttpGet]
    [Route("/search/byEsp/{EspModule}")]
    public ActionResult<EnrollmentItems> GetByEsp(string EspModule)
    {
        return  Ok(enrollmentRepository.GetByEsp(EspModule));
    }



  
 [HttpPost]
    public ActionResult<EnrollmentItems> Post([FromBody] EnrollmentItems enrollmentItems)
    {
       
        return Ok (enrollmentRepository.Post(enrollmentItems));
    }
  



        [HttpPut("{IdEnroll:int}")]
    public ActionResult<EnrollmentItems> Update([FromBody] EnrollmentItems enrollmentItems, int IdEnroll)
    {
        EnrollmentItems enrollmentItemToUpdate = _context.EnrollmentItem.Find(IdEnroll);
        if (enrollmentItemToUpdate == null)
        {
            return NotFound("Elemento del carrito no encontrado");
        }
        enrollmentItemToUpdate.NameUser = enrollmentItems.NameUser;
        enrollmentItemToUpdate.IdEnroll = enrollmentItems.IdEnroll;
        _context.SaveChanges();
        string resourceUrl = Request.Path.ToString() + "/" + enrollmentItems.IdEnroll;

        return Created(resourceUrl, enrollmentItems);
    }
    /*[HttpDelete("{id:int}")]
    public ActionResult Delete()
    {
        return Ok(enrollmentRepository);
    }*/
        [HttpDelete("{id:int}")]
    public ActionResult Delete(int IdEnroll)
    {
        EnrollmentItems enrollmentItemToDelete = _context.EnrollmentItem.Find(IdEnroll);
        if (enrollmentItemToDelete == null)
        {
            return NotFound("Elemento del Especialidad no encontrado");
        }
        _context.EnrollmentItem.Remove(enrollmentItemToDelete);
        _context.SaveChanges();
        return Ok(enrollmentItemToDelete);
    }
        
    }
