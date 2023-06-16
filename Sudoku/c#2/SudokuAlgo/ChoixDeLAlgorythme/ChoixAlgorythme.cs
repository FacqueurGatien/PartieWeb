﻿using SudokuAlgo.AlgoAleatoire;
using SudokuAlgo.AlgoReduction;
using SudokuAlgo.AlgoTraqueur;
using SudokuAlgo.RechercheIndice;
using SudokuGrille;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuAlgo.ChoixDeLAlgorythme
{
    public static class ChoixAlgorythme
    {
        public static (string,Grille) Redirection(Grille _grille)
        {
            string result="";
            Grille reduction = AlgoReduction(_grille);

            if (reduction.EtatGrille == EnumEtatGrille.Complette)
            {
                result+="Grille Resolu par l'algorythme de Reduction";
                result = EtatGrilleApresTraitement(reduction,result);
                return (result,reduction);
            }
            else
            {
                int niveauDifficulte = reduction.CompterItterationTotal();
                Grille grilleFinal;
                if (niveauDifficulte < 180 || niveauDifficulte > 400)
                {
                    grilleFinal = AlgoPseudoAleatoire(_grille);
                    result += "Grille Resolu par l'algorythme pseudo aleatoire et l'algorythme de Reduction";
                }

                else
                {
                    grilleFinal = AlgoTraqueur(_grille);
                    result += "Grille Resolu par l'algorythme Traqueur et l'algorythme de Reduction";
                }
                result = EtatGrilleApresTraitement(grilleFinal,result);
                return (result, grilleFinal);
            }

        }
        public static Grille AlgoReduction(Grille _grille)
        {
            Grille reduction = CopieGrille.Copie(_grille);
            RechercerIndices.RechercherIndicesGrille(reduction);
            ReductionIndices.ReductionSeul(reduction);
            VerificationEtatGrille.EtatGrille(reduction);
            return reduction;
        }
        public static Grille AlgoPseudoAleatoire(Grille _grille)
        {
            Grille aleatoire = CopieGrille.Copie(_grille);
            Generateur generateur = new Generateur(aleatoire);
            aleatoire = generateur.Generer();
            return aleatoire;
        }
        public static Grille AlgoTraqueur(Grille _grille)
        {
            Grille traque = CopieGrille.Copie(_grille);
            Traqueur traqueur = new Traqueur(traque);
            RechercerIndices.RechercherIndicesGrille(traque);
            traque = traqueur.Resolution();
            return traque;
        }
        public static string EtatGrilleApresTraitement(Grille _grille,string _result)
        {
            VerificationEtatGrille.EtatGrille(_grille);
            string result="";
            switch (_grille.EtatGrille)
            {
                case EnumEtatGrille.Incomplette:
                    result = "La grille n'est pas completé";
                    break;
                case EnumEtatGrille.Complette:
                    result = "Une solution a été trouvé";
                    break;
                case EnumEtatGrille.Invalide:
                    result = "La grille n'a pas de solution";
                    break;
                case EnumEtatGrille.Vierge:
                    result = "La grille est vierge";
                    break;
                default:
                    break;
            }
            return $"{result}\n{_result}";
        }
    }
}