using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Autoparc.Models
{
    public class Tache
    {
        [Key]
        public int id { get; set; }
        public string departurePoint { get; set; }
        public string arrivalPoint { get; set; }
        public string date { get; set; }
        public string state { get; set; }
        public string departureDate { get; set; }
        public string arrivalDate { get; set; }
        public string description { get; set; }
        public string priority { get; set; }
        public string usedCar { get; set; }

        public string cin { get; set; }
        [ForeignKey("cin")]
        public virtual User User { get; set; }

        public string registrationNumber { get; set; }
        [ForeignKey("registrationNumber")]
        public virtual  Vehicule Vehicule { get; set; }

        

        public Tache() { }

    }
}
