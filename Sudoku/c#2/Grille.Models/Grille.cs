using System.ComponentModel.DataAnnotations;

namespace Grille.Models
{
    public class Grille:Model
    {
        [Required]
        public List<Ligne> Rangees {  get; set; }
    }
}