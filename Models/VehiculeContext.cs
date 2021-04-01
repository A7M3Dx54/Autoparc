using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Autoparc.Models
{
    public class VehiculeContext:DbContext
    {
        public VehiculeContext(DbContextOptions<VehiculeContext> options): base(options)
        {
        }

        public virtual DbSet<Vehicule> vehicules { get; set; }
        public virtual DbSet<Tache> taches { get; set; }
        public virtual DbSet<User> users { get; set; }
        public virtual DbSet<Entretien> entretiens { get; set; }
        public virtual DbSet<EntretienType> entretienTypes { get; set; }
        public virtual DbSet<DriverLocationHistory> driverLocationsHistory { get; set; }
    }
}
