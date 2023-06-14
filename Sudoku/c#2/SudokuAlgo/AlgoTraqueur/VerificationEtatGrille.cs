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
        public static void EtatGrille(Grille? _grille)
        {
            bool incomplette = false;
            bool vierge = true;
            if (_grille != null)
            {
                foreach (Ligne lca in _grille.Rangees)
                {
                    foreach (Case ca in lca.Cases)
                    {
                        if (ca.Contenu.Count > 1)
                        {
                            incomplette = true;
                        }
                        else if (ca.Contenu.Count == 0)
                        {
                             _grille.EtatGrille=EnumEtatGrille.Invalide;
                        }
                        else if (ca.Contenu.Count < 9)
                        {
                            vierge = false;
                        }
                    }
                }
                if (incomplette)
                {
                    _grille.EtatGrille = EnumEtatGrille.Incomplette;
                }
                else if (vierge)
                {
                    _grille.EtatGrille = EnumEtatGrille.Vierge;
                }
                else
                {
                    _grille.EtatGrille = EnumEtatGrille.Complette;
                }
            }
            else
            {
                _grille.EtatGrille = EnumEtatGrille.Invalide;
            }
            
        }

    }

}
