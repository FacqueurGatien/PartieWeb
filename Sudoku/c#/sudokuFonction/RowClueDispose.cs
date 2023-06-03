using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudokuFonction
{
    public class RowClueDispose
    {
        public List<List<int>> rowClues;
        public GridInit grid;
        public int[] chiffre;
        public RowClueDispose()
        {
            chiffre = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            grid = new GridInit();
            //grid.AddFirstBlock();

            RowCluesInit();
        }
        public void RowCluesInit()
        {
            rowClues = new List<List<int>>();
            for (int i = 0; i < 9; i++)
            {
                rowClues.Add(new List<int>());
            }
        }
        public RowClueDispose(GridInit _grid)
        {
            chiffre = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            grid = _grid;
            //grid.AddFirstBlock();

            rowClues = new List<List<int>>();
            for (int i = 0; i < 9; i++)
            {
                rowClues.Add(new List<int>());
            }
        }
        public List<List<int>> SearchCluesRow(int numRow)
        {
            int[] row = grid.setCursor(numRow);
            int cursor = 0;
            for (int rb = row[0]; rb < row[0] + 1; rb++)
            {
                for (int r = row[1]; r < row[1] + 1; r++)
                {
                    for (int cb = 0; cb < 3; cb++)
                    {
                        for (int c = 0; c < 3; c++)
                        {
                            int[] coord = new int[] { rb, r, cb, c };
                            if (grid.grid[rb, r, cb, c] == 0)
                            {
                                int counter = 0;
                                foreach (int i in chiffre)
                                {
                                    if (grid.CheckCaseValide(coord, i))
                                    {
                                        rowClues[cursor].Add(i);
                                        counter++;
                                    }
                                }
                                if (counter==0)
                                {
                                    return null;
                                }
                            }
                            else
                            {
                                rowClues[cursor].Add(grid.grid[rb, r, cb, c]);
                            }
                            cursor++;
                        }
                    }
                }
            }
            RowSolver solver= new RowSolver(rowClues);
            solver.PurgeCheck();
            return rowClues;
        }
        public override string ToString()
        {
            string res = "";
            foreach (List<int> it in rowClues)
            {
                res += "(";
                foreach (int e in it)
                {
                    res += e;
                }
                res += ")";
            }
            return res;
        }
    }
}
