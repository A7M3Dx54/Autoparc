using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Autoparc.Models
{
    public class Task
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

        public Task() { }

    }
}
