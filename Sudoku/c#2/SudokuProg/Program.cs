using SudokuAlgo.AlgoAleatoire;
using SudokuAlgo.AlgoReduction;
using SudokuAlgo.AlgoTraqueur;
using SudokuAlgo.ChoixDeLAlgorythme;
using SudokuAlgo.RechercheIndice;
using SudokuGrille;
using System.Diagnostics;

namespace SudokuProg
{
    public class Program
    {
        static void Main(string[] args)
        {

            /*           Grille grille = new Grille(GrilleVierge());

                       Console.WriteLine("Grille de Depart");
                       Console.WriteLine(grille.ToString());

                       Generateur generateur = new Generateur(grille);
                       Grille grilleAleatoire = generateur.Generer();

                       Console.WriteLine("\nGrille Aleatoire Généré");
                       Console.WriteLine(grilleAleatoire.ToString());*/

            //__________________________________________________________

            /*grille = new Grille(GrilleEssaie2());

            Console.WriteLine("Grille de Depart");
            Console.WriteLine(grille.ToString());

            Traqueur traqueur = new Traqueur(grille);
            Grille? grilleFinal = traqueur.Resolution();
            EnumEtatGrille solution = VerificationEtatGrille.EtatGrille(grilleFinal);

            switch (solution)
            {
                case EnumEtatGrille.Incomplette:
                    Console.WriteLine("La grille n'est pas completé");
                    break;
                case EnumEtatGrille.Complette:
                    Console.WriteLine("Une solution a été trouvé");
                    break;
                case EnumEtatGrille.Invalide:
                    Console.WriteLine("La grille n'a pas de solution");
                    break;
                case EnumEtatGrille.Vierge:
                    Console.WriteLine("La grille est vierge");
                    break;
                default:
                    break;
            }
            Console.WriteLine("\nGrille Final");
            Console.WriteLine(grilleFinal.ToString());*/

            //_____________________________________________________

            /* Grille grille = new Grille(GrilleVierge());
             Console.WriteLine("Grille de depart");
             Console.WriteLine(grille.ToString());


             Grille reduction = CopieGrille.Copie(grille);
             RechercerIndices.RechercherIndicesGrille(reduction);
             ReductionIndices.ReductionSeul(reduction);
             VerificationEtatGrille.EtatGrille(reduction);
             int niveauDifficult = reduction.CompterItterationTotal();
             if (reduction.EtatGrille==EnumEtatGrille.Complette)
             {
                 Console.WriteLine("Grille Resolu par l'algorythme de Reduction");
                 Console.WriteLine(reduction.ToString());
             }


             else
             {
                 string result;
                 Grille grilleFinal;
                 if (niveauDifficult < 180 || niveauDifficult >400)
                 {
                     Grille aleatoire = CopieGrille.Copie(grille);
                     Generateur generateur = new Generateur(grille);
                     RechercerIndices.RechercherIndicesGrille(aleatoire);
                     aleatoire = generateur.Generer();
                     grilleFinal = CopieGrille.Copie(aleatoire);
                     result = "Grille Resolu par l'algorythme pseudo aleatoire et l'algorythme de Reduction";
                 }

                 else
                 {
                     Grille traque = CopieGrille.Copie(grille);
                     Traqueur traqueur = new Traqueur(traque);
                     RechercerIndices.RechercherIndicesGrille(traque);
                     traque = traqueur.Resolution();
                     grilleFinal = CopieGrille.Copie(traque);
                     result = "Grille Resolu par l'algorythme Traqueur et l'algorythme de Reduction";
                 }

                 VerificationEtatGrille.EtatGrille(grilleFinal);
                 switch (grilleFinal.EtatGrille)
                 {
                     case EnumEtatGrille.Incomplette:
                         Console.WriteLine("La grille n'est pas completé");
                         break;
                     case EnumEtatGrille.Complette:
                         Console.WriteLine("Une solution a été trouvé");
                         Console.WriteLine(result);
                         break;
                     case EnumEtatGrille.Invalide:
                         Console.WriteLine("La grille n'a pas de solution");
                         break;
                     case EnumEtatGrille.Vierge:
                         Console.WriteLine("La grille est vierge");
                         break;
                     default:
                         break;
                 }
                 Console.WriteLine(grilleFinal.ToString());
             }*/
            Grille grille = new Grille(GrilleVierge());
            (string, Grille) result = ChoixAlgorythme.Redirection(grille);
            Console.WriteLine($"{result.Item1}\n{result.Item2.ToString()}");
            


            //_____________________________________________________________

        }
        public static List<Ligne> GrilleVierge()
        {
            List<Ligne> grille = new List<Ligne>();
            for (int r = 0; r < 9; r++)
            {
                grille.Add(new Ligne());
            }
            return grille;
        }
        public static List<Ligne> GrilleEssaie2()
        {
            List<Ligne> grille = new List<Ligne>();
            for (int r = 0; r < 9; r++)
            {
                grille.Add(new Ligne());
            }
            //Rangé1
            grille[0].Cases[0].PlacerChiffre(3);
            grille[0].Cases[1].PlacerChiffre(8);

            grille[0].Cases[3].PlacerChiffre(7);

            grille[0].Cases[6].PlacerChiffre(2);
            grille[0].Cases[7].PlacerChiffre(6);

            //Rangé2
            grille[1].Cases[5].PlacerChiffre(8);

            grille[1].Cases[7].PlacerChiffre(7);
            grille[1].Cases[8].PlacerChiffre(1);

            //Rangé3
            grille[2].Cases[1].PlacerChiffre(9);

            grille[2].Cases[6].PlacerChiffre(3);
            grille[2].Cases[7].PlacerChiffre(8);
            grille[2].Cases[8].PlacerChiffre(4);

            //Rangé 4
            grille[3].Cases[0].PlacerChiffre(1);

            grille[3].Cases[7].PlacerChiffre(5);

            //Rangé5
            grille[4].Cases[0].PlacerChiffre(4);
            grille[4].Cases[1].PlacerChiffre(7);

            grille[4].Cases[4].PlacerChiffre(8);

            //Rangé6
            grille[5].Cases[0].PlacerChiffre(8);

            grille[5].Cases[5].PlacerChiffre(6);

            grille[5].Cases[8].PlacerChiffre(3);


            //Rangé 7
            grille[6].Cases[3].PlacerChiffre(9);
            grille[6].Cases[4].PlacerChiffre(4);

            //Rangé8
            grille[7].Cases[0].PlacerChiffre(5);

            grille[7].Cases[3].PlacerChiffre(8);
            grille[7].Cases[4].PlacerChiffre(6);

            //Rangé9
            grille[8].Cases[4].PlacerChiffre(5);
            grille[8].Cases[5].PlacerChiffre(1);

            return grille;
        }
        public static List<Ligne> GrilleEssaie3()
        {
            List<Ligne> grille = new List<Ligne>();
            for (int r = 0; r < 9; r++)
            {
                grille.Add(new Ligne());
            }
            //Rangé1
            grille[0].Cases[1].PlacerChiffre(6);
            grille[0].Cases[5].PlacerChiffre(1);
            grille[0].Cases[6].PlacerChiffre(8);
            //Rangé2
            grille[1].Cases[2].PlacerChiffre(8);
            grille[1].Cases[3].PlacerChiffre(9);
            grille[1].Cases[4].PlacerChiffre(6);
            grille[1].Cases[5].PlacerChiffre(4);
            grille[1].Cases[7].PlacerChiffre(1);
            //Rangé3
            grille[2].Cases[0].PlacerChiffre(9);
            grille[2].Cases[1].PlacerChiffre(1);
            grille[2].Cases[2].PlacerChiffre(4);
            grille[2].Cases[5].PlacerChiffre(7);
            grille[2].Cases[6].PlacerChiffre(3);
            grille[2].Cases[7].PlacerChiffre(6);
            grille[2].Cases[8].PlacerChiffre(2);

            //Rangé 4
            grille[3].Cases[5].PlacerChiffre(3);
            grille[3].Cases[6].PlacerChiffre(6);
            grille[3].Cases[7].PlacerChiffre(7);

            //Rangé5
            grille[4].Cases[0].PlacerChiffre(6);
            grille[4].Cases[1].PlacerChiffre(7);
            grille[4].Cases[3].PlacerChiffre(1);
            grille[4].Cases[6].PlacerChiffre(5);

            //Rangé6
            grille[5].Cases[0].PlacerChiffre(1);
            grille[5].Cases[1].PlacerChiffre(5);
            grille[5].Cases[2].PlacerChiffre(3);
            grille[5].Cases[3].PlacerChiffre(7);
            grille[5].Cases[4].PlacerChiffre(8);
            grille[5].Cases[5].PlacerChiffre(6);
            grille[5].Cases[6].PlacerChiffre(4);
            grille[5].Cases[7].PlacerChiffre(2);

            //Rangé 7
            grille[6].Cases[1].PlacerChiffre(8);
            grille[6].Cases[4].PlacerChiffre(3);
            grille[6].Cases[6].PlacerChiffre(2);
            grille[6].Cases[7].PlacerChiffre(5);

            //Rangé8
            grille[7].Cases[0].PlacerChiffre(7);
            grille[7].Cases[1].PlacerChiffre(2);
            grille[7].Cases[2].PlacerChiffre(6);
            grille[7].Cases[3].PlacerChiffre(4);
            grille[7].Cases[4].PlacerChiffre(1);
            grille[7].Cases[6].PlacerChiffre(9);
            grille[7].Cases[8].PlacerChiffre(3);

            //Rangé9
            grille[8].Cases[1].PlacerChiffre(9);
            grille[8].Cases[4].PlacerChiffre(7);
            grille[8].Cases[5].PlacerChiffre(8);
            grille[8].Cases[7].PlacerChiffre(4);

            return grille;
        }

    }
}