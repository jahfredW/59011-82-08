using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using drone_last.Models.Services;
using drone_last.Models.DTOs;
using drone_last.Models.Data;

namespace drone_last.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SessionsController : ControllerBase
{
    private readonly SessionsService _SessionsService;
    private readonly IMapper _mapper;

    public SessionsController(SessionsService service, IMapper mapper)
    {
        _SessionsService = service;
        _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<IEnumerable<SessionsDTO>> GetAllSessions()
    {
        var listeSessions = _SessionsService.GetAllSessions();
        return Ok(_mapper.Map<IEnumerable<SessionsDTO>>(listeSessions));
    }

    [HttpGet("{id}", Name = "GetSessionById")]
    public ActionResult<SessionsDTO> GetSessionById(int id)
    {
        var SessionItem = _SessionsService.GetSessionById(id);

        if (SessionItem != null)
        {
            return Ok(_mapper.Map<SessionsDTO>(SessionItem));
        }

        return NotFound();
    }

    [HttpPost]
    public ActionResult<SessionsDTO> CreateSession(Session entity)
    {
        _SessionsService.AddSession(entity);
        return CreatedAtRoute(nameof(GetSessionById), new { Id = entity.IdSession }, entity);
    }

    [HttpPut("{id}")]
    public ActionResult UpdateSession(int id, SessionsDTO entity)
    {
        var SessionFromRepo = _SessionsService.GetSessionById(id);
        if (SessionFromRepo == null)
        {
            return NotFound();
        }

        _mapper.Map(entity, SessionFromRepo);
        _SessionsService.UpdateSession(SessionFromRepo);
        return NoContent();
    }

    [HttpPatch("{id}")]
    public ActionResult PartialSessionUpdate(int id, [FromBody] JsonPatchDocument<Session> patchDoc)
    {
        var SessionFromRepo = _SessionsService.GetSessionById(id);

        if (SessionFromRepo == null)
        {
            return NotFound();
        }

        var SessionToPatch = _mapper.Map<Session>(SessionFromRepo);

        patchDoc.ApplyTo(SessionToPatch, ModelState);
        if (!TryValidateModel(SessionToPatch))
        {
            return ValidationProblem();
        }

        _mapper.Map(SessionToPatch, SessionFromRepo);
        _SessionsService.UpdateSession(SessionFromRepo);

        return NoContent();
    }
}

