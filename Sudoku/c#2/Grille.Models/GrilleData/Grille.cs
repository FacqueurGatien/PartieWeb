using System.ComponentModel.DataAnnotations;

namespace Grilles.Models.GrilleData
{
    public class Grille:Model
    {
        [Required]
        public List<Ligne> Rangees {  get; set; }

    }
}