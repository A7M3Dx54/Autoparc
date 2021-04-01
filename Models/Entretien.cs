using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Autoparc.Models
{
    public class Entretien
    {
        [Key]
        public int id { get; set; }
        public string description { get; set; }
        public string state { get; set; }
        public float cost { get; set; }
        public string dateDebut { get; set; }
        public string dateFin { get; set; }

        public string registrationNumber { get; set; }
        [ForeignKey("registrationNumber")]
        public virtual Vehicule Vehicule { get; set; }

        public string cin { get; set; }
        [ForeignKey("cin")]
        public virtual User User { get; set; }

        public int idType { get; set; }
        [ForeignKey("idType")]
        public virtual EntretienType EntretienType { get; set; }
    }
}
