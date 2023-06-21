using SudokuAlgo.AlgoTraqueur;
using SudokuAlgo.RechercheIndice;
using SudokuGrille;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuAlgo.AlgoReduction
{
    public static class ReductionIndices
    {
        public static void Reduction(Grille _grille)
        {
            PurgerGrille(_grille);
            RechercerIndices.RechercherIndicesGrille(_grille);
            _grille.VerifierEtatGrille();
        }
        public static void PurgerGrille(Grille _grille)
        {
            int depart;
            int fin = int.MaxValue;
            do
            {
                depart = fin;
                foreach (Ligne rca in _grille.Rangees)
                {
                    foreach (Case cca in rca.Cases)
                    {
                        if (cca.Contenu.Count == 1)
                        {
                            _grille.Rangees[cca.NumRangee].PurgerLigne(cca, cca.Contenu[0]);
                            _grille.Colonnes[cca.NumColonne].PurgerLigne(cca, cca.Contenu[0]);
                            _grille.Blocks[cca.NumBlock].PurgerLigne(cca, cca.Contenu[0]);
                        }
                    }
                }
                fin = _grille.CompterItterationTotal();
            }
            while (depart != fin);
        }
    }

}
