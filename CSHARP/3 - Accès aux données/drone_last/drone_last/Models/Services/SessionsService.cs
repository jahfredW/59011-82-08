
using drone_last.Models.Data;

namespace drone_last.Models.Services;

public class SessionsService
{
    private readonly nppContext _context;

    public SessionsService(nppContext context)
    {
        _context = context;
    }

    public void AddSession(Session entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        _context.Sessions.Add(entity);
        _context.SaveChanges();
    }

    public IEnumerable<Session> GetAllSessions()
    {
        return _context.Sessions.ToList();
    }

    public Session GetSessionById(int id)
    {
        Session entity = _context.Sessions.FirstOrDefault(entity => entity.IdSession == id);

        return entity;
    }
    public void DeleteSession(Session entity)
    {

        _context.Sessions.Remove(entity);
        _context.SaveChanges();
    }

    public void UpdateSession(Session entity)
    {
        _context.Sessions.Update(entity);
        _context.SaveChanges();
    }

}


