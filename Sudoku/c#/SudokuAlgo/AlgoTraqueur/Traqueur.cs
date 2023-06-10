using SudokuGrille;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SudokuAlgo.RechercheIndice;

namespace SudokuAlgo.AlgoTraqueur
{
    public class Traqueur
    {
        public Grille GrilleAResoudre { get; set; }

        public Traqueur(Grille _grille)
        {
            //Etape 1
             RechercerIndices.RechercherIndicesGrille(_grille);
             GrilleAResoudre= _grille;
        }
        public EnumEtatGrille Resolution()
        {
            //Etape 2
            AlgoReductionIndices.Reduction(GrilleAResoudre);
            EnumEtatGrille solution = VerificationEtatGrille.EtatGrille(GrilleAResoudre);

            //Etape 3
            if (solution==EnumEtatGrille.Incomplette)
            {
                Grille grilleFinal = AlgoResolveur.Demarer(GrilleAResoudre);
                solution = VerificationEtatGrille.EtatGrille(grilleFinal);
                return solution;
            }
            else
            {
                return solution;
            }
        }

        public override string ToString()
        {
            string result = "";
            foreach (Rangee r in GrilleAResoudre.Rangees)
            {
                result += "\n________________________________________________________________________________________________________________\n";
                foreach (Case c in r.Cases)
                {
                    result += "(";
                    string temp = "";
                    foreach (int n in c.Contenu)
                    {
                        temp += n;
                    }
                    result += string.Format("{0,-9})|", temp);
                }
            }
            result += "\n________________________________________________________________________________________________________________";
            return result;
        }
    }
}
