using System;

namespace sudokuFonction
{
    public class Program
    {
        static void Main(string[] args)
        {
            AutoGenerateGrid grid= new AutoGenerateGrid();

            RowClueDispose clues = new RowClueDispose(grid.grid);

            List<List<List<int>>> tab =clues.SearchCluesRow9();
            Console.WriteLine(clues.ToString9());

            PurgeClues resolve = new PurgeClues(tab);
            Console.WriteLine(resolve.ToString());


/*            int valide = 0;
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
            }
            Console.WriteLine(grid.grid.ToString());
            Console.WriteLine(valide + " nb essaie:" +essaie);*/
        }
    }
}