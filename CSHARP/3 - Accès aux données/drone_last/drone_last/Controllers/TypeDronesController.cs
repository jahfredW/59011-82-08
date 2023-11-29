using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using drone_last.Models.Services;
using drone_last.Models.DTOs;
using drone_last.Models.Data;

namespace drone_last.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TypeDronesController : ControllerBase
{
    private readonly TypeDronesService _TypeDronesService;
    private readonly IMapper _mapper;

    public TypeDronesController(TypeDronesService service, IMapper mapper)
    {
        _TypeDronesService = service;
        _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<IEnumerable<TypeDronesDTO>> GetAllTypeDrones()
    {
        var listeTypeDrones = _TypeDronesService.GetAllTypeDrones();
        return Ok(_mapper.Map<IEnumerable<TypeDronesDTO>>(listeTypeDrones));
    }

    [HttpGet("{id}", Name = "GetTypeDroneById")]
    public ActionResult<TypeDronesDTO> GetTypeDroneById(int id)
    {
        var TypeDroneItem = _TypeDronesService.GetTypeDroneById(id);

        if (TypeDroneItem != null)
        {
            return Ok(_mapper.Map<TypeDronesDTO>(TypeDroneItem));
        }

        return NotFound();
    }

    [HttpPost]
    public ActionResult<TypeDronesDTO> CreateTypeDrone(TypeDrone entity)
    {
        _TypeDronesService.AddTypeDrone(entity);
        return CreatedAtRoute(nameof(GetTypeDroneById), new { Id = entity.IdTypeDrone }, entity);
    }

    [HttpPut("{id}")]
    public ActionResult UpdateTypeDrone(int id, TypeDronesDTO entity)
    {
        var TypeDroneFromRepo = _TypeDronesService.GetTypeDroneById(id);
        if (TypeDroneFromRepo == null)
        {
            return NotFound();
        }

        _mapper.Map(entity, TypeDroneFromRepo);
        _TypeDronesService.UpdateTypeDrone(TypeDroneFromRepo);
        return NoContent();
    }

    [HttpPatch("{id}")]
    public ActionResult PartialTypeDroneUpdate(int id, [FromBody] JsonPatchDocument<TypeDrone> patchDoc)
    {
        var TypeDroneFromRepo = _TypeDronesService.GetTypeDroneById(id);

        if (TypeDroneFromRepo == null)
        {
            return NotFound();
        }

        var TypeDroneToPatch = _mapper.Map<TypeDrone>(TypeDroneFromRepo);

        patchDoc.ApplyTo(TypeDroneToPatch, ModelState);
        if (!TryValidateModel(TypeDroneToPatch))
        {
            return ValidationProblem();
        }

        _mapper.Map(TypeDroneToPatch, TypeDroneFromRepo);
        _TypeDronesService.UpdateTypeDrone(TypeDroneFromRepo);

        return NoContent();
    }
}

