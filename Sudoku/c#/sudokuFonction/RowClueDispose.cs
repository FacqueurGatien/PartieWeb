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
        public List<List<List<int>>> rowCluesMultiple;
        public GridInit grid;
        public int[] chiffre;
        public RowClueDispose()
        {
            chiffre = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            grid = new GridInit();
        }
        public RowClueDispose(GridInit _grid)
        {
            chiffre = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            grid = _grid;
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
        public string ToString9()
        {
            string res = "";
            foreach (List<List<int>> itt in rowCluesMultiple)
            {
                res += "{";
                foreach (List<int> it in itt)
                {
                    res += "[";
                    string temp = "";
                    foreach (int e in it)
                    {
                        temp += e;
                    }
                    res += string.Format("{0,-9}]", temp);
                }
                res += "}\n";
            }
            return res;
        }


        /// <summary>
        /// Permet d'initialisé une list de 9 listes vide
        /// </summary>
        public void RowCluesInit()
        {
            rowClues = new List<List<int>>();
            for (int i = 0; i < 9; i++)
            {
                rowClues.Add(new List<int>());
            }
        }
        /// <summary>
        /// Permet de chercher les indice de chaque case d'une rangé
        /// </summary>
        /// <param name="numRow">numero de la rangé a parcourir a la recherche d'indice</param>
        /// <returns>Une liste de 9 listes d'indice</returns>
        public List<List<int>> SearchCluesRow(int numRow)
        {
            RowCluesInit();
            int[] row = grid.setLine(numRow);
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
                                if (counter == 0)
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
            RowSolver solver = new RowSolver(rowClues);
            solver.PurgeCheck();
            return rowClues;
        }



        /// <summary>
        /// Permet d'initialisé une 3 listes de 9 listes vide
        /// </summary>
        public void RowCluesInit3()
        {
            rowCluesMultiple = new List<List<List<int>>>();
            for (int i = 0; i < 3; i++)
            {
                rowCluesMultiple.Add(new List<List<int>>());
                for (int j = 0; j < 9; j++)
                {
                    rowCluesMultiple[i].Add(new List<int>());
                }
            }
        }
        /// <summary>
        /// Permet de chercher les indice de chaque case d'une rangé
        /// </summary>
        /// <param name="numRow">numero de la rangé a parcourir a la recherche d'indice</param>
        /// <returns>Une liste de 9 listes d'indice</returns>
        public List<List<List<int>>> SearchCluesRow3(int _numRow)
        {
            int numRow = 0;
            if (_numRow <= 3)
            {
                numRow = 1;
            }
            else if (_numRow <= 6)
            {
                numRow = 4;
            }
            else
            {
                numRow = 7;
            }
            RowCluesInit3();
            for (int i = 0; i < 3; i++)
            {
                RowCluesInit();
                int[] row = grid.setLine(numRow++);
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
                                    foreach (int j in chiffre)
                                    {
                                        if (grid.CheckCaseValide(coord, j))
                                        {
                                            rowClues[cursor].Add(j);
                                            counter++;
                                        }
                                    }
                                    if (counter == 0)
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
                rowCluesMultiple[i] = rowClues;
            }
            RowSolver solver = new RowSolver(rowClues);
            solver.PurgeCheck();
            return rowCluesMultiple;
        }



        /// <summary>
        /// Permet d'initialisé une 9 listes de 9 listes vide
        /// </summary>
        public void RowCluesInit9()
        {
            rowCluesMultiple = new List<List<List<int>>>();
            for (int i = 0; i < 9; i++)
            {
                rowCluesMultiple.Add(new List<List<int>>());
                for (int j = 0; j < 9; j++)
                {
                    rowCluesMultiple[i].Add(new List<int>());
                }
            }
        }
        /// <summary>
        /// Permet de chercher les indice de chaque case d'une rangé
        /// </summary>
        /// <param name="numRow">numero de la rangé a parcourir a la recherche d'indice</param>
        /// <returns>Une liste de 9 listes d'indice</returns>
        public List<List<List<int>>> SearchCluesRow9()
        {
            RowCluesInit9();
            int numRow = 1;
            for (int i = 0; i < 9; i++)
            {
                RowCluesInit();
                int[] row = grid.setLine(numRow++);
                int cursor = 0;
                RowCluesInit();
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
                                    foreach (int j in chiffre)
                                    {
                                        if (grid.CheckCaseValide(coord, j))
                                        {
                                            rowClues[cursor].Add(j);
                                            counter++;
                                        }
                                    }
                                    if (counter == 0)
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
                    rowCluesMultiple[i] = rowClues;
                }
            }
            RowSolver solver = new RowSolver(rowClues);
            solver.PurgeCheck();
            return rowCluesMultiple;
        }

    }
}
