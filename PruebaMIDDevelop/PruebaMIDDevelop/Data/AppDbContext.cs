using Microsoft.EntityFrameworkCore;
using PruebaMIDDevelop.entities;

namespace PruebaMIDDevelop.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        //DbSet de entidades
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Cuenta> Cuentas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Movimiento> Movimientos { get; set; }

    }
}
