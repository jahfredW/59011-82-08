using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using nppApplication.Models.Services;
using nppApplication.Models.DTO;

namespace nppApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        private readonly AlbumsService _albumService
            ;
        // Le mapper sert à mapper les datas entre la classe source de la classe DTO 
        private readonly IMapper _mapper;


        public AlbumsController(AlbumsService service, IMapper mapper)
        {
            _albumService = service;
            _mapper = mapper;

        }

        //GET api/lutins
        /// <summary>
        ///     Action de récupération de tous les lutins. 
        /// </summary>
        /// <returns>Retourne une ActionResult</returns>
        [HttpGet]
        public ActionResult<IEnumerable<AlbumsDTO>> getAllAlbums()
        {
            // récupération de tous les lutins en BDD via le service 
            var listeLutins = _albumService.GetAllAlbums();

            // On map directement la liste de objets récupérés en objets DTO 
            // que l'on renvoie sous forme de réponse HTTP 
            return Ok(_mapper.Map<IEnumerable<AlbumsDTO>>(listeLutins));
        }
    }
    }
