
using drone_last.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace drone_last.Models.Services;

public class PilotesService
{
    private readonly nppContext _context;

    public PilotesService(nppContext context)
    {
        _context = context;
    }

    public void AddPilote(Pilote entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        _context.Pilotes.Add(entity);
        _context.SaveChanges();
    }

    public IEnumerable<Pilote> GetAllPilotes()
    {
        return _context.Pilotes.ToList();
    }

    public Pilote GetPiloteById(int id)
    {
        Pilote entity = _context.Pilotes.Include("Sessions.DroneRelation").FirstOrDefault(entity => entity.IdPilote == id);


        return entity;
    }
    public void DeletePilote(Pilote entity)
    {

        _context.Pilotes.Remove(entity);
        _context.SaveChanges();
    }

    public void UpdatePilote(Pilote entity)
    {
        _context.Pilotes.Update(entity);
        _context.SaveChanges();
    }

}


