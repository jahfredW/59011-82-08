using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using drone_api.Models.Services;
using drone_api.Models.DTO;
using drone_api.Models.Data;
using System.Collections.Generic;
using System.Net.Http.Headers;

namespace drone_api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DronesController : ControllerBase
{
    private readonly DronesService _DronesService;
    private readonly TypeDronesService _TypeDronesService;
    private readonly IMapper _mapper;

    public DronesController(DronesService service, IMapper mapper)
    {
        _DronesService = service;
        _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<IEnumerable<DronesDTOWithSessions>> GetAllDrones()
    {
        var drone = _DronesService.GetAllDrones();
        return Ok(_mapper.Map<IEnumerable<DronesDTOWithSessions>>(drone));
    }
    [HttpGet("Testdrones", Name = "TestDrone"  )]
    public ActionResult<IEnumerable<DronesDTO>> GetAllDronesFull()
    {
        var drone = _DronesService.GetAllDrones();
        return Ok(_mapper.Map<IEnumerable<DronesDTO>>(drone));
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
    public ActionResult<DronesDTOIn> CreateDrone(DronesDTOIn entity)
    {
        // récupération du type de drone
        var typeDrone = _TypeDronesService.GetTypeDroneByIntitule(entity.IntituleTypeDrone);

        var drone = _mapper.Map<Drone>(entity);

        drone.IdTypeDrone = typeDrone.IdTypeDrone;

        _DronesService.AddDrone(drone);

        return CreatedAtRoute(nameof(GetDroneById), new { Id = drone.IdDrone }, entity);
    }

    [HttpPut("{id}")]
    public ActionResult UpdateDrone(int id, DronesDTOWithSessions entity)
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

