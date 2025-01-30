using Microsoft.EntityFrameworkCore;
using EstadoCuentaAPI.Models;

namespace EstadoCuentaAPI.Data
{
    public class EstadoCuentaDbContext : DbContext
    {
        public EstadoCuentaDbContext(DbContextOptions<EstadoCuentaDbContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<EstadoCuenta> EstadosCuenta { get; set; }
        public DbSet<Movimiento> Movimientos { get; set; }


    }
}
