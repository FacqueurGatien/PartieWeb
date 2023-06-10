using SudokuGrille;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuAlgo.RechercheIndice
{
    public static class RechercerIndices
    {
        public static int[] indices = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        public static void RechercherIndicesGrille(Grille _grille)//Rien a renvoyer car la grille est un passage de reference et non une copie
        {
            foreach (List<Case> rca in _grille.GrilleDepart)
            {
                foreach (Case cca in rca)
                {
                    if (cca.Contenu.Count != 1 )
                    {
                        foreach (int i in indices)
                        {
                            if (!_grille.Rangees[cca.NumRangee].VerifierDoublon(cca, i) && 
                                !_grille.Colonnes[cca.NumColonne].VerifierDoublon(cca, i) &&
                                !_grille.Blocks[cca.NumBlock].VerifierDoublon(cca, i))
                            {
                                cca.Contenu.Add(i);
                            }
                        }
                    }
                }
            }
        }
    }
}
