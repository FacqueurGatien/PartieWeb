using System.ComponentModel.DataAnnotations;

namespace Grilles.Models
{
    public class Grille
    {
/*        public int id { get; set; }*/
        public List<Ligne> rangees {  get; set; }

        public Grille(/*int _id,*/SudokuGrille.Grille _grille)
        {
            /*id = _id;
            int idLigne = _id*9-9+1;*/
            rangees = new List<Ligne>();
            foreach (SudokuGrille.Ligne item in _grille.Rangees)
            {
                rangees.Add(new Ligne(/*idLigne++,*/item.Cases));
            }

        }
    }
}