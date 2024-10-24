using Microsoft.EntityFrameworkCore;
using PruebaMIDDevelop.entities;

namespace PruebaMIDDevelop.Data
{
    public class ClienteRepository : IRepository<Cliente>
    {

        private readonly AppDbContext contexto;

        public ClienteRepository(AppDbContext context)
        {
            contexto = context;
        }

        public async Task<IEnumerable<Cliente>> GetAll()
        {
            return await contexto.Clientes.Include(x => x.Persona).ToListAsync();
        }

        public async Task<Cliente> GetById(int id)
        {
            return await contexto.Clientes.Include(x => x.Persona).FirstAsync(x => x.Id == id);
        }

        public async Task Add(Cliente entidad)
        {
            await contexto.Clientes.AddAsync(entidad);
            await contexto.SaveChangesAsync();
        }

        public async Task Update(Cliente entidad)
        {
            contexto.Clientes.Update(entidad);
            await contexto.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var cliente = await GetById(id);
            contexto.Clientes.Remove(cliente);
            await contexto.SaveChangesAsync();
        }


    }
}
