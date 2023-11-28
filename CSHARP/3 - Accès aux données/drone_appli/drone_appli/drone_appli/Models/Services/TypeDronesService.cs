﻿
using drone_appli.Models.Data;

namespace drone_appli.Models.Services;

public class TypeDronesService
{
    private readonly appContext _context;

    public TypeDronesService(appContext context)
    {
        _context = context;
    }

    public void AddTypeDrone(TypeDrone entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        _context.TypeDrones.Add(entity);
        _context.SaveChanges();
    }

    public IEnumerable<TypeDrone> GetAllTypeDrones()
    {
        return _context.TypeDrones.ToList();
    }

    public TypeDrone GetTypeDroneById(int id)
    {
        TypeDrone entity = _context.TypeDrones.FirstOrDefault(entity => entity.IdTypeDrone == id);

        return entity;
    }
    public void DeleteTypeDrone(TypeDrone entity)
    {

        _context.TypeDrones.Remove(entity);
        _context.SaveChanges();
    }

    public void UpdateTypeDrone(TypeDrone entity)
    {
        _context.TypeDrones.Update(entity);
        _context.SaveChanges();
    }

}


