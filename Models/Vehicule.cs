using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Autoparc.Models
{
    public class Vehicule
    {
        [Key]
        public string registrationNumber { get; set; }
        public string mark { get; set; }
        public string model { get; set; }
        public string state { get; set; }  
        public long totalDistance { get; set; }
        public int reservoir { get; set; }
        public double kmPerLittre { get; set; }
        //public virtual List<Tache> Taches { get; set; }
       
    }
}
