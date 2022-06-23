using Especialidad.Data;
using TaskItem;

public class TaskRepository
{
    private readonly DataContext _context;
    public TaskRepository(DataContext context)
    {
        this._context = context;
    }

    public List<TaskItems> Get()
    {
        return this._context.TaskItem.ToList();
    }
    public TaskItems Post(TaskItems taskItems)
    {
        TaskItems existingTaskItems = _context.TaskItem.Find(taskItems.IdTask);
        if (existingTaskItems != null)
        {
            throw new Exception("user not found");
        }
        _context.TaskItem.Add(taskItems);
        _context.SaveChanges();

        return taskItems;
    }
}