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
            bool incomplette = false;
            bool vierge = true;
            if (_grille != null)
            {
                foreach (List<Case> lca in _grille.GrilleDepart)
                {
                    foreach (Case ca in lca)
                    {
                        if (ca.Contenu.Count > 1)
                        {
                            incomplette = true;
                        }
                        else if (ca.Contenu.Count == 0)
                        {
                            return EnumEtatGrille.Invalide;
                        }
                        else if (ca.Contenu.Count < 9)
                        {
                            vierge = false;
                        }
                    }
                }
                if (incomplette)
                {
                    return EnumEtatGrille.Incomplette;
                }
                else if (vierge)
                {
                    return EnumEtatGrille.Vierge;
                }
                else
                {
                    return EnumEtatGrille.Complette;
                }
            }
            else
            {
                return EnumEtatGrille.Invalide;
            }
            
        }

    }

}
