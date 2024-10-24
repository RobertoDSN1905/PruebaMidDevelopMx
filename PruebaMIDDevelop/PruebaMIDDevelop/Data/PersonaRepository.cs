using Microsoft.EntityFrameworkCore;
using PruebaMIDDevelop.entities;

namespace PruebaMIDDevelop.Data
{
    public class PersonaRepository : IRepository<Persona>
    {
        private readonly AppDbContext contexto;

        public PersonaRepository(AppDbContext context)
        {
            contexto = context;
        }

        public async Task<IEnumerable<Persona>> GetAll()
        {
            return await contexto.Personas.ToListAsync();
        }

        public async Task<Persona> GetById(int id)
        {
            return await contexto.Personas.FirstAsync(x => x.Id == id);
        }

        public async Task Add(Persona entidad)
        {
            await contexto.Personas.AddAsync(entidad);
            await contexto.SaveChangesAsync();
        }

        public async Task Update(Persona entidad)
        {
            contexto.Personas.Update(entidad);
            await contexto.SaveChangesAsync();
        }

        public async Task Delete (int id)
        {
            var persona = await GetById(id);
            contexto.Personas.Remove(persona);
            await contexto.SaveChangesAsync();
        }


    }
}
