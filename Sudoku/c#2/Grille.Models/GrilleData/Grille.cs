using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Grilles.Models.GrilleData
{
    [Table("grilles")]
    public class Grille:Model
    {
        [Required]
        public List<Ligne> Rangees {  get; set; }

    }
}