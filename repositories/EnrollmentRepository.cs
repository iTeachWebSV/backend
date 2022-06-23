using Especialidad.Data;
using EnrollmentItem;

public class EnrollmentRepository
{
    private readonly DataContext _context;
    public EnrollmentRepository(DataContext context)
    {
        this._context = context;
    }

    public List<EnrollmentItems> Get()
    {
        return this._context.EnrollmentItem.ToList();
    }


    public EnrollmentItems GetByUser(string NameUser)
    {
    return this._context.EnrollmentItem.Where(b => b.NameUser == NameUser)
        .FirstOrDefault();
    }
    public List< EnrollmentItems> GetByModule(string NameModule)
    {
     return this._context.EnrollmentItem.Where(b => b.NameModule == NameModule).ToList();
    }
    public  List<EnrollmentItems> GetByEsp(string EspModule)
    {
     return this._context.EnrollmentItem.Where(b => b.EspModule == EspModule).ToList();
        
    }

    public EnrollmentItems Post(EnrollmentItems enrollmentItems)
    {
        EnrollmentItems existingEnrollmentItems = _context.EnrollmentItem.Find(enrollmentItems.IdEnroll);
        if (existingEnrollmentItems != null)
        {
            throw new Exception("user not found");
        }
        _context.EnrollmentItem.Add(enrollmentItems);
        _context.SaveChanges();

        return enrollmentItems;
    }
    public EnrollmentItems Update(EnrollmentItems enrollmentItems)
    {
        EnrollmentItems existingEnrollmentItems = _context.EnrollmentItem.Find(enrollmentItems.IdEnroll);
        if (existingEnrollmentItems != null)
        {
            throw new Exception("user not found");
        }
        _context.EnrollmentItem.Add(enrollmentItems);
        _context.SaveChanges();

        return enrollmentItems;
    }
    
    
     public EnrollmentItems Remove(EnrollmentItems enrollmentItems)
    {
        EnrollmentItems enrollmentItemToDelete = _context.EnrollmentItem.Find(enrollmentItems.IdEnroll);
        if (enrollmentItemToDelete == null)
        {
            throw new Exception("user not found");
        }
        _context.EnrollmentItem.Remove(enrollmentItemToDelete);
        _context.SaveChanges();
        return enrollmentItems;

    }
}