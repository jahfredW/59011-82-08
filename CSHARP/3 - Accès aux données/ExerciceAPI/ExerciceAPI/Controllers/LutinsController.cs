using AutoMapper;
using ExerciceAPI.Models.Data.Services;
using ExerciceAPI.Models.Data.Dtos;
using ExerciceAPI.Models.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Org.BouncyCastle.Ocsp;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Adapters;

namespace ExerciceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LutinsController : ControllerBase
    {
        private readonly LutinsServices _lutinServices;
        private readonly IMapper _mapper;
        private readonly IObjectAdapter _adapter;

        public LutinsController(LutinsServices service, IMapper mapper, IObjectAdapter adapter)
        {
            _lutinServices = service;
            _mapper = mapper;
            _adapter = adapter;
        }

        //GET api/lutins
        [HttpGet]
        public ActionResult<IEnumerable<LutinsDTO>> getAllLutins()
        {
            var listeLutins = _lutinServices.GetAllLutins();
            return Ok(_mapper.Map<IEnumerable<LutinsDTO>>(listeLutins));
        }

        //GET api/lutins/{id}
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
        public ActionResult UpdatePersonne(int id, LutinsDTO personne)
        {
            var personneFromRepo = _lutinServices.GetLutinById(id);
            if (personneFromRepo == null)
            {
                return NotFound();
            }
            
            _mapper.Map(personne, personneFromRepo);
            
            // inutile puisque la fonction ne fait rien, mais garde la cohérence
            _lutinServices.UpdatePersonne(personneFromRepo);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialPersonneUpdate(int id, JsonPatchDocument<Lutin>
        patchDoc)
        {
            var personneFromRepo = _lutinServices.GetLutinById(id);
            if (personneFromRepo == null)
            {
                return NotFound();
            }
            var personneToPatch = _mapper.Map<Lutin>(personneFromRepo);
            patchDoc.ApplyTo(personneToPatch, _adapter);
            if (!TryValidateModel(personneToPatch))
            {
                return ValidationProblem(_adapter);
            }
            _mapper.Map(personneToPatch, personneFromRepo);
            _lutinServices.UpdatePersonne(personneFromRepo);
            return NoContent();


    }
}
