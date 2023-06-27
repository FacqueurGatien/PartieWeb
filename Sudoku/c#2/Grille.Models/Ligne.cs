using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grille.Models
{
    public class Ligne:Model
    {
        [Required]
        public List<Case> Cases { get; set; }
    }
}
