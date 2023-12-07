using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using WpfAvecScaffold.Models.Services;
using WpfAvecScaffold.Models.Data;
using WpfAvecScaffold.Models.DTOs;
using WpfAvecScaffold.Models.Profiles;
using WpfAvecScaffold.Models;


namespace WpfAvecScaffold.Controllers;


public class DronesController : ControllerBase
{
    private readonly DronesService _DronesService;
    private readonly IMapper _mapper;

    public DronesController(DronesDbContext context)
    {
        _DronesService = new DronesService(context);
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<DronesProfile>();
        });
        _mapper = config.CreateMapper();
    }


    public IEnumerable<DronesDTOOut> GetAllDrones()
    {
        var listeDrones = _DronesService.GetAllDrones();
        return _mapper.Map<IEnumerable<DronesDTOOut>>(listeDrones);
    }

 
    public DronesDTO GetDroneById(int id)
    {
        var DroneItem = _DronesService.GetDroneById(id);

        if (DroneItem != null)
        {
            return _mapper.Map<DronesDTO>(DroneItem);
        }

        return null;
    }


    public void CreateDrone(Drone entity)
    {
        _DronesService.AddDrone(entity);
      
    }


    public void UpdateDrone(int id, DronesDTO entity)
    {
        var DroneFromRepo = _DronesService.GetDroneById(id);
        if (DroneFromRepo != null)
        {
            _mapper.Map(entity, DroneFromRepo);
            _DronesService.UpdateDrone(DroneFromRepo);
        }
    }



}

