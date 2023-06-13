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
        public static void RechercherIndicesGrille(Grille _grille)
        {
            foreach (Ligne rca in _grille.Rangees)
            {
                foreach (Case cca in rca.Cases)
                {
                    if (cca.Contenu.Count != 1)
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
        public static void RechercherIndicesLigne(Grille _grille, Ligne _ligne)
        {
            foreach (Case cca in _ligne.Cases)
            {
                if (cca.Contenu.Count != 1)
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
