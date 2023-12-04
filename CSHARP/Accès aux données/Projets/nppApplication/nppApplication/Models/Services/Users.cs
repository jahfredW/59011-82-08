
using nppApplication.Models.Data;

namespace nppApplication.Models.Services;

public class UsersService
{
    private readonly NppContext _context;

    public UsersService(NppContext context)
    {
        _context = context;
    }

    public void AddUser(User entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        _context.Users.Add(entity);
        _context.SaveChanges();
    }

    public IEnumerable<User> GetAllUsers()
    {
        return _context.Users.ToList();
    }

    public User GetUserById(int id)
    {
        User entity = _context.Users.FirstOrDefault(entity => entity.Id == id);

        return entity;
    }
    public void DeleteUser(User entity)
    {

        _context.Users.Remove(entity);
        _context.SaveChanges();
    }

    public void UpdateUser(User entity)
    {
        _context.Users.Update(entity);
        _context.SaveChanges();
    }

}


