using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using nppApplication.Models.Services;
using nppApplication.Models.DTO;
using nppApplication.Models.Data;

namespace nppApplication.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AlbumsController : ControllerBase
{
    private readonly AlbumsService _AlbumsService;
    private readonly IMapper _mapper;

    public AlbumsController(AlbumsService service, IMapper mapper)
    {
        _AlbumsService = service;
        _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<IEnumerable<AlbumsDTO>> GetAllAlbums()
    {
        var listeAlbums = _AlbumsService.GetAllAlbums();
        return Ok(_mapper.Map<IEnumerable<AlbumsDTO>>(listeAlbums));
    }

    [HttpGet("{id}", Name = "GetAlbumById")]
    public ActionResult<AlbumsDTO> GetAlbumById(int id)
    {
        var AlbumItem = _AlbumsService.GetAlbumById(id);

        if (AlbumItem != null)
        {
            return Ok(_mapper.Map<AlbumsDTO>(AlbumItem));
        }

        return NotFound();
    }

    [HttpPost]
    // Ici je passe un DTO Perso pour les request Body 
    public ActionResult<AlbumsDTO> CreateAlbum([FromBody] AlbumsDTOPost entity)
    {
        // ne pas oublier de convertir le AlbumsDTOPost en entité Album
        var album = _mapper.Map<Album>(entity);

        // utilisation du service
        _AlbumsService.AddAlbum(album);

        return CreatedAtRoute(nameof(GetAlbumById), new { Id = album.Id }, album);
    }

    [HttpPut("{id}")]
    public ActionResult UpdateAlbum(int id, AlbumsDTOPost   entity)
    {
        var AlbumFromRepo = _AlbumsService.GetAlbumById(id);
        if (AlbumFromRepo == null)
        {
            return NotFound();
        }

        _mapper.Map(entity, AlbumFromRepo);
        _AlbumsService.UpdateAlbum(AlbumFromRepo);
        return NoContent();
    }

    [HttpPatch("{id}")]
    public ActionResult PartialAlbumUpdate(int id, [FromBody] JsonPatchDocument<Album> patchDoc)
    {
        var AlbumFromRepo = _AlbumsService.GetAlbumById(id);

        if (AlbumFromRepo == null)
        {
            return NotFound();
        }

        var AlbumToPatch = _mapper.Map<Album>(AlbumFromRepo);

        patchDoc.ApplyTo(AlbumToPatch, ModelState);
        if (!TryValidateModel(AlbumToPatch))
        {
            return ValidationProblem();
        }

        _mapper.Map(AlbumToPatch, AlbumFromRepo);
        _AlbumsService.UpdateAlbum(AlbumFromRepo);

        return NoContent();
    }
}
