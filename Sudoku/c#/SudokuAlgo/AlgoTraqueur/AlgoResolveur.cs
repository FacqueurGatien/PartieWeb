using SudokuGrille;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuAlgo.AlgoTraqueur
{
    public static class AlgoResolveur
    {
        public static Grille Demarer(Grille _grille)
        {
            int compteur=0;
            while (compteur<1000)
            {
                Grille grille = CopieGrille.Copie(_grille);//Copier la grille de depart a chaque itteration

                //Traitement a venir
                if (true)//Renvoyer la premiere grille valide
                {
                    return grille;
                }
            }
            return null;//Renvoyer une grille vide si pas de solution
        }
    }
}
