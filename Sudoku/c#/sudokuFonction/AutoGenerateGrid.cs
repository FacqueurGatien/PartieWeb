using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudokuFonction
{
    public class AutoGenerateGrid
    {
        public GridInit grid;
        public List<List<int>> rowClues;
        public int[] pattern;
        public int[] pattern2;
        public int[] pattern3;
        public int valide;

        public AutoGenerateGrid()
        {
            grid = new GridInit();
            pattern = new int[] { 1, 4,7,2,3};
            pattern2 = new int[] { 4, 7 };
            pattern3 = new int[] { 4,5,6,7,8,9 };
            valide = 0;
        }
        public bool GetRowClues(int numRow)
        {
            rowClues = new RowClueDispose(grid).SearchCluesRow(numRow);
            if (rowClues == null)
            {
                return false;
            }
            return true;
        }
        public string GetRowCluesString()
        {
            if (rowClues != null)
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
            return "null";
        }

        public bool Generate()
        {
            for (int i = 0; i < pattern.Length; i++)
            {
                if (GetRowClues(pattern[i]))
                {
                    if (grid.AddOneRow(pattern[i], rowClues))
                    {
                        valide++;
                    }
                }
                else
                {
                    return false;
                }
            }
            for (int i = 0; i < pattern2.Length; i++)
            {
                grid.EraseRange(pattern2[i]);
            }
            for (int i = 0; i < pattern3.Length; i++)
            {
                if (GetRowClues(pattern3[i]))
                {
                    if (grid.AddOneRow(pattern3[i], rowClues))
                    {
                        valide++;
                    }
                }
                else
                {
                    return false;
                }
            }

            if (valide==pattern.Length+pattern3.Length)
            {
                return true;
            }
            return false;
        }
        public bool Resolveur()
        {
            for (int i = 1; i < 9; i++)
            {
                if (GetRowClues(i))
                {
                    if (grid.AddOneRow(i, rowClues))
                    {
                        valide++;
                    }
                }
                else
                {
                    return false;
                }
            }

            if (valide == pattern.Length + pattern3.Length)
            {
                return true;
            }
            return false;
        }
    }
}
