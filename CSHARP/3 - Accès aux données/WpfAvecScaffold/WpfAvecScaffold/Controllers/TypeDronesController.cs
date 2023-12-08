using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using WpfAvecScaffold.Models.Services;
using WpfAvecScaffold.Models.DTOs;
using WpfAvecScaffold.Models.Data;
using WpfAvecScaffold.Models.Profiles;
using WpfAvecScaffold.Models;

namespace WpfAvecScaffold.Controllers;


public class TypeDronesController : ControllerBase
{
    private readonly TypeDronesService _TypeDronesService;
    private readonly IMapper _mapper;

    public TypeDronesController(DronesDbContext context)
    {
        _TypeDronesService = new TypeDronesService(context);
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<TypeDronesProfile>();
        });
        _mapper = config.CreateMapper();
    }


    public IEnumerable<TypeDrone> GetAllTypeDrones()
    {
        var listeTypeDrones = _TypeDronesService.GetAllTypeDrones();
        return _mapper.Map<IEnumerable<TypeDrone>>(listeTypeDrones);
    }


    public TypeDronesDTO GetTypeDroneById(int id)
    {
        var TypeDroneItem = _TypeDronesService.GetTypeDroneById(id);

        if (TypeDroneItem != null)
        {
            return _mapper.Map<TypeDronesDTO>(TypeDroneItem);
        }

        return null;
    }

 
    public void  CreateTypeDrone(TypeDrone entity)
    {
        _TypeDronesService.AddTypeDrone(entity);
        
    }

  
    public void UpdateTypeDrone(int id, TypeDronesDTOIn entity)
    {
        var TypeDroneFromRepo = _TypeDronesService.GetTypeDroneById(id);
        if (TypeDroneFromRepo != null)
        {
            _mapper.Map(entity, TypeDroneFromRepo);
            _TypeDronesService.UpdateTypeDrone(TypeDroneFromRepo);
        } 
     
    }

    public int GetTypeDroneByName(string name)
    {
        return _TypeDronesService.GetTypeDroneByName(name);
    }


}
