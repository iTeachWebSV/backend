using Especialidad.Data;
using ModuleItem;

public class ModuleRepository
{
    private readonly DataContext _context;
    public ModuleRepository(DataContext context)
    {
        this._context = context;
    }

    public List<ModuleItems> Get()
    {
        return this._context.ModuleItem.ToList();
    }
    public ModuleItems Post(ModuleItems moduleItems)
    {
        ModuleItems existingModuleItems = _context.ModuleItem.Find(moduleItems.IdModule);
        if (existingModuleItems != null)
        {
            throw new Exception("user not found");
        }
        _context.ModuleItem.Add(moduleItems);
        _context.SaveChanges();

        return moduleItems;
    }
}