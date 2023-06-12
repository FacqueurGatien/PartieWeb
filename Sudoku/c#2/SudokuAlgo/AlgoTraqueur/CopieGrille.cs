using SudokuGrille;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuAlgo.AlgoTraqueur
{
    public static class CopieGrille
    {
        public static Grille Copie(Grille _grille)
        {
            List<Ligne> listeCase = new List<Ligne>();
            for (int r = 0; r < 9; r++)
            {
                listeCase.Add(new Ligne());
                for (int c = 0; c < 9; c++)
                {
                    List<int> temp = new List<int>();
                    temp.AddRange(_grille.Rangees[r].Cases[c].Contenu);
                    listeCase[r].Cases[c] =new Case(temp);
                }
            }
            Grille grille = new Grille(listeCase);
            return grille;
        }
    }
}
