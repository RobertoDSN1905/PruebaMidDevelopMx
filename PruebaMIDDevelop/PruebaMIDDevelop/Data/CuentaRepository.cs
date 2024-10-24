using Microsoft.EntityFrameworkCore;
using PruebaMIDDevelop.entities;

namespace PruebaMIDDevelop.Data
{
    public class CuentaRepository : IRepository<Cuenta>
    {

        private readonly AppDbContext contexto;

        public CuentaRepository(AppDbContext context)
        {
            contexto = context;
        }

        public async Task<IEnumerable<Cuenta>> GetAll()
        {
            return await contexto.Cuentas.Include(x => x.Cliente).ToListAsync();
        }

        public async Task<Cuenta> GetById(int id)
        {
            return await contexto.Cuentas.Include(x => x.Cliente).FirstAsync(x => x.Id == id);
        }

        public async Task Add(Cuenta entidad)
        {
            await contexto.Cuentas.AddAsync(entidad);
            await contexto.SaveChangesAsync();
        }

        public async Task Update(Cuenta entidad)
        {
            contexto.Cuentas.Update(entidad);
            await contexto.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var cuenta = await GetById(id);
            contexto.Cuentas.Remove(cuenta);
            await contexto.SaveChangesAsync();
        }

    }
}
