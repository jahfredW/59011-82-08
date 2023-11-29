
using drone_api.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace drone_api.Models.Services;

public class DronesService
{
    private readonly nppContext _context;

    public DronesService(nppContext context)
    {
        _context = context;
    }

    public void AddDrone(Drone entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        _context.Drones.Add(entity);
        _context.SaveChanges();
    }

    public IEnumerable<Drone> GetAllDrones()
    {
        return _context.Drones.Include("Sessions.Pilote").ToList();
    }

    public Drone GetDroneById(int id)
    {
        Drone entity = _context.Drones.FirstOrDefault(entity => entity.IdDrone == id);

        return entity;
    }

    // récupérer un drone par son type
    public Drone GetDroneByIntitule(string name)
    {
        Drone entity = _context.Drones.FirstOrDefault(entity => entity.Nom == name);

        return entity;
    }
    public void DeleteDrone(Drone entity)
    {

        _context.Drones.Remove(entity);
        _context.SaveChanges();
    }

    public void UpdateDrone(Drone entity)
    {
        _context.Drones.Update(entity);
        _context.SaveChanges();
    }

}

