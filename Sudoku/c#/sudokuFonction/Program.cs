using System;

namespace sudokuFonction
{
    public class Program
    {
        static void Main(string[] args)
        {
            AutoGenerateGrid grid= new AutoGenerateGrid();
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
            }
            Console.WriteLine(grid.grid.ToString());
            Console.WriteLine(valide + " nb essaie:" +essaie);
        }
    }
}