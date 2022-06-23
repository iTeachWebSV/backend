using Especialidad.Data;
using UsersItem;

public class UserRepository
{
    private readonly DataContext _context;
    public UserRepository(DataContext context)
    {
        this._context = context;
    }

    public List<UserItems> Get()
    {
        return this._context.UserItem.ToList();
    }
    public UserItems Post(UserItems userItems)
    {

        UserItems existingUserItems = _context.UserItem.Find(userItems.DniUser);
        if (existingUserItems != null)
        {
            throw new Exception("user not found");
        }
        _context.UserItem.Add(userItems);
        _context.SaveChanges();

        return userItems;
    }
}