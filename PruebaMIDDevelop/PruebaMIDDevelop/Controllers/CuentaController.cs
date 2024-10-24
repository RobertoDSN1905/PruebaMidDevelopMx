using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaMIDDevelop.Data;
using PruebaMIDDevelop.entities;

namespace PruebaMIDDevelop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuentaController : Controller
    {

        private readonly IRepository<Cuenta> _cuentaRepository;

        public CuentaController(IRepository<Cuenta> cuentaRepository)
        {
            _cuentaRepository = cuentaRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cuenta>>> GetCuentas()
        {
            var cuentas = await _cuentaRepository.GetAll();
            return Ok(cuentas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cuenta>> getCuenta(int id)
        {
            var cuenta = await _cuentaRepository.GetById(id);
            if (cuenta == null)
            {
                return BadRequest("no se encontro un usuario con esa id");
            }
            return Ok(cuenta);
        }

        [HttpPost]
        public async Task<ActionResult> createMovimiento(Cuenta cuenta)
        {
            await _cuentaRepository.Add(cuenta);
            return CreatedAtAction(nameof(getCuenta), new { id = cuenta.Id }, cuenta);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> updateCuenta(int id, Cuenta cuenta)
        {
            if (id != cuenta.Id)
            {
                return BadRequest("Id invalido");
            }
            await _cuentaRepository.Update(cuenta);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCuenta(int id)
        {
            await _cuentaRepository.Delete(id);
            return NoContent();
        }

    }
}
