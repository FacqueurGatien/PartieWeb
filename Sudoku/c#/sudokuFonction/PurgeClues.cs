using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudokuFonction
{
    public class PurgeClues
    {
        public List<List<List<int>>> cluesMachines;
        public List<List<List<List<List<int>>>>> grid;
        public List<List<int>> array;
        public Dictionary<int, int> itteration;
        public int essaieMinResolve;


        public int resolveAction;
        public bool purgeAction;
        public PurgeClues(List<List<List<int>>> _cluesMachines)
        {
            cluesMachines = _cluesMachines;
            grid = new List<List<List<List<List<int>>>>>();
            GridCluesDisposeAuto();

            array = new List<List<int>>();
            itteration = new Dictionary<int, int>();

            resolveAction = 0;
            purgeAction = true;

            essaieMinResolve = 0;
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
                            if (counterCol == 8)
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
        }//OK
        public override string ToString()
        {
            string temp = "";
            string res = "  ---------- ---------- ----------   ---------- ---------- ----------   ---------- ---------- -----------  \n";
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
                                temp += item;
                            }
                            res += string.Format("({0,-9})", temp);
                            temp = "";
                        }
                        res += "|";
                    }
                    res += "}\n";
                    res += "  ---------- ---------- ----------   ---------- ---------- ----------   ---------- ---------- -----------  \n";
                }
            }
            return res;
        }//OK
        public string ToStringArray()
        {
            string res = "";
            foreach (List<int> it in array)
            {
                res += "[";
                string temp = "";
                foreach (int i in it)
                {
                    temp += i;
                }

                res += string.Format("{0,-9}]", temp);
            }
            res.Trim(' ');
            return res;
        }//OK

        public void ItterationInit()
        {
            itteration = new Dictionary<int, int>
            {
                { 1, 0 },
                { 2, 0 },
                { 3, 0 },
                { 4, 0 },
                { 5, 0 },
                { 6, 0 },
                { 7, 0 },
                { 8, 0 },
                { 9, 0 }
            };
        }

        public void PurgeCluesRow(int[] coordCase, bool itterationMode, int _num = 0)//a travailler
        {
            if (!itterationMode)
            {
                int num = 0;
                if (_num == 0)
                {
                    num = grid[coordCase[0]][coordCase[1]][coordCase[2]][coordCase[3]][0];
                }
                else
                {
                    num = _num;
                }

                for (int rb = coordCase[0]; rb < coordCase[0] + 1; rb++)
                {
                    for (int r = coordCase[1]; r < coordCase[1] + 1; r++)
                    {
                        for (int cb = 0; cb < 3; cb++)
                        {
                            for (int c = 0; c < 3; c++)
                            {
                                if (!(rb == coordCase[0] &&
                                    r == coordCase[1] &&
                                    cb == coordCase[2] &&
                                    c == coordCase[3]))
                                {
                                    EraseClues(new int[] { rb, r, cb, c }, num);
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                List<List<List<int>>> list = new List<List<List<int>>>();
                for (int rb = coordCase[0]; rb < coordCase[0] + 1; rb++)
                {
                    for (int r = coordCase[1]; r < coordCase[1] + 1; r++)
                    {
                        for (int cb = 0; cb < 3; cb++)
                        {
                            list.Add(new List<List<int>>());
                            for (int c = 0; c < 3; c++)
                            {
                                list[cb].Add(new List<int>());
                                foreach (int i in grid[rb][r][cb][c])
                                {
                                    list[cb][c].Add(i);
                                }
                            }
                        }
                    }
                }
                ItterationCount(list);
                for (int a = 0; a < 3; a++)
                {
                    for (int b = 0; b < 3; b++)
                    {
                        foreach (int i in list[a][b])
                        {
                            if (list[a][b].Count > 1 && itteration[i] == 1)
                            {
                                ReplaceCluesRow(coordCase, i);
                            }
                        }
                    }
                }
            }
        }
        public void ReplaceCluesRow(int[] coordCase, int num)
        {
            for (int rb = coordCase[0]; rb < coordCase[0] + 1; rb++)
            {
                for (int r = coordCase[1]; r < coordCase[1] + 1; r++)
                {
                    for (int cb = 0; cb < 3; cb++)
                    {
                        for (int c = 0; c < 3; c++)
                        {
                            if (grid[rb][r][cb][c].Contains(num))
                            {
                                grid[rb][r][cb][c].Clear();
                                grid[rb][r][cb][c].Add(num);
                            }
                        }
                    }
                }
            }
        }
        public void purgeCluesCol(int[] coordCase, bool itterationMode, int _num = 0)//a travailler
        {
            if (!itterationMode)
            {
                int num = 0;
                if (_num == 0)
                {
                    num = grid[coordCase[0]][coordCase[1]][coordCase[2]][coordCase[3]][0];
                }
                else
                {
                    num = _num;
                }
                for (int rb = 0; rb < 3; rb++)
                {
                    for (int r = 0; r < 3; r++)
                    {
                        for (int cb = coordCase[2]; cb < coordCase[2] + 1; cb++)
                        {
                            for (int c = coordCase[3]; c < coordCase[3] + 1; c++)
                            {
                                if (!(rb == coordCase[0] &&
                                    r == coordCase[1] &&
                                    cb == coordCase[2] &&
                                    c == coordCase[3]))
                                {
                                    EraseClues(new int[] { rb, r, cb, c }, num);
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                List<List<List<int>>> list = new List<List<List<int>>>();
                for (int rb = 0; rb < 3; rb++)
                {
                    list.Add(new List<List<int>>());
                    for (int r = 0; r < 3; r++)
                    {
                        list[rb].Add(new List<int>());
                        for (int cb = coordCase[2]; cb < coordCase[2] + 1; cb++)
                        {

                            for (int c = coordCase[3]; c < coordCase[3] + 1; c++)
                            {

                                foreach (int i in grid[rb][r][cb][c])
                                {
                                    list[rb][r].Add(i);
                                }
                            }
                        }
                    }
                }
                ItterationCount(list);
                for (int a = 0; a < 3; a++)
                {
                    for (int b = 0; b < 3; b++)
                    {
                        foreach (int i in list[a][b])
                        {
                            if (list[a][b].Count > 1 && itteration[i] == 1)
                            {
                                ReplaceCluesCol(coordCase, i);
                            }
                        }
                    }
                }
            }
        }
        public void ReplaceCluesCol(int[] coordCase, int num)
        {
            for (int rb = 0; rb < 3; rb++)
            {
                for (int r = 0; r < 3; r++)
                {
                    for (int cb = coordCase[2]; cb < coordCase[2] + 1; cb++)
                    {
                        for (int c = coordCase[3]; c < coordCase[3] + 1; c++)
                        {
                            if (grid[rb][r][cb][c].Contains(num))
                            {
                                grid[rb][r][cb][c].Clear();
                                grid[rb][r][cb][c].Add(num);
                            }
                        }
                    }
                }
            }
        }
        public void purgeCluesBlock(int[] coordCase, bool itterationMode, int _num = 0)//a travailler
        {
            if (!itterationMode)
            {
                int num = 0;
                if (_num == 0)
                {
                    num = grid[coordCase[0]][coordCase[1]][coordCase[2]][coordCase[3]][0];
                }
                else
                {
                    num = _num;
                }
                for (int rb = coordCase[0]; rb < coordCase[0] + 1; rb++)
                {
                    for (int r = 0; r < 3; r++)
                    {
                        for (int cb = coordCase[2]; cb < coordCase[2] + 1; cb++)
                        {
                            for (int c = 0; c < 3; c++)
                            {
                                if (!(rb == coordCase[0] &&
                                    r == coordCase[1] &&
                                    cb == coordCase[2] &&
                                    c == coordCase[3]))
                                {
                                    EraseClues(new int[] { rb, r, cb, c }, num);
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                List<List<List<int>>> list = new List<List<List<int>>>();
                for (int rb = coordCase[0]; rb < coordCase[0] + 1; rb++)
                {
                    for (int r = 0; r < 3; r++)
                    {
                        list.Add(new List<List<int>>());
                        for (int cb = coordCase[2]; cb < coordCase[2] + 1; cb++)
                        {
                            for (int c = 0; c < 3; c++)
                            {
                                list[r].Add(new List<int>());
                                foreach (int i in grid[rb][r][cb][c])
                                {
                                    list[r][c].Add(i);
                                }
                            }
                        }
                    }
                }
                ItterationCount(list);
                for (int a = 0; a < 3; a++)
                {
                    for (int b = 0; b < 3; b++)
                    {
                        foreach (int i in list[a][b])
                        {
                            if (list[a][b].Count > 1 && itteration[i] == 1)
                            {
                                ReplaceCluesBlock(coordCase, i);
                            }
                        }
                    }
                }
            }
        }
        public void ReplaceCluesBlock(int[] coordCase, int num)
        {
            for (int rb = coordCase[0]; rb < coordCase[0] + 1; rb++)
            {
                for (int r = 0; r < 3; r++)
                {
                    for (int cb = coordCase[2]; cb < coordCase[2] + 1; cb++)
                    {
                        for (int c = 0; c < 3; c++)
                        {
                            if (grid[rb][r][cb][c].Contains(num))
                            {
                                grid[rb][r][cb][c].Clear();
                                grid[rb][r][cb][c].Add(num);
                            }
                        }
                    }
                }
            }
        }

        public void EraseClues(int[] coord, int num)
        {
            int before = grid[coord[0]][coord[1]][coord[2]][coord[3]].Count;
            grid[coord[0]][coord[1]][coord[2]][coord[3]].Remove(num);
            if (before != grid[coord[0]][coord[1]][coord[2]][coord[3]].Count)
            {
                purgeAction = true;
            }

        }


        public void Reset()
        {
            itteration[1] = 0;
            itteration[2] = 0;
            itteration[3] = 0;
            itteration[4] = 0;
            itteration[5] = 0;
            itteration[6] = 0;
            itteration[7] = 0;
            itteration[8] = 0;
            itteration[9] = 0;

            array = new List<List<int>>();
        }//a travailler

        public void PurgeCheck()
        {



        }//a travailler
        public void PurgeArray(bool itterationMode)//a travailler
        {
            purgeAction = false;
            for (int rb = 0; rb < 3; rb++)
            {
                for (int r = 0; r < 3; r++)
                {
                    for (int cb = 0; cb < 3; cb++)
                    {
                        for (int c = 0; c < 3; c++)
                        {
                            if (!itterationMode)
                            {
                                if (grid[rb][r][cb][c].Count == 1)
                                {
                                    PurgeCaseOneDigit(new int[] { rb, r, cb, c }, itterationMode);
                                }
                            }
                            else
                            {
                                if (grid[rb][r][cb][c].Count > 1)
                                {
                                    PurgeCaseOneDigit(new int[] { rb, r, cb, c }, itterationMode);
                                }
                            }
                        }
                    }
                }
            }

        }
        public void PurgeCaseOneDigit(int[] coord, bool itterationMode, int num = 0)
        {
            PurgeCluesRow(coord, itterationMode, num);
            purgeCluesCol(coord, itterationMode, num);
            purgeCluesBlock(coord, itterationMode, num);
        }

        public void ItterationCount(List<List<List<int>>> array)
        {
            ItterationInit();
            foreach (List<List<int>> itt in array)
            {
                foreach (List<int> it in itt)
                {
                    foreach (int i in it)
                    {
                        itteration[i]++;
                    }

                }
            }
        }
        public void ItterationCount()
        {
            for (int rb = 0; rb < 3; rb++)
            {
                for (int r = 0; r < 3; r++)
                {
                    for (int cb = 0; cb < 3; cb++)
                    {
                        for (int c = 0; c < 3; c++)
                        {
                            foreach (int i in grid[rb][r][cb][c])
                            {
                                itteration[i]++;
                            }
                        }
                    }
                }
            }
        }
        public int CheckGridComplete()
        {
            int count = 0;
            for (int rb = 0; rb < 3; rb++)
            {
                for (int r = 0; r < 3; r++)
                {
                    for (int cb = 0; cb < 3; cb++)
                    {
                        for (int c = 0; c < 3; c++)
                        {
                            if (grid[rb][r][cb][c].Count == 1)
                            {
                                count++;
                            }
                        }
                    }
                }
            }

            return count;
        }
        public bool CheckAllItteration()
        {
            return CheckGridComplete() == 81;
        }//a travailler

        public int[] setLine(int cursor)
        {
            switch (cursor)
            {
                case 1:
                    return new int[] { 0, 0 };
                case 2:
                    return new int[] { 0, 1 };
                case 3:
                    return new int[] { 0, 2 };
                case 4:
                    return new int[] { 1, 0 };
                case 5:
                    return new int[] { 1, 1 };
                case 6:
                    return new int[] { 1, 2 };
                case 7:
                    return new int[] { 2, 0 };
                case 8:
                    return new int[] { 2, 1 };
                case 9:
                    return new int[] { 2, 2 };
                default:
                    return null;
            }
        }//a travailler
        /// <summary>
        /// permet de recuperer le numero d'une ligne colonne ou block a partir de Coordonné
        /// </summary>
        /// <param name="coord">Coordonne de la ligne colonne ou block</param>
        /// <returns>Renvoie le numero de ligne/block/colonne</returns>
        public int setCursor(int[] coord)
        {
            if (coord[0] == 0 && coord[1] == 0)
            {
                return 1;
            }
            else if (coord[0] == 0 && coord[1] == 1)
            {
                return 2;
            }
            else if (coord[0] == 0 && coord[1] == 2)
            {
                return 3;
            }
            else if (coord[0] == 1 && coord[1] == 0)
            {
                return 4;
            }
            else if (coord[0] == 1 && coord[1] == 1)
            {
                return 5;
            }
            else if (coord[0] == 1 && coord[1] == 2)
            {
                return 6;
            }
            else if (coord[0] == 2 && coord[1] == 0)
            {
                return 7;
            }
            else if (coord[0] == 2 && coord[1] == 1)
            {
                return 8;
            }
            else if (coord[0] == 2 && coord[1] == 2)
            {
                return 9;
            }
            else
            {
                return 0;
            }
        }//a travailler



        /// <summary>
        /// Permet de copier une rangé a partir de ses coordonnées 
        /// </summary>
        /// <param name="numRow"></param>
        /// <returns>Renvoie un tableau avec le contenue de la rangé</returns>
        public void CopyRowClues(int[] coordRow)//OK
        {
            array = new List<List<int>>();
            for (int rb = coordRow[0]; rb < coordRow[0] + 1; rb++)
            {

                for (int r = coordRow[1]; r < coordRow[1] + 1; r++)
                {

                    for (int cb = 0; cb < 3; cb++)
                    {

                        for (int c = 0; c < 3; c++)
                        {
                            array.Add(grid[rb][r][cb][c]);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Permet de copier une colonne a partir de ses coordonnées 
        /// </summary>
        /// <param name="numCol"></param>
        /// <returns>Renvoie un tableau avec le contenue de la colonne</returns>
        public void CopyColumnClues(int[] coordCol)
        {
            array = new List<List<int>>();
            for (int rb = 0; rb < 3; rb++)
            {

                for (int r = 0; r < 3; r++)
                {

                    for (int cb = coordCol[0]; cb < coordCol[0] + 1; cb++)
                    {

                        for (int c = coordCol[1]; c < coordCol[1] + 1; c++)
                        {
                            array.Add(grid[rb][r][cb][c]);
                        }
                    }
                }
            }
        }//OK

        /// <summary>
        /// Permet de copier un block a partir de ses coordonnées 
        /// </summary>
        /// <param name="numBlock"></param>
        /// <returns>Renvoie un tableau avec le contenue du block</returns>
        public void CopyBlockClues(int[] cordBlock)
        {
            array = new List<List<int>>();
            for (int rb = cordBlock[0]; rb < cordBlock[0] + 1; rb++)
            {

                for (int r = 0; r < 3; r++)
                {

                    for (int cb = cordBlock[1]; cb < cordBlock[1] + 1; cb++)
                    {

                        for (int c = 0; c < 3; c++)
                        {
                            array.Add(grid[rb][r][cb][c]);
                        }
                    }
                }
            }
        }//OK

        public void ItterationMinResolve(int essaie)
        {

            ItterationInit();
            ItterationCount();//Sans paramettre toute la grille sera compté

            List<int> array = new List<int>();
            foreach (KeyValuePair<int, int> i in itteration.OrderBy(key => key.Value))
            {
                if (i.Value != 9)
                {
                    array.Add(i.Key);
                }

            }

            List<int[]> index = new List<int[]>();
            for (int rb = 0; rb < 3; rb++)
            {
                for (int r = 0; r < 3; r++)
                {
                    for (int cb = 0; cb < 3; cb++)
                    {
                        for (int c = 0; c < 3; c++)
                        {
                            if (grid[rb][r][cb][c].Count > 1)
                            {
                                if (grid[rb][r][cb][c].Contains(array[essaie]))
                                {
                                    index.Add(new int[] { rb, r, cb, c });
                                }
                            }
                        }
                    }
                }
            }
            int counter = 0;
            while (counter < index.Count && essaie<8)
            {
                grid = new List<List<List<List<List<int>>>>>();
                GridCluesDisposeAuto();

                grid[index[counter][0]][index[counter][1]][index[counter][2]][index[counter][3]].Clear();
                grid[index[counter][0]][index[counter][1]][index[counter][2]][index[counter][3]].Add(array[essaie]);

                resolveAction = 0;
                Console.WriteLine(ToString);
                resolveAction = 10;
                if (ResolveGrid(false))
                {
                    counter = index.Count + 1;

                }
                else
                {
                    resolveAction = 0;
                    essaie++;
                }
            }

            counter++;
            resolveAction = 10;
            if (!ResolveGrid(false))
            {
                grid = new List<List<List<List<List<int>>>>>();
                GridCluesDisposeAuto();
                ResolveGrid(false);
            }
        }

        public bool ResolveGrid(bool minResolveMode = true)//a travailler
        {
            while (!CheckAllItteration() && resolveAction < 11 && essaieMinResolve < 5)
            {
                purgeAction = true;
                while (purgeAction)
                {
                    PurgeArray(itterationMode: false);
                }
                PurgeArray(itterationMode: true);
                resolveAction++;
                if (resolveAction >= 10 && minResolveMode)
                {
                    essaieMinResolve++;
                    ItterationMinResolve(essaieMinResolve);
                }
                Console.WriteLine(ToString());
            }
            if (CheckAllItteration())
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }


}
