using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using nppApplication.Models.Services;
using nppApplication.Models.DTO;
using nppApplication.Models.Data;

namespace nppApplication.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReductionsController : ControllerBase
{
    private readonly ReductionsService _ReductionsService;
    private readonly IMapper _mapper;

    public ReductionsController(ReductionsService service, IMapper mapper)
    {
        _ReductionsService = service;
        _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<IEnumerable<ReductionsDTO>> GetAllReductions()
    {
        var listeReductions = _ReductionsService.GetAllReductions();
        return Ok(_mapper.Map<IEnumerable<ReductionsDTO>>(listeReductions));
    }

    [HttpGet("{id}", Name = "GetReductionById")]
    public ActionResult<ReductionsDTO> GetReductionById(int id)
    {
        var ReductionItem = _ReductionsService.GetReductionById(id);

        if (ReductionItem != null)
        {
            return Ok(_mapper.Map<ReductionsDTO>(ReductionItem));
        }

        return NotFound();
    }

    [HttpPost]
    public ActionResult<ReductionsDTO> CreateReduction(Reduction entity)
    {
        _ReductionsService.AddReduction(entity);
        return CreatedAtRoute(nameof(GetReductionById), new { Id = entity.Id }, entity);
    }

    [HttpPut("{id}")]
    public ActionResult UpdateReduction(int id, ReductionsDTO entity)
    {
        var ReductionFromRepo = _ReductionsService.GetReductionById(id);
        if (ReductionFromRepo == null)
        {
            return NotFound();
        }

        _mapper.Map(entity, ReductionFromRepo);
        _ReductionsService.UpdateReduction(ReductionFromRepo);
        return NoContent();
    }

    [HttpPatch("{id}")]
    public ActionResult PartialReductionUpdate(int id, [FromBody] JsonPatchDocument<Reduction> patchDoc)
    {
        var ReductionFromRepo = _ReductionsService.GetReductionById(id);

        if (ReductionFromRepo == null)
        {
            return NotFound();
        }

        var ReductionToPatch = _mapper.Map<Reduction>(ReductionFromRepo);

        patchDoc.ApplyTo(ReductionToPatch, ModelState);
        if (!TryValidateModel(ReductionToPatch))
        {
            return ValidationProblem();
        }

        _mapper.Map(ReductionToPatch, ReductionFromRepo);
        _ReductionsService.UpdateReduction(ReductionFromRepo);

        return NoContent();
    }
}
