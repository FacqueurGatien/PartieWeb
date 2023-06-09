using SudokuGrille;

namespace SudokuProg
{
    public class Program
    {
        static void Main(string[] args)
        {

            Grille grille = new Grille(GrilleEssaie());
            Console.WriteLine(grille.ToString());

            Console.WriteLine(grille.Rangees[0].Cases[1].Contenu[0]);
            Console.WriteLine(grille.Colonnes[1].Cases[0].Contenu[0]);
            Console.WriteLine(grille.Blocks[0].Cases[1].Contenu[0]);

            grille.Rangees[0].Cases[1].Contenu[0] = 3;

            Console.WriteLine(grille.Rangees[0].Cases[1].Contenu[0]);
            Console.WriteLine(grille.Colonnes[1].Cases[0].Contenu[0]);
            Console.WriteLine(grille.Blocks[0].Cases[1].Contenu[0]);

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
            grille[0][0].Contenu = new List<int>() { 0 };
            grille[0][1].Contenu = new List<int>() { 5 };
            grille[0][2].Contenu = new List<int>() { 7 };

            grille[0][3].Contenu = new List<int>() { 0 };
            grille[0][4].Contenu = new List<int>() { 2 };
            grille[0][5].Contenu = new List<int>() { 0 };

            grille[0][6].Contenu = new List<int>() { 0 };
            grille[0][7].Contenu = new List<int>() { 0 };
            grille[0][8].Contenu = new List<int>() { 0 };

            //Rangé2
            grille[1][0].Contenu = new List<int>() { 0 };
            grille[1][1].Contenu = new List<int>() { 0 };
            grille[1][2].Contenu = new List<int>() { 0 };

            grille[1][3].Contenu = new List<int>() { 0 };
            grille[1][4].Contenu = new List<int>() { 0 };
            grille[1][5].Contenu = new List<int>() { 5 };

            grille[1][6].Contenu = new List<int>() { 0 };
            grille[1][7].Contenu = new List<int>() { 0 };
            grille[1][8].Contenu = new List<int>() { 1 };

            //Rangé3
            grille[2][0].Contenu = new List<int>() { 0 };
            grille[2][1].Contenu = new List<int>() { 0 };
            grille[2][2].Contenu = new List<int>() { 0 };

            grille[2][3].Contenu = new List<int>() { 7 };
            grille[2][4].Contenu = new List<int>() { 1 };
            grille[2][5].Contenu = new List<int>() { 0 };

            grille[2][6].Contenu = new List<int>() { 8 };
            grille[2][7].Contenu = new List<int>() { 0 };
            grille[2][8].Contenu = new List<int>() { 9 }; 

            //Rangé 4
            grille[3][0].Contenu = new List<int>() { 0 };
            grille[3][1].Contenu = new List<int>() { 0 };
            grille[3][2].Contenu = new List<int>() { 0 };

            grille[3][3].Contenu = new List<int>() { 0 };
            grille[3][4].Contenu = new List<int>() { 0 };
            grille[3][5].Contenu = new List<int>() { 0 };

            grille[3][6].Contenu = new List<int>() { 0 };
            grille[3][7].Contenu = new List<int>() { 0 };
            grille[3][8].Contenu = new List<int>() { 0 };

            //Rangé5
            grille[4][0].Contenu = new List<int>() { 0 };
            grille[4][1].Contenu = new List<int>() { 6 };
            grille[4][2].Contenu = new List<int>() { 0 };

            grille[4][3].Contenu = new List<int>() { 8 };
            grille[4][4].Contenu = new List<int>() { 0 };
            grille[4][5].Contenu = new List<int>() { 2 };

            grille[4][6].Contenu = new List<int>() { 0 };
            grille[4][7].Contenu = new List<int>() { 1 };
            grille[4][8].Contenu = new List<int>() { 0 };

            //Rangé6
            grille[5][0].Contenu = new List<int>() { 0 };
            grille[5][1].Contenu = new List<int>() { 0 };
            grille[5][2].Contenu = new List<int>() { 0 };

            grille[5][3].Contenu = new List<int>() { 0 };
            grille[5][4].Contenu = new List<int>() { 7 };
            grille[5][5].Contenu = new List<int>() { 0 };

            grille[5][6].Contenu = new List<int>() { 9 };
            grille[5][7].Contenu = new List<int>() { 0 };
            grille[5][8].Contenu = new List<int>() { 0 };

            //Rangé 7
            grille[6][0].Contenu = new List<int>() { 0 };
            grille[6][1].Contenu = new List<int>() { 9 };
            grille[6][2].Contenu = new List<int>() { 0 };

            grille[6][3].Contenu = new List<int>() { 0 };
            grille[6][4].Contenu = new List<int>() { 0 };
            grille[6][5].Contenu = new List<int>() { 0 };

            grille[6][6].Contenu = new List<int>() { 0 };
            grille[6][7].Contenu = new List<int>() { 2 };
            grille[6][8].Contenu = new List<int>() { 4 };

            //Rangé8
            grille[7][0].Contenu = new List<int>() { 0 };
            grille[7][1].Contenu = new List<int>() { 8 };
            grille[7][2].Contenu = new List<int>() { 0 };

            grille[7][3].Contenu = new List<int>() { 0 };
            grille[7][4].Contenu = new List<int>() { 0 };
            grille[7][5].Contenu = new List<int>() { 0 };

            grille[7][6].Contenu = new List<int>() { 0 };
            grille[7][7].Contenu = new List<int>() { 0 };
            grille[7][8].Contenu = new List<int>() { 6 };

            //Rangé9
            grille[8][0].Contenu = new List<int>() { 6 };
            grille[8][1].Contenu = new List<int>() { 4 };
            grille[8][2].Contenu = new List<int>() { 3 };

            grille[8][3].Contenu = new List<int>() { 0 };
            grille[8][4].Contenu = new List<int>() { 0 };
            grille[8][5].Contenu = new List<int>() { 1 };

            grille[8][6].Contenu = new List<int>() { 0 };
            grille[8][7].Contenu = new List<int>() { 0 };
            grille[8][8].Contenu = new List<int>() { 8 };
            return grille;
        }
    }
}