using Microsoft.EntityFrameworkCore;

namespace Autoparc.Models
{
    public class VehiculeContext : DbContext
    {
        public VehiculeContext(DbContextOptions<VehiculeContext> options)
            : base(options)
        {
        }

        public DbSet<Vehicule> vehicules { get; set; }
    }
}