using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grilles.Models.GrilleData
{
    [Table("rangees")]
    public class Ligne:Model
    {
        [Required]
        public List<Case> Cases { get; set; }
    }
}
