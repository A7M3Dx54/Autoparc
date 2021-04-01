using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Autoparc.Models
{
    public class User
    {
        [Key]
        public string cin { get; set; }
        public string firstname { get; set; }
        public string lastName { get; set; }
        public string role { get; set; }
        public string state { get; set; }
        public string password { get; set; }
        public string birthDate { get; set; }
        public int phone { get; set; }
        public string email { get; set; }

        //public virtual List<Tache> taches { get; set; }
        //public virtual List<Entretien> entretiens { get; set; }
    }
}
