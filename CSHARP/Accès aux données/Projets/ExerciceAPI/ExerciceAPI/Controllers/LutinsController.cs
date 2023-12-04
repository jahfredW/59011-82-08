using AutoMapper;
using ExerciceAPI.Models.Data.Services;
using ExerciceAPI.Models.Data.Dtos;
using ExerciceAPI.Models.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Org.BouncyCastle.Ocsp;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Adapters;
using Microsoft.AspNetCore.Mvc.ModelBinding;



namespace ExerciceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LutinsController : ControllerBase
    {
        private readonly LutinsServices _lutinServices;
        // Le mapper sert à mapper les datas entre la classe source de la classe DTO 
        private readonly IMapper _mapper;
      

        public LutinsController(LutinsServices service, IMapper mapper)
        {
            _lutinServices = service;
            _mapper = mapper;
         
        }

        //GET api/lutins
        /// <summary>
        ///     Action de récupération de tous les lutins. 
        /// </summary>
        /// <returns>Retourne une ActionResult</returns>
        [HttpGet]
        public ActionResult<IEnumerable<LutinsDTO>> getAllLutins()
        {
            // récupération de tous les lutins en BDD via le service 
            var listeLutins = _lutinServices.GetAllLutins();

            // On map directement la liste de objets récupérés en objets DTO 
            // que l'on renvoie sous forme de réponse HTTP 
            return Ok(_mapper.Map<IEnumerable<LutinsDTO>>(listeLutins));
        }

        //GET api/lutins/{id}
        /// <summary>
        /// 
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetLutinById")]
        public ActionResult<LutinsDTO> GetLutinById(int id)
        {
            var commandItem = _lutinServices.GetLutinById(id);

            if ( commandItem != null)
            {
                return Ok(_mapper.Map<LutinsDTO>(commandItem));
            }
            return NotFound();
        }

        //POST api/personnes
        [HttpPost]
        public ActionResult<LutinsDTO> CreatePersonne(Lutin lutin)
        {
            //on ajoute l’objet à la base de données
            _lutinServices.AddLutin(lutin);
            //on retourne le chemin de findById avec l'objet créé
            return CreatedAtRoute(nameof(GetLutinById), new
            {
                Id = lutin.IdLutin
            }, lutin);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateLutin(int id, LutinsDTO personne)
        {
            var lutinFromRepo = _lutinServices.GetLutinById(id);
            if (lutinFromRepo == null)
            {
                return NotFound();
            }
            
            _mapper.Map(personne, lutinFromRepo);
            
            // inutile puisque la fonction ne fait rien, mais garde la cohérence
            _lutinServices.UpdateLutin(lutinFromRepo);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialPersonneUpdate(int id, [FromBody] JsonPatchDocument<Lutin>
        patchDoc)
        {
            var lutinFromRepo = _lutinServices.GetLutinById(id);

            if (lutinFromRepo == null)
            {
                return NotFound();
            }

            var lutinToPatch = _mapper.Map<Lutin>(lutinFromRepo);

            patchDoc.ApplyTo(lutinToPatch, ModelState);
            if (!TryValidateModel(lutinToPatch))
            {
                return ValidationProblem();
            }

            _mapper.Map(lutinToPatch, lutinFromRepo);
            _lutinServices.UpdateLutin(lutinFromRepo);

            return NoContent();
        }

    }
}
