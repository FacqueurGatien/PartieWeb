using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace sudokuFonction
{
    public enum EnumLine
    {
        Row,
        Column,
        Block
    }
    public class GridInit
    {
        public int[,,,] grid;
        public int essaie;

        public GridInit()
        {
            grid = new int[3, 3, 3, 3];
            DisposingArrayZero();
            essaie= 0;
        }
        public void DisposingZero()
        {
            string res = "";
            int compteur = 0;
            for (int rb = 0; rb < 3; rb++)
            {
                res += "\n _________  _________  _________\n";
                for (int cb = 0; cb < 3; cb++)
                {
                    res += "\n _________  _________  _________\n";
                    for (int r = 0; r < 3; r++)
                    {
                        res += "| ";
                        for (int c = 0; c < 3; c++)
                        {
                            //compteur++;
                            res += string.Format("{0,-2}|", compteur.ToString());
                        }
                    }
                }
            }
            Console.WriteLine(res);
        }
        public override string ToString()
        {
            string res = "";
            for (int rb = 0; rb < 3; rb++)
            {
                if (rb != 0)
                {
                    res += "\n _________  _________  _________\n";
                }
                for (int r = 0; r < 3; r++)
                {
                    res += "\n _________  _________  _________\n";
                    for (int cb = 0; cb < 3; cb++)
                    {
                        res += "| ";
                        for (int c = 0; c < 3; c++)
                        {
                            res += string.Format("{0,-2}|", grid[rb, r, cb, c]);
                        }
                    }
                }
            }
            res += "\n _________  _________  _________\n";
            return res;
        }

        public int[] setCursor(int cursor)
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
        }
        public int[] CopyRow(int numRow)
        {
            int[] rowCursor = setCursor(numRow);
            int[] row = new int[9];
            int compteur = 0;
            for (int rb = rowCursor[0]; rb < rowCursor[0] + 1; rb++)
            {
                for (int r = rowCursor[1]; r < rowCursor[1] + 1; r++)
                {
                    for (int cb = 0; cb < 3; cb++)
                    {
                        for (int c = 0; c < 3; c++)
                        {
                            row[compteur++] = grid[rb, r, cb, c];
                        }
                    }
                }
            }
            return row;
        }
        public int[] CopyColumn(int numCol)
        {
            int[] columnCursor = setCursor(numCol);
            int[] column = new int[9];
            int compteur = 0;
            for (int rb = 0; rb < 3; rb++)
            {
                for (int r = 0; r < 3; r++)
                {
                    for (int cb = columnCursor[0]; cb < columnCursor[0] + 1; cb++)
                    {
                        for (int c = columnCursor[1]; c < columnCursor[1] + 1; c++)
                        {
                            column[compteur++] = grid[rb, r, cb, c];
                        }
                    }
                }
            }
            return column;
        }
        public int[] CopyBlock(int numBlock)
        {
            int[] blockCursor = setCursor(numBlock);
            int[] column = new int[9];
            int compteur = 0;
            for (int rb = blockCursor[0]; rb < blockCursor[0] + 1; rb++)
            {
                for (int r = 0; r < 3; r++)
                {
                    for (int cb = blockCursor[1]; cb < blockCursor[1] + 1; cb++)
                    {
                        for (int c = 0; c < 3; c++)
                        {
                            column[compteur++] = grid[rb, r, cb, c];
                        }
                    }
                }
            }
            return column;
        }

        public int setCase(int[] coord)
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
            else
            {
                return 9;
            }
        }
        public int[] CopyRow(int[] numRow)
        {
            int rowCase = setCase(numRow);
            int[] rowCursor = setCursor(rowCase);
            int[] row = new int[9];
            int compteur = 0;
            for (int rb = rowCursor[0]; rb < rowCursor[0] + 1; rb++)
            {
                for (int r = rowCursor[1]; r < rowCursor[1] + 1; r++)
                {
                    for (int cb = 0; cb < 3; cb++)
                    {
                        for (int c = 0; c < 3; c++)
                        {
                            row[compteur++] = grid[rb, r, cb, c];
                        }
                    }
                }
            }
            return row;
        }
        public int[] CopyColumn(int[] numCol)
        {
            int columnCase = setCase(numCol);
            int[] columnCursor = setCursor(columnCase);
            int[] column = new int[9];
            int compteur = 0;
            for (int rb = 0; rb < 3; rb++)
            {
                for (int r = 0; r < 3; r++)
                {
                    for (int cb = columnCursor[0]; cb < columnCursor[0] + 1; cb++)
                    {
                        for (int c = columnCursor[1]; c < columnCursor[1] + 1; c++)
                        {
                            column[compteur++] = grid[rb, r, cb, c];
                        }
                    }
                }
            }
            return column;
        }
        public int[] CopyBlock(int[] numBlock)
        {
            int blockCase = setCase(numBlock);
            int[] blockCursor = setCursor(blockCase);
            int[] column = new int[9];
            int compteur = 0;
            for (int rb = blockCursor[0]; rb < blockCursor[0] + 1; rb++)
            {
                for (int r = 0; r < 3; r++)
                {
                    for (int cb = blockCursor[1]; cb < blockCursor[1] + 1; cb++)
                    {
                        for (int c = 0; c < 3; c++)
                        {
                            column[compteur++] = grid[rb, r, cb, c];
                        }
                    }
                }
            }
            return column;
        }

        public bool CheckLineValide(int num, EnumLine typeLine)
        {
            int[] line = new int[9];
            if (typeLine == EnumLine.Row)
            {
                line = CopyRow(num);
            }
            else if (typeLine == EnumLine.Column)
            {
                line = CopyColumn(num);
            }
            else
            {
                line = CopyBlock(num);
            }

            for (int i = 1; i < 10; i++)
            {
                int counter = 0;
                foreach (int item in line)
                {
                    if (i == item)
                    {
                        counter++;
                        if (counter > 1)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        public bool CheckLineComplete(int num, EnumLine typeLine)
        {
            int[] line = new int[9];
            if (typeLine == EnumLine.Row)
            {
                line = CopyRow(num);
            }
            else if (typeLine == EnumLine.Column)
            {
                line = CopyColumn(num);
            }
            else
            {
                line = CopyBlock(num);
            }
            int counter = 0;
            foreach (int item in line)
            {
                if (item != 0)
                {
                    counter++;
                }
            }
            if (counter != 9)
            {
                return false;
            }
            return true;
        }
        public bool CheckCaseValide(int[] coord, int chiffre)
        {
            int[] row = CopyRow(new int[] { coord[0], coord[1] });
            int[] col = CopyColumn(new int[] { coord[2], coord[3] });
            int[] block = CopyBlock(new int[] { coord[0], coord[2] });

            if (row.Contains(chiffre) || col.Contains(chiffre) || block.Contains(chiffre))
            {
                return false;
            }
            return true;
        }
        public bool AddChiffre(int[] coord, int chiffre)
        {
            if (CheckCaseValide(coord, chiffre))
            {
                grid[coord[0], coord[1], coord[2], coord[3]] = chiffre;
                return true;
            }
            else if(grid[coord[0], coord[1], coord[2], coord[3]]!=0)
            {
                return true;
            }
            return false;

        }
        public void DisposingArray()
        {  //    rb r cb  c

            //Rangé 1
            grid[0, 0, 0, 0] = 1;
            grid[0, 0, 0, 1] = 0;
            grid[0, 0, 0, 2] = 0;

            grid[0, 0, 1, 0] = 0;
            grid[0, 0, 1, 1] = 0;
            grid[0, 0, 1, 2] = 0;

            grid[0, 0, 2, 0] = 0;
            grid[0, 0, 2, 1] = 0;
            grid[0, 0, 2, 2] = 7;

            //Rangé2
            grid[0, 1, 0, 0] = 0;
            grid[0, 1, 0, 1] = 9;
            grid[0, 1, 0, 2] = 0;

            grid[0, 1, 1, 0] = 0;
            grid[0, 1, 1, 1] = 0;
            grid[0, 1, 1, 2] = 0;

            grid[0, 1, 2, 0] = 0;
            grid[0, 1, 2, 1] = 2;
            grid[0, 1, 2, 2] = 0;

            //Rangé3
            grid[0, 2, 0, 0] = 4;
            grid[0, 2, 0, 1] = 0;
            grid[0, 2, 0, 2] = 0;

            grid[0, 2, 1, 0] = 9;
            grid[0, 2, 1, 1] = 0;
            grid[0, 2, 1, 2] = 1;

            grid[0, 2, 2, 0] = 8;
            grid[0, 2, 2, 1] = 0;
            grid[0, 2, 2, 2] = 0;

            //Rangé 4
            grid[1, 0, 0, 0] = 0;
            grid[1, 0, 0, 1] = 0;
            grid[1, 0, 0, 2] = 0;

            grid[1, 0, 1, 0] = 0;
            grid[1, 0, 1, 1] = 0;
            grid[1, 0, 1, 2] = 0;

            grid[1, 0, 2, 0] = 0;
            grid[1, 0, 2, 1] = 0;
            grid[1, 0, 2, 2] = 0;

            //Rangé5
            grid[1, 1, 0, 0] = 5;
            grid[1, 1, 0, 1] = 0;
            grid[1, 1, 0, 2] = 0;

            grid[1, 1, 1, 0] = 0;
            grid[1, 1, 1, 1] = 0;
            grid[1, 1, 1, 2] = 2;

            grid[1, 1, 2, 0] = 0;
            grid[1, 1, 2, 1] = 9;
            grid[1, 1, 2, 2] = 8;

            //Rangé6
            grid[1, 2, 0, 0] = 0;
            grid[1, 2, 0, 1] = 0;
            grid[1, 2, 0, 2] = 2;

            grid[1, 2, 1, 0] = 1;
            grid[1, 2, 1, 1] = 0;
            grid[1, 2, 1, 2] = 0;

            grid[1, 2, 2, 0] = 6;
            grid[1, 2, 2, 1] = 0;
            grid[1, 2, 2, 2] = 0;

            //Rangé 7
            grid[2, 0, 0, 0] = 0;
            grid[2, 0, 0, 1] = 0;
            grid[2, 0, 0, 2] = 0;

            grid[2, 0, 1, 0] = 0;
            grid[2, 0, 1, 1] = 0;
            grid[2, 0, 1, 2] = 0;

            grid[2, 0, 2, 0] = 0;
            grid[2, 0, 2, 1] = 6;
            grid[2, 0, 2, 2] = 0;

            //Rangé8
            grid[2, 1, 0, 0] = 0;
            grid[2, 1, 0, 1] = 3;
            grid[2, 1, 0, 2] = 4;

            grid[2, 1, 1, 0] = 0;
            grid[2, 1, 1, 1] = 0;
            grid[2, 1, 1, 2] = 7;

            grid[2, 1, 2, 0] = 0;
            grid[2, 1, 2, 1] = 5;
            grid[2, 1, 2, 2] = 1;

            //Rangé9
            grid[2, 2, 0, 0] = 0;
            grid[2, 2, 0, 1] = 7;
            grid[2, 2, 0, 2] = 0;

            grid[2, 2, 1, 0] = 6;
            grid[2, 2, 1, 1] = 5;
            grid[2, 2, 1, 2] = 0;

            grid[2, 2, 2, 0] = 4;
            grid[2, 2, 2, 1] = 0;
            grid[2, 2, 2, 2] = 0;
        }
        public void DisposingArrayZero()
        {  //    rb r cb  c

            //Rangé 1
            grid[0, 0, 0, 0] = 0;
            grid[0, 0, 0, 1] = 0;
            grid[0, 0, 0, 2] = 0;

            grid[0, 0, 1, 0] = 0;
            grid[0, 0, 1, 1] = 0;
            grid[0, 0, 1, 2] = 0;

            grid[0, 0, 2, 0] = 0;
            grid[0, 0, 2, 1] = 0;
            grid[0, 0, 2, 2] = 0;

            //Rangé2
            grid[0, 1, 0, 0] = 0;
            grid[0, 1, 0, 1] = 0;
            grid[0, 1, 0, 2] = 0;

            grid[0, 1, 1, 0] = 0;
            grid[0, 1, 1, 1] = 0;
            grid[0, 1, 1, 2] = 0;

            grid[0, 1, 2, 0] = 0;
            grid[0, 1, 2, 1] = 0;
            grid[0, 1, 2, 2] = 0;

            //Rangé3
            grid[0, 2, 0, 0] = 0;
            grid[0, 2, 0, 1] = 0;
            grid[0, 2, 0, 2] = 0;

            grid[0, 2, 1, 0] = 0;
            grid[0, 2, 1, 1] = 0;
            grid[0, 2, 1, 2] = 0;

            grid[0, 2, 2, 0] = 0;
            grid[0, 2, 2, 1] = 0;
            grid[0, 2, 2, 2] = 0;

            //Rangé 4
            grid[1, 0, 0, 0] = 0;
            grid[1, 0, 0, 1] = 0;
            grid[1, 0, 0, 2] = 0;

            grid[1, 0, 1, 0] = 0;
            grid[1, 0, 1, 1] = 0;
            grid[1, 0, 1, 2] = 0;

            grid[1, 0, 2, 0] = 0;
            grid[1, 0, 2, 1] = 0;
            grid[1, 0, 2, 2] = 0;

            //Rangé5
            grid[1, 1, 0, 0] = 0;
            grid[1, 1, 0, 1] = 0;
            grid[1, 1, 0, 2] = 0;

            grid[1, 1, 1, 0] = 0;
            grid[1, 1, 1, 1] = 0;
            grid[1, 1, 1, 2] = 0;

            grid[1, 1, 2, 0] = 0;
            grid[1, 1, 2, 1] = 0;
            grid[1, 1, 2, 2] = 0;

            //Rangé6
            grid[1, 2, 0, 0] = 0;
            grid[1, 2, 0, 1] = 0;
            grid[1, 2, 0, 2] = 0;

            grid[1, 2, 1, 0] = 0;
            grid[1, 2, 1, 1] = 0;
            grid[1, 2, 1, 2] = 0;

            grid[1, 2, 2, 0] = 0;
            grid[1, 2, 2, 1] = 0;
            grid[1, 2, 2, 2] = 0;

            //Rangé 7
            grid[2, 0, 0, 0] = 0;
            grid[2, 0, 0, 1] = 0;
            grid[2, 0, 0, 2] = 0;

            grid[2, 0, 1, 0] = 0;
            grid[2, 0, 1, 1] = 0;
            grid[2, 0, 1, 2] = 0;

            grid[2, 0, 2, 0] = 0;
            grid[2, 0, 2, 1] = 0;
            grid[2, 0, 2, 2] = 0;

            //Rangé8
            grid[2, 1, 0, 0] = 0;
            grid[2, 1, 0, 1] = 0;
            grid[2, 1, 0, 2] = 0;

            grid[2, 1, 1, 0] = 0;
            grid[2, 1, 1, 1] = 0;
            grid[2, 1, 1, 2] = 0;

            grid[2, 1, 2, 0] = 0;
            grid[2, 1, 2, 1] = 0;
            grid[2, 1, 2, 2] = 0;

            //Rangé9
            grid[2, 2, 0, 0] = 0;
            grid[2, 2, 0, 1] = 0;
            grid[2, 2, 0, 2] = 0;

            grid[2, 2, 1, 0] = 0;
            grid[2, 2, 1, 1] = 0;
            grid[2, 2, 1, 2] = 0;

            grid[2, 2, 2, 0] = 0;
            grid[2, 2, 2, 1] = 0;
            grid[2, 2, 2, 2] = 0;
        }

        public bool checkDisposingOneRow(int numRow, int[] row)
        {
            int[] coord = setCursor(numRow);
            int counter = 0;
            if (row == null)
            {
                return false;
            }
            for (int rb = coord[0]; rb < coord[0] + 1; rb++)
            {
                for (int r = coord[1]; r < coord[1] + 1; r++)
                {
                    for (int cb = 0; cb < 3; cb++)
                    {
                        for (int c = 0; c < 3; c++)
                        {
                            if (!CheckCaseValide(new int[] {rb,r,cb,c}, row[counter]))
                            {
                                return false;
                            }
                            counter++;
                        }
                    }
                }
            }
            return true;
        }
        public List<List<int>> CopyClues(List<List<int>> rowClues)
        {
            List<List<int>> listToReturn = new();
            for (int i = 0; i < rowClues.Count; i++)
            {
                listToReturn.Add(new List<int>());
                for (int y = 0; y < rowClues[i].Count; y++)
                {
                    listToReturn[i].Add(rowClues[i][y]);
                }
            }
            return listToReturn;
        }
        public void EraseRange(int num)
        {
            int[] coord = setCursor(num);
            for (int rb = coord[0]; rb < coord[0] + 1; rb++)
            {
                for (int r = coord[1]; r < coord[1] + 1; r++)
                {
                    for (int cb = 0; cb < 3; cb++)
                    {
                        for (int c = 0; c < 3; c++)
                        {
                            grid[rb, r, cb, c] = 0;
                        }
                    }
                }
            }
            
        }
        public bool AddOneRow(int numRow, List<List<int>> rowClues)
        {

            List<List<int>> rowCluesStart;
            int[] coord = setCursor(numRow);
            int[] row = new int[9];
            bool loopContinue = true;

            int tryCount = 0;
            do
            {
                rowCluesStart = CopyClues(rowClues);
                row = new RowSolver(rowCluesStart).Resolve();
                if (row==null)
                {
                    rowCluesStart = CopyClues(rowClues);
                    row = new RowSolver(rowCluesStart).Resolve();
                }
                tryCount++;
                loopContinue = !checkDisposingOneRow(numRow, row);
            }
            while (loopContinue && tryCount < 5);
            if (tryCount >= 5)
            {
                return false;
            }
            int counter = 0;
            if (checkDisposingOneRow(numRow, row))
            {
                for (int rb = coord[0]; rb < coord[0] + 1; rb++)
                {
                    for (int r = coord[1]; r < coord[1] + 1; r++)
                    {
                        for (int cb = 0; cb < 3; cb++)
                        {
                            for (int c = 0; c < 3; c++)
                            {
                                if (!AddChiffre(new int[] { rb, r, cb, c }, row[counter]))
                                {
                                    return false;
                                }
                                
                                counter++;
                            }
                        }
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AddFirstBlock()
        {
            throw new NotImplementedException();
        }

        public void HideCase(int number)
        {
            throw new NotImplementedException();
        }


    }
}
