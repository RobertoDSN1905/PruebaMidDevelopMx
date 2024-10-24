using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaMIDDevelop.Data;
using PruebaMIDDevelop.entities;
using System.Net;

namespace PruebaMIDDevelop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : Controller
    {

        private readonly IRepository<Cliente> _clienteRepository;

        public ClienteController(IRepository<Cliente> clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            try
            {
                var clientes = await _clienteRepository.GetAll();
                return Ok(clientes);
            }
            catch (Exception ex)
            {
                return Content("favor de revisar el error = " + ex.ToString());
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> getCliente(int id)
        {
            var cliente = await _clienteRepository.GetById(id);
            if (cliente == null)
            {
                return BadRequest("no existe el cliente con esta id.");
            }
            return Ok(cliente);
        }

        [HttpPost]
        public async Task<ActionResult> createMovimiento(Cliente cliente)
        {
            await _clienteRepository.Add(cliente);
            return CreatedAtAction(nameof(getCliente), new { id = cliente.Id }, cliente);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> updateCliente(int id, Cliente cliente)
        {
            if (id != cliente.Id)
            {
                return BadRequest("Id invalido");
            }
            await _clienteRepository.Update(cliente);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCliente(int id)
        {
            try
            {
                await _clienteRepository.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return Content("favor de revisar el error = " + ex.ToString());
            }
        }
    }
}
