using Microsoft.AspNetCore.Mvc;
using PruebaMIDDevelop.Data;
using PruebaMIDDevelop.entities;

namespace PruebaMIDDevelop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : Controller
    {

        private readonly IRepository<Persona> _personaRepository;

        public PersonaController(IRepository<Persona> personaRepository)
        {
            _personaRepository = personaRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Persona>>> GetPersonas()
        {
            var personas = await _personaRepository.GetAll();
            return Ok(personas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Persona>> getPersona(int id)
        {
            var persona = await _personaRepository.GetById(id);
            if (persona == null)
            {
                return NotFound();
            }
            return Ok(persona);
        }

        [HttpPost]
        public async Task<ActionResult> createPersona(Persona persona)
        {
            await _personaRepository.Add(persona);
            return CreatedAtAction(nameof(getPersona), new { id = persona.Id }, persona);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> updatePersona(int id, Persona persona)
        {
            if (id != persona.Id)
            {
                return BadRequest("Id invalido");
            }
            await _personaRepository.Update(persona);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProducto(int id)
        {
            await _personaRepository.Delete(id);
            return NoContent();
        }

    }
}
