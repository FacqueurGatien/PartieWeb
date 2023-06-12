using System;

namespace sudokuFonction
{
    public class Program
    {
        static void Main(string[] args)
        {
            bool test = true;

            //1 Creation d'une instance de grid ()
            AutoGenerateGrid grid = new AutoGenerateGrid();
            grid.grid.DisposingArray4();
            Console.WriteLine(grid.grid.ToString());
            RowClueDispose clues = new RowClueDispose(grid.grid);

            List<List<List<int>>> tab = clues.SearchCluesRow();
            Console.WriteLine(clues.ToStringMultiple());

            PurgeClues resolve = new PurgeClues(tab);
            Console.WriteLine(resolve.ToString());
            Console.WriteLine("\n\n\n___________________________________________________________\n");

            if (resolve.ItterationTotal()<300)
            {
                if (resolve.ResolveGrid())
                {
                    Console.WriteLine(resolve.ToString());
                    Console.WriteLine("Solution trouvé");
                    test = false;
                }
                else
                {
                    resolve = new PurgeClues(tab);
                    resolve.ResolveGrid(false);
                    Console.WriteLine(resolve.ToString());
                    Console.WriteLine("Pas de solution trouvé");
                    resolve.ItterationCount();
                    Console.WriteLine(resolve.itteration);
                }
            }


            //Verification de la copy des Ligne
            /*            resolve.CopyRowClues(new int[] {0,2});
                        Console.WriteLine(resolve.ToStringArray());
                        resolve.CopyColumnClues(new int[] { 1, 0 });
                        Console.WriteLine("\n" + "\n" + resolve.ToStringArray());
                        resolve.CopyBlockClues(new int[] {0,1});
                        Console.WriteLine("\n" + "\n" + resolve.ToStringArray());
            */



            //Faire une fonction qui traduit la resolution de la cluesMachines en grid de la classe grid
            // pour pouvoir la resoudre aleatoirement


            if (test)
            {
                int valide = 0;
                int essaie = 0;
                while (true)
                {
                    essaie++;
                    grid = new AutoGenerateGrid();
                    if (grid.Generate())
                    {
                        valide++;
                        break;
                    }
                    Console.WriteLine(grid.grid.ToString());
                }
                Console.WriteLine(grid.grid.ToString());
                Console.WriteLine(valide + " nb essaie:" + essaie);
            }



        }
    }
}