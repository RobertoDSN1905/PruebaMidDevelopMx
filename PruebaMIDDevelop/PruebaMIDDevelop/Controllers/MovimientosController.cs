using Microsoft.AspNetCore.Mvc;
using PruebaMIDDevelop.Data;
using PruebaMIDDevelop.entities;

namespace PruebaMIDDevelop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimientosController : Controller
    {

        private readonly IRepository<Movimiento> _movimientoRepository;
        private readonly IRepository<Persona> _personaRepository;
        private readonly IRepository<Cuenta> _CuentaRepository;

        public MovimientosController(IRepository<Movimiento> movimientoRepository,IRepository<Persona> personaRepository, IRepository<Cuenta> cuentaRepository)
        {
            _movimientoRepository = movimientoRepository;
            _personaRepository = personaRepository;
            _CuentaRepository = cuentaRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movimiento>>> GetMovimientos()
        {
            try
            {
                var movimientos = await _movimientoRepository.GetAll();
                return Ok(movimientos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Movimiento>> getMovimiento(int id)
        {
            var movimiento = await _movimientoRepository.GetById(id);
            if (movimiento == null)
            {
                return BadRequest("no se encontro el movimiento con esa id");
            }
            return Ok(movimiento);
        }

        [HttpPost]
        public async Task<ActionResult> createMovimiento(Movimiento movimiento)
        {

            if (movimiento.Valor < 0 && movimiento.Cuenta.SaldoInicial == 0)
            {
                return BadRequest("saldo no disponible");
            }
            else
            {
                var saldoDisp = movimiento.Cuenta.SaldoInicial + movimiento.Valor;

                movimiento.SaldoDisponible = saldoDisp;

                movimiento.Cuenta.SaldoInicial = saldoDisp;

                await _movimientoRepository.Add(movimiento);
                await _CuentaRepository.Update(movimiento.Cuenta);
                return CreatedAtAction(nameof(getMovimiento), new { id = movimiento.Id }, movimiento);
            }

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> updateMovimiento(int id, Movimiento movimiento)
        {
            if (id != movimiento.Id)
            {
                return BadRequest("Id invalido");
            }
            await _movimientoRepository.Update(movimiento);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMovimiento(int id)
        {
                await _movimientoRepository.Delete(id);
                return NoContent();
        }

        [HttpGet("reportes/{id}/{fecha}")]
        public async Task<ActionResult<Movimiento>> getReporte(int id,string fecha)
        {
            try
            {
                DateTime fechaParseada;
                if (!DateTime.TryParseExact(fecha, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out fechaParseada))
                {
                    return BadRequest("Formato de fecha inválido. Utiliza yyyy-mm-dd.");
                }

                var movimientos = await _movimientoRepository.GetById(id);

                if (movimientos == null)
                {
                    return NotFound();
                }

                var persona = await _personaRepository.GetById(movimientos.Cuenta.ClienteID);


                var reporteRes = new
                {
                    Fecha = fechaParseada,
                    Cliente = persona.Nombre,
                    Numero_Cuenta = movimientos.Cuenta.NumeroCuenta,
                    Tipo_ = movimientos.Tipo,
                    Saldo_Inicial = movimientos.Cuenta.SaldoInicial,
                    estado = movimientos.Cuenta.Estado,
                    movimiento = movimientos.Valor,
                    Saldo_Disponible = movimientos.SaldoDisponible
                };

                return Json(reporteRes);
            }
            catch (Exception ex)
            {
                return BadRequest(" la descripcion del error es:  " + ex.Message);
            }
        }
    }
}
