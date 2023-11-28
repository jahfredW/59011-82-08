using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using drone_appli.Models.Services;
using drone_appli.Models.DTO;
using drone_appli.Models.Data;

namespace drone_appli.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DronesController : ControllerBase
{
    private readonly DronesService _DronesService;
    private readonly IMapper _mapper;

    public DronesController(DronesService service, IMapper mapper)
    {
        _DronesService = service;
        _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<IEnumerable<DronesDTO>> GetAllDrones()
    {
        var listeDrones = _DronesService.GetAllDrones();
        return Ok(_mapper.Map<IEnumerable<DronesDTO>>(listeDrones));
    }

    [HttpGet("{id}", Name = "GetDroneById")]
    public ActionResult<DronesDTO> GetDroneById(int id)
    {
        var DroneItem = _DronesService.GetDroneById(id);

        if (DroneItem != null)
        {
            return Ok(_mapper.Map<DronesDTO>(DroneItem));
        }

        return NotFound();
    }

    [HttpPost]
    public ActionResult<DronesDTO> CreateDrone(Drone entity)
    {
        _DronesService.AddDrone(entity);
        return CreatedAtRoute(nameof(GetDroneById), new { Id = entity.IdDrone }, entity);
    }

    [HttpPut("{id}")]
    public ActionResult UpdateDrone(int id, DronesDTO entity)
    {
        var DroneFromRepo = _DronesService.GetDroneById(id);
        if (DroneFromRepo == null)
        {
            return NotFound();
        }

        _mapper.Map(entity, DroneFromRepo);
        _DronesService.UpdateDrone(DroneFromRepo);
        return NoContent();
    }

    [HttpPatch("{id}")]
    public ActionResult PartialDroneUpdate(int id, [FromBody] JsonPatchDocument<Drone> patchDoc)
    {
        var DroneFromRepo = _DronesService.GetDroneById(id);

        if (DroneFromRepo == null)
        {
            return NotFound();
        }

        var DroneToPatch = _mapper.Map<Drone>(DroneFromRepo);

        patchDoc.ApplyTo(DroneToPatch, ModelState);
        if (!TryValidateModel(DroneToPatch))
        {
            return ValidationProblem();
        }

        _mapper.Map(DroneToPatch, DroneFromRepo);
        _DronesService.UpdateDrone(DroneFromRepo);

        return NoContent();
    }
}

