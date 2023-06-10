using SudokuGrille;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuAlgo.AlgoTraqueur
{
    public static class VerificationEtatGrille
    {
        public static EnumEtatGrille EtatGrille(Grille? _grille)
        {
            if (_grille != null)
            {
                foreach (Rangee rangee in _grille.Rangees)
                {
                    if (!rangee.LigneComplette())
                    {
                        return EnumEtatGrille.Incomplette;
                    }
                    return EnumEtatGrille.Complette;
                };
            }
            return EnumEtatGrille.Invalide;
        }
    }
}
