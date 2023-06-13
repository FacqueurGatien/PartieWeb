using SudokuAlgo.AlgoAleatoire;
using SudokuAlgo.AlgoTraqueur;
using SudokuAlgo.RechercheIndice;
using SudokuGrille;

namespace SudokuProg
{
    public class Program
    {
        static void Main(string[] args)
        {

            Grille grille = new Grille(GrilleVierge());

            Console.WriteLine("Grille de Depart");
            Console.WriteLine(grille.ToString());

            Generateur generateur = new Generateur(grille);
            Grille grilleAleatoire = generateur.Generer();

            Console.WriteLine("\nGrille Aleatoire Généré");
            Console.WriteLine(grilleAleatoire.ToString());

            grille = new Grille(GrilleEssaie4());

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
            Console.WriteLine(grilleFinal.ToString());
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
        public static List<List<Case>> GrilleEssaie()
        {
            List<List<Case>> grille = new List<List<Case>>();
            for (int r = 0; r < 9; r++)
            {
                grille.Add(new List<Case>());
                for (int c = 0; c < 9; c++)
                {
                    grille[r].Add(new Case());
                }
            }
            grille[0][0].Contenu = new List<int>();
            grille[0][1].Contenu = new List<int>() { 5 };
            grille[0][2].Contenu = new List<int>() { 7 };

            grille[0][3].Contenu = new List<int>();
            grille[0][4].Contenu = new List<int>() { 2 };
            grille[0][5].Contenu = new List<int>();

            grille[0][6].Contenu = new List<int>();
            grille[0][7].Contenu = new List<int>();
            grille[0][8].Contenu = new List<int>();

            //Rangé2
            grille[1][0].Contenu = new List<int>();
            grille[1][1].Contenu = new List<int>();
            grille[1][2].Contenu = new List<int>();

            grille[1][3].Contenu = new List<int>();
            grille[1][4].Contenu = new List<int>();
            grille[1][5].Contenu = new List<int>() { 5 };

            grille[1][6].Contenu = new List<int>() { 2 };
            grille[1][7].Contenu = new List<int>();
            grille[1][8].Contenu = new List<int>() { 1 };

            //Rangé3
            grille[2][0].Contenu = new List<int>();
            grille[2][1].Contenu = new List<int>();
            grille[2][2].Contenu = new List<int>();

            grille[2][3].Contenu = new List<int>() { 7 };
            grille[2][4].Contenu = new List<int>() { 1 };
            grille[2][5].Contenu = new List<int>();

            grille[2][6].Contenu = new List<int>() { 8 };
            grille[2][7].Contenu = new List<int>();
            grille[2][8].Contenu = new List<int>() { 9 };

            //Rangé 4
            grille[3][0].Contenu = new List<int>();
            grille[3][1].Contenu = new List<int>();
            grille[3][2].Contenu = new List<int>();

            grille[3][3].Contenu = new List<int>();
            grille[3][4].Contenu = new List<int>();
            grille[3][5].Contenu = new List<int>();

            grille[3][6].Contenu = new List<int>();
            grille[3][7].Contenu = new List<int>();
            grille[3][8].Contenu = new List<int>();

            //Rangé5
            grille[4][0].Contenu = new List<int>();
            grille[4][1].Contenu = new List<int>() { 6 };
            grille[4][2].Contenu = new List<int>();

            grille[4][3].Contenu = new List<int>() { 8 };
            grille[4][4].Contenu = new List<int>();
            grille[4][5].Contenu = new List<int>() { 2 };

            grille[4][6].Contenu = new List<int>();
            grille[4][7].Contenu = new List<int>() { 1 };
            grille[4][8].Contenu = new List<int>();

            //Rangé6
            grille[5][0].Contenu = new List<int>();
            grille[5][1].Contenu = new List<int>();
            grille[5][2].Contenu = new List<int>();

            grille[5][3].Contenu = new List<int>();
            grille[5][4].Contenu = new List<int>() { 7 };
            grille[5][5].Contenu = new List<int>();

            grille[5][6].Contenu = new List<int>() { 9 };
            grille[5][7].Contenu = new List<int>();
            grille[5][8].Contenu = new List<int>();

            //Rangé 7
            grille[6][0].Contenu = new List<int>();
            grille[6][1].Contenu = new List<int>() { 9 };
            grille[6][2].Contenu = new List<int>();

            grille[6][3].Contenu = new List<int>();
            grille[6][4].Contenu = new List<int>();
            grille[6][5].Contenu = new List<int>();

            grille[6][6].Contenu = new List<int>();
            grille[6][7].Contenu = new List<int>() { 2 };
            grille[6][8].Contenu = new List<int>() { 4 };

            //Rangé8
            grille[7][0].Contenu = new List<int>();
            grille[7][1].Contenu = new List<int>() { 8 };
            grille[7][2].Contenu = new List<int>();

            grille[7][3].Contenu = new List<int>();
            grille[7][4].Contenu = new List<int>();
            grille[7][5].Contenu = new List<int>();

            grille[7][6].Contenu = new List<int>();
            grille[7][7].Contenu = new List<int>();
            grille[7][8].Contenu = new List<int>() { 6 };

            //Rangé9
            grille[8][0].Contenu = new List<int>() { 6 };
            grille[8][1].Contenu = new List<int>() { 4 };
            grille[8][2].Contenu = new List<int>() { 3 };

            grille[8][3].Contenu = new List<int>();
            grille[8][4].Contenu = new List<int>();
            grille[8][5].Contenu = new List<int>() { 1 };

            grille[8][6].Contenu = new List<int>();
            grille[8][7].Contenu = new List<int>();
            grille[8][8].Contenu = new List<int>() { 8 };
            return grille;
        }
        public static List<List<Case>> GrilleEssaie2()
        {
            List<List<Case>> grille = new List<List<Case>>();
            for (int r = 0; r < 9; r++)
            {
                grille.Add(new List<Case>());
                for (int c = 0; c < 9; c++)
                {
                    grille[r].Add(new Case());
                }
            }
            //Rangé1
            grille[0][0].Contenu = new List<int>();
            grille[0][1].Contenu = new List<int>();
            grille[0][2].Contenu = new List<int>();

            grille[0][3].Contenu = new List<int>();
            grille[0][4].Contenu = new List<int>() { 7 };
            grille[0][5].Contenu = new List<int>() { 9 };

            grille[0][6].Contenu = new List<int>();
            grille[0][7].Contenu = new List<int>();
            grille[0][8].Contenu = new List<int>();

            //Rangé2
            grille[1][0].Contenu = new List<int>();
            grille[1][1].Contenu = new List<int>();
            grille[1][2].Contenu = new List<int>() { 4 };

            grille[1][3].Contenu = new List<int>();
            grille[1][4].Contenu = new List<int>();
            grille[1][5].Contenu = new List<int>();

            grille[1][6].Contenu = new List<int>();
            grille[1][7].Contenu = new List<int>();
            grille[1][8].Contenu = new List<int>() { 3 };

            //Rangé3
            grille[2][0].Contenu = new List<int>();
            grille[2][1].Contenu = new List<int>();
            grille[2][2].Contenu = new List<int>() { 5 };

            grille[2][3].Contenu = new List<int>() ;
            grille[2][4].Contenu = new List<int>() ;
            grille[2][5].Contenu = new List<int>() { 4 };

            grille[2][6].Contenu = new List<int>() { 9 };
            grille[2][7].Contenu = new List<int>();
            grille[2][8].Contenu = new List<int>() { 6 };

            //Rangé 4
            grille[3][0].Contenu = new List<int>();
            grille[3][1].Contenu = new List<int>();
            grille[3][2].Contenu = new List<int>();

            grille[3][3].Contenu = new List<int>();
            grille[3][4].Contenu = new List<int>();
            grille[3][5].Contenu = new List<int>() { 1 };

            grille[3][6].Contenu = new List<int>();
            grille[3][7].Contenu = new List<int>();
            grille[3][8].Contenu = new List<int>();

            //Rangé5
            grille[4][0].Contenu = new List<int>() { 7 };
            grille[4][1].Contenu = new List<int>() { 9 };
            grille[4][2].Contenu = new List<int>();

            grille[4][3].Contenu = new List<int>();
            grille[4][4].Contenu = new List<int>();
            grille[4][5].Contenu = new List<int>() { 6 };

            grille[4][6].Contenu = new List<int>();
            grille[4][7].Contenu = new List<int>();
            grille[4][8].Contenu = new List<int>();

            //Rangé6
            grille[5][0].Contenu = new List<int>();
            grille[5][1].Contenu = new List<int>();
            grille[5][2].Contenu = new List<int>();

            grille[5][3].Contenu = new List<int>() { 8 };
            grille[5][4].Contenu = new List<int>();
            grille[5][5].Contenu = new List<int>();

            grille[5][6].Contenu = new List<int>() { 2 };
            grille[5][7].Contenu = new List<int>();
            grille[5][8].Contenu = new List<int>() { 4 };

            //Rangé 7
            grille[6][0].Contenu = new List<int>();
            grille[6][1].Contenu = new List<int>() { 1 };
            grille[6][2].Contenu = new List<int>();

            grille[6][3].Contenu = new List<int>();
            grille[6][4].Contenu = new List<int>();
            grille[6][5].Contenu = new List<int>();

            grille[6][6].Contenu = new List<int>();
            grille[6][7].Contenu = new List<int>() { 4 };
            grille[6][8].Contenu = new List<int>() { 9 };

            //Rangé8
            grille[7][0].Contenu = new List<int>();
            grille[7][1].Contenu = new List<int>() { 8 };
            grille[7][2].Contenu = new List<int>();

            grille[7][3].Contenu = new List<int>();
            grille[7][4].Contenu = new List<int>();
            grille[7][5].Contenu = new List<int>() { 5 };

            grille[7][6].Contenu = new List<int>() { 1 };
            grille[7][7].Contenu = new List<int>() { 6 };
            grille[7][8].Contenu = new List<int>();

            //Rangé9
            grille[8][0].Contenu = new List<int>();
            grille[8][1].Contenu = new List<int>() { 2 };
            grille[8][2].Contenu = new List<int>();

            grille[8][3].Contenu = new List<int>();
            grille[8][4].Contenu = new List<int>();
            grille[8][5].Contenu = new List<int>();

            grille[8][6].Contenu = new List<int>();
            grille[8][7].Contenu = new List<int>() { 8 };
            grille[8][8].Contenu = new List<int>() { 7 };
            return grille;
        }
        public static List<Ligne> GrilleEssaie4()
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
    }
}