using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Autoparc.Models
{
    public class EntretienType
    {
        [Key]
        public int idType { get; set; }
        public string label { get; set; }
        public int period { get; set; }
    }
}
