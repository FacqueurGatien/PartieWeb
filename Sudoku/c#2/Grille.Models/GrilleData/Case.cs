using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grilles.Models.GrilleData
{
    [Table("cases")]
    public class Case:Model
    {
        [Required]
        public int Contenu { get; set; }
        [Required]
        public int Num_Rangee { get; set; }
        [Required]
        public int Num_Colonne { get; set; }
        [Required]
        public int Num_Block { get; set; }

    }
}
