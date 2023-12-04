
using drone_appli.Models.Data;

namespace drone_appli.Models.Services;

public class DronesService
{
    private readonly appContext _context;

    public DronesService(appContext context)
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
        return _context.Drones.ToList();
    }

    public Drone GetDroneById(int id)
    {
        Drone entity = _context.Drones.FirstOrDefault(entity => entity.IdDrone == id);

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


