using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using drone_last.Models.Services;
using drone_last.Models.DTOs;
using drone_last.Models.Data;

namespace drone_last.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PilotesController : ControllerBase
{
    private readonly PilotesService _PilotesService;
    private readonly IMapper _mapper;

    public PilotesController(PilotesService service, IMapper mapper)
    {
        _PilotesService = service;
        _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<IEnumerable<PilotesDTO>> GetAllPilotes()
    {
        var listePilotes = _PilotesService.GetAllPilotes();
        return Ok(_mapper.Map<IEnumerable<PilotesDTO>>(listePilotes));
    }

    [HttpGet("{id}", Name = "GetPiloteById")]
    public ActionResult<PilotesDTO> GetPiloteById(int id)
    {
        var PiloteItem = _PilotesService.GetPiloteById(id);

        if (PiloteItem != null)
        {
            return Ok(_mapper.Map<PilotesDTO>(PiloteItem));
        }

        return NotFound();
    }

    [HttpPost]
    public ActionResult<PilotesDTOout> CreatePilote(PilotesDTOin entity)
    {
        var piloteFromRepo = _mapper.Map<Pilote>(entity);

        _PilotesService.AddPilote(piloteFromRepo);

        return CreatedAtRoute(nameof(GetPiloteById), new { Id = entity.IdPilote }, entity);
    }

    [HttpPut("{id}")]
    public ActionResult UpdatePilote(int id, PilotesDTO entity)
    {
        var PiloteFromRepo = _PilotesService.GetPiloteById(id);
        if (PiloteFromRepo == null)
        {
            return NotFound();
        }

        _mapper.Map(entity, PiloteFromRepo);
        _PilotesService.UpdatePilote(PiloteFromRepo);
        return NoContent();
    }

    [HttpPatch("{id}")]
    public ActionResult PartialPiloteUpdate(int id, [FromBody] JsonPatchDocument<Pilote> patchDoc)
    {
        var PiloteFromRepo = _PilotesService.GetPiloteById(id);

        if (PiloteFromRepo == null)
        {
            return NotFound();
        }

        var PiloteToPatch = _mapper.Map<Pilote>(PiloteFromRepo);

        patchDoc.ApplyTo(PiloteToPatch, ModelState);
        if (!TryValidateModel(PiloteToPatch))
        {
            return ValidationProblem();
        }

        _mapper.Map(PiloteToPatch, PiloteFromRepo);
        _PilotesService.UpdatePilote(PiloteFromRepo);

        return NoContent();
    }
}

