using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Autoparc.Models
{
    public class DriverLocationHistory
    {
        [Key]
        public int idLocation { get; set; }
        public string longitude { get; set; }
        public string latitude { get; set; }
        public string date { get; set; }

        public string cin { get; set; }
        [ForeignKey("cin")]
        public virtual User User { get; set; }
    }
}
