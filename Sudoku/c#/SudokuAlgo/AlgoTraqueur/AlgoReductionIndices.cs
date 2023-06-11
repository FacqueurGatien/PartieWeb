using SudokuGrille;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuAlgo.AlgoTraqueur
{
    public static class AlgoReductionIndices
    {
        public static void Reduction(Grille _grille)
        {
            PurgerGrille(_grille);
            _grille.EtatGrille = VerificationEtatGrille.EtatGrille(_grille);
        }
        public static void PurgerGrille(Grille _grille)
        {
            bool recommencerPurge = true;
            while (recommencerPurge)
            {
                recommencerPurge = false;
                _grille.PurgeRecomencer = false;
                foreach (List<Case> rca in _grille.GrilleDepart)
                {
                    foreach (Case cca in rca)
                    {
                        if (cca.Contenu.Count == 1)
                        {
                            if (!recommencerPurge)
                            {
                                _grille.Rangees[cca.NumRangee].PurgerLigne(cca, cca.Contenu[0], _grille);
                                _grille.Colonnes[cca.NumColonne].PurgerLigne(cca, cca.Contenu[0], _grille);
                                _grille.Blocks[cca.NumBlock].PurgerLigne(cca, cca.Contenu[0], _grille);
                            }
                            else
                            {
                                _grille.Rangees[cca.NumRangee].PurgerLigne(cca, cca.Contenu[0]);
                                _grille.Colonnes[cca.NumColonne].PurgerLigne(cca, cca.Contenu[0]);
                                _grille.Blocks[cca.NumBlock].PurgerLigne(cca, cca.Contenu[0]);
                            }
                            if (_grille.PurgeRecomencer)
                            {
                                recommencerPurge = true;
                            }
                        }
                    }
                }
                recommencerPurge = PurgerGrilleItteration(_grille);
            }
        }
        public static bool PurgerGrilleItteration(Grille _grille)
        {
            bool recomencerItteration=true;
            bool recomencerPurge = false;
            while (recomencerItteration)
            {
                recomencerItteration = false;
                foreach (List<Case> rca in _grille.GrilleDepart)
                {
                    foreach (Case cca in rca)
                    {
                        if (cca.Contenu.Count > 1)
                        {
                            if(cca.NumBlock==2 && cca.NumRangee==1 && cca.NumColonne==7)
                            {

                            }
                            for(int i =0;i < cca.Contenu.Count;i++)
                            {
                                if ((_grille.Rangees[cca.NumRangee].VerifierLigneComplette()&&
                                    _grille.Rangees[cca.NumRangee].Itteration[cca.Contenu[i]]==1) ||
                                    (_grille.Colonnes[cca.NumColonne].VerifierLigneComplette() &&
                                    _grille.Colonnes[cca.NumColonne].Itteration[cca.Contenu[i]] == 1)||
                                    (_grille.Blocks[cca.NumBlock].VerifierLigneComplette() &&
                                    _grille.Blocks[cca.NumBlock].Itteration[cca.Contenu[i]] == 1))
                                {
                                    cca.PlacerChiffre(cca.Contenu[i]);
                                    recomencerPurge = true;
                                    recomencerItteration = true;
                                }
                            }
                        }
                    }
                }
            }
            return recomencerPurge;
        }
    }

}
