using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Completion;
using nppApplication.Models.Data;
using nppApplication.Models.Services;
using nppApplication.Models.DTO;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Adapters;



namespace nppApplication.Controllers
{



    [Route("api/[controller]")]
    [ApiController]
    public class PicturesController : ControllerBase
    {
        private readonly PicturesService _PicturesService;
        private readonly IMapper _mapper;

        public PicturesController(PicturesService service, IMapper mapper)
        {
            _PicturesService = service;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PicturesDTO>> GetAllPictures()
        {
            var listePictures = _PicturesService.GetAllPictures();
            return Ok(_mapper.Map<IEnumerable<PicturesDTO>>(listePictures));
        }

        [HttpGet("{id}", Name = "GetPictureById")]
        public ActionResult<PicturesDTOWithAlbumDetails> GetPictureById(int id)
        {
            var PictureItem = _PicturesService.GetPictureById(id);

            if (PictureItem != null)
            {
                return Ok(_mapper.Map<PicturesDTOWithAlbumDetails>(PictureItem));
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult<PicturesDTO> CreatePicture(Picture entity)
        {
            _PicturesService.AddPicture(entity);
            return CreatedAtRoute(nameof(GetPictureById), new { Id = entity.Id }, entity);
        }

        [HttpPut("{id}")]
        public ActionResult UpdatePicture(int id, PicturesDTO entity)
        {
            var PictureFromRepo = _PicturesService.GetPictureById(id);
            if (PictureFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(entity, PictureFromRepo);
            _PicturesService.UpdatePicture(PictureFromRepo);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialPictureUpdate(int id, [FromBody] JsonPatchDocument<Picture> patchDoc)
        {
            var PictureFromRepo = _PicturesService.GetPictureById(id);

            if (PictureFromRepo == null)
            {
                return NotFound();
            }

            var PictureToPatch = _mapper.Map<Picture>(PictureFromRepo);

            patchDoc.ApplyTo(PictureToPatch, ModelState);
            if (!TryValidateModel(PictureToPatch))
            {
                return ValidationProblem();
            }

            _mapper.Map(PictureToPatch, PictureFromRepo);
            _PicturesService.UpdatePicture(PictureFromRepo);

            return NoContent();
        }
    }


}
