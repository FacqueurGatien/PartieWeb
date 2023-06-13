using SudokuGrille;
using SudokuAlgo.RechercheIndice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace SudokuAlgo.AlgoAleatoire
{
    public class Generateur
    {
        public Grille GrilleAGenerer { get; set; }
        public Generateur(Grille _grille)
        {
            GrilleAGenerer = _grille;
        }
        public Grille Generer()
        {
            foreach (Ligne l in GrilleAGenerer.Rangees)
            {
                //Etape 1 Rechercher les indices d'une ligne
                RechercerIndices.RechercherIndicesLigne(GrilleAGenerer,l);
                ResolutionLigneAleatoire(l);
            }
            return GrilleAGenerer;
        }
        public void ResolutionLigneAleatoire(Ligne _ligne)
        {

        }
        public Ligne CopieLigneAResoudre(Ligne _ligne)
        {
            //Etape2 Copier la ligne
            Ligne ligneCopie = new Ligne(_ligne);

            //Etape3 Trier la ligne
            foreach (Case i in ligneCopie.Cases.OrderBy(ca => ca.Contenu.Count)) ;

            //Etape4

            return ligneCopie;
        }
    }
}
