using Especialidad.Data;
using ClassItem;

public class ClassRepository
{
    private readonly DataContext _context;
    public ClassRepository(DataContext context)
    {
        this._context = context;
    }

    public List<ClassItems> Get()
    {
        return this._context.ClassItem.ToList();
    }
    public ClassItems Post(ClassItems classItems)
    {
        ClassItems existingClassItems = _context.ClassItem.Find(classItems.IdClass);
        if (existingClassItems != null)
        {
            throw new Exception("user not found");
        }
        _context.ClassItem.Add(classItems);
        _context.SaveChanges();

        return classItems;
    }
}