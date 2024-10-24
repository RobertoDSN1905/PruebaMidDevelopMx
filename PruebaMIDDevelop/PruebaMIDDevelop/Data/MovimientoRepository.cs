using Microsoft.EntityFrameworkCore;
using PruebaMIDDevelop.entities;

namespace PruebaMIDDevelop.Data
{
    public class MovimientoRepository : IRepository<Movimiento>
    {

        private readonly AppDbContext contexto;

        public MovimientoRepository(AppDbContext context)
        {
            contexto = context;
        }

        public async Task<IEnumerable<Movimiento>> GetAll()
        {
            return await contexto.Movimientos.Include(x => x.Cuenta).ToListAsync();
        }

        public async Task<Movimiento> GetById(int id)
        {
            return await contexto.Movimientos.Include(x => x.Cuenta).FirstAsync(x => x.Id == id);
        }

        public async Task Add(Movimiento entidad)
        {
            await contexto.Movimientos.AddAsync(entidad);
            await contexto.SaveChangesAsync();
        }

        public async Task Update(Movimiento entidad)
        {
            contexto.Movimientos.Update(entidad);
            await contexto.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var movimiento = await GetById(id);
            contexto.Movimientos.Remove(movimiento);
            await contexto.SaveChangesAsync();
        }

    }
}
