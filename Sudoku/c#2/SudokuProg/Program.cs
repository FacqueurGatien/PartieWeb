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
            Grille grille = new Grille(GrilleEssaie2());
            Grille result = ChoixAlgorythme.Redirection(grille);
            Console.WriteLine($"{result.ResolutionMessage}\n{result}");

            grille = new Grille(GrilleEssaie3());
            result = ChoixAlgorythme.Redirection(grille);
            Console.WriteLine($"{result.ResolutionMessage}\n{result}");

            grille = new Grille(GrilleEssaie4());
            result = ChoixAlgorythme.Redirection(grille);
            Console.WriteLine($"{result.ResolutionMessage}\n{result}");

            grille = new Grille(GrilleVierge());
            result = ChoixAlgorythme.Redirection(grille);
            Console.WriteLine($"{result.ResolutionMessage}\n{result}");
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
        public static List<Ligne> GrilleEssaie4()
        {
            List<Ligne> grille = new List<Ligne>();
            for (int r = 0; r < 9; r++)
            {
                grille.Add(new Ligne());
            }
            int n = 0;
            //Rangé1
            grille[n].Cases[0].PlacerChiffre(9);
            grille[n].Cases[1].PlacerChiffre();
            grille[n].Cases[2].PlacerChiffre(3);
            grille[n].Cases[3].PlacerChiffre(6);
            grille[n].Cases[4].PlacerChiffre(8);
            grille[n].Cases[5].PlacerChiffre(7);
            grille[n].Cases[6].PlacerChiffre();
            grille[n].Cases[7].PlacerChiffre(5);
            grille[n++].Cases[8].PlacerChiffre(4);
            //Rangé2
            grille[n].Cases[0].PlacerChiffre();
            grille[n].Cases[1].PlacerChiffre(4);
            grille[n].Cases[2].PlacerChiffre(6);
            grille[n].Cases[3].PlacerChiffre(2);
            grille[n].Cases[4].PlacerChiffre(9);
            grille[n].Cases[5].PlacerChiffre();
            grille[n].Cases[6].PlacerChiffre();
            grille[n].Cases[7].PlacerChiffre(1);
            grille[n++].Cases[8].PlacerChiffre(7);
            //Rangé3
            grille[n].Cases[0].PlacerChiffre(2);
            grille[n].Cases[1].PlacerChiffre(8);
            grille[n].Cases[2].PlacerChiffre(7);
            grille[n].Cases[3].PlacerChiffre();
            grille[n].Cases[4].PlacerChiffre(5);
            grille[n].Cases[5].PlacerChiffre();
            grille[n].Cases[6].PlacerChiffre(6);
            grille[n].Cases[7].PlacerChiffre(3);
            grille[n++].Cases[8].PlacerChiffre(9);
            //Rangé 4
            grille[n].Cases[0].PlacerChiffre(8);
            grille[n].Cases[1].PlacerChiffre(2);
            grille[n].Cases[2].PlacerChiffre(5);
            grille[n].Cases[3].PlacerChiffre(4);
            grille[n].Cases[4].PlacerChiffre(6);
            grille[n].Cases[5].PlacerChiffre(9);
            grille[n].Cases[6].PlacerChiffre();
            grille[n].Cases[7].PlacerChiffre(7);
            grille[n++].Cases[8].PlacerChiffre(3);
            //Rangé5
            grille[n].Cases[0].PlacerChiffre(4);
            grille[n].Cases[1].PlacerChiffre(7);
            grille[n].Cases[2].PlacerChiffre();
            grille[n].Cases[3].PlacerChiffre(3);
            grille[n].Cases[4].PlacerChiffre(2);
            grille[n].Cases[5].PlacerChiffre(1);
            grille[n].Cases[6].PlacerChiffre(5);
            grille[n].Cases[7].PlacerChiffre(6);
            grille[n++].Cases[8].PlacerChiffre();
            //Rangé6
            grille[n].Cases[0].PlacerChiffre(6);
            grille[n].Cases[1].PlacerChiffre(3);
            grille[n].Cases[2].PlacerChiffre(1);
            grille[n].Cases[3].PlacerChiffre(8);
            grille[n].Cases[4].PlacerChiffre(7);
            grille[n].Cases[5].PlacerChiffre(5);
            grille[n].Cases[6].PlacerChiffre(4);
            grille[n].Cases[7].PlacerChiffre();
            grille[n++].Cases[8].PlacerChiffre(2);
            //Rangé 7
            grille[n].Cases[0].PlacerChiffre(1);
            grille[n].Cases[1].PlacerChiffre();
            grille[n].Cases[2].PlacerChiffre(2);
            grille[n].Cases[3].PlacerChiffre();
            grille[n].Cases[4].PlacerChiffre(3);
            grille[n].Cases[5].PlacerChiffre();
            grille[n].Cases[6].PlacerChiffre(7);
            grille[n].Cases[7].PlacerChiffre(4);
            grille[n++].Cases[8].PlacerChiffre(6);
            //Rangé8
            grille[n].Cases[0].PlacerChiffre(3);
            grille[n].Cases[1].PlacerChiffre(5);
            grille[n].Cases[2].PlacerChiffre(8);
            grille[n].Cases[3].PlacerChiffre();
            grille[n].Cases[4].PlacerChiffre(4);
            grille[n].Cases[5].PlacerChiffre(6);
            grille[n].Cases[6].PlacerChiffre(9);
            grille[n].Cases[7].PlacerChiffre(2);
            grille[n++].Cases[8].PlacerChiffre();
            //Rangé9
            grille[n].Cases[0].PlacerChiffre(7);
            grille[n].Cases[1].PlacerChiffre();
            grille[n].Cases[2].PlacerChiffre(4);
            grille[n].Cases[3].PlacerChiffre(9);
            grille[n].Cases[4].PlacerChiffre();
            grille[n].Cases[5].PlacerChiffre(2);
            grille[n].Cases[6].PlacerChiffre(3);
            grille[n].Cases[7].PlacerChiffre(8);
            grille[n++].Cases[8].PlacerChiffre(5);
            return grille;
        }

    }
}