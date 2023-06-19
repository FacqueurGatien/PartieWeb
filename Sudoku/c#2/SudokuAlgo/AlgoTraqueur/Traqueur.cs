using SudokuGrille;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SudokuAlgo.RechercheIndice;
using SudokuAlgo.AlgoReduction;

namespace SudokuAlgo.AlgoTraqueur
{
    public class Traqueur
    {
        public Grille GrilleAResoudre { get; set; }

        public Traqueur(Grille _grille)
        {
             GrilleAResoudre= _grille;
        }
        public Grille? Resolution()
        {
            //Etape 1
            ReductionIndices.Reduction(GrilleAResoudre);
            VerificationEtatGrille.EtatGrille(GrilleAResoudre);

            //Etape 
            if (GrilleAResoudre.EtatGrille==EnumEtatGrille.Incomplette)
            {
                Grille? grilleFinal = AlgoResolveur.Demarer(GrilleAResoudre);
                VerificationEtatGrille.EtatGrille(grilleFinal);
                return grilleFinal;
            }
            else
            {
                return null;
            }
        }

        public override string ToString()
        {
            string result = "";
            foreach (Ligne r in GrilleAResoudre.Rangees)
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
