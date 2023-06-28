using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grilles.Models.GrilleData
{
    public class Ligne:Model
    {
        [Required]
        public List<Case> Cases { get; set; }
    }
}
