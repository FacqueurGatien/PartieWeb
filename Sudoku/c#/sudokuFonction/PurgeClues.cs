using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudokuFonction
{
    public class PurgeClues
    {
        public List<List<List<int>>> cluesMachines;
        public List<List<List<List<List<int>>>>> grid;
        public PurgeClues(List<List<List<int>>> _cluesMachines)
        {
            cluesMachines = _cluesMachines;
            grid = new List<List<List<List<List<int>>>>>();
            GridCluesDisposeAuto();
        }

        /// <summary>
        /// initiation automatique du tableau
        /// </summary>
        public void GridCluesDisposeAuto()
        {
            int counterCol = 0;
            int counterRow = 0;

            for (int rb = 0; rb < 3; rb++)
            {
                grid.Add(new List<List<List<List<int>>>>());

                for (int r = 0; r < 3; r++)
                {
                    grid[rb].Add(new List<List<List<int>>>());

                    for (int cb = 0; cb < 3; cb++)
                    {
                        grid[rb][r].Add(new List<List<int>>());

                        for (int c = 0; c < 3; c++)
                        {
                            grid[rb][r][cb].Add(new List<int>());
                            grid[rb][r][cb][c].AddRange(cluesMachines[counterRow][counterCol]);
                            if (counterCol ==8)
                            {
                                counterCol = 0;
                                counterRow++;
                            }
                            else
                            {
                                counterCol++;
                            }
                        }
                    }
                }
            }
        }
        public override string ToString()
        {
            string temp = "";
            string res = "\n";
            for (int rb = 0; rb < 3; rb++)
            {
                for (int r = 0; r < 3; r++)
                {
                    res += "{";
                    for (int cb = 0; cb < 3; cb++)
                    {
                        res += "|";
                        for (int c = 0; c < 3; c++)
                        {
                            foreach (int item in grid[rb][r][cb][c])
                            {
                                temp+= item;
                            }
                            res+= string.Format("({0,-9})",temp);
                            temp = "";
                        }
                        res += "|";
                    }
                    res+= "}\n";
                    res+= "  ---------- ---------- ----------   ---------- ---------- ----------   ---------- ---------- -----------  \n";
                }
            }
            return res;
        }


        public void PurgeCluesRow(int[] coordCase)
        {
            throw new NotImplementedException();
        }
        public void purgeCluesCol(int[] coordCase)
        {
            throw new NotImplementedException();
        }
        public void purgeCluesBlock(int[] coordCase)
        {
            throw new NotImplementedException();
        }
    }
}
