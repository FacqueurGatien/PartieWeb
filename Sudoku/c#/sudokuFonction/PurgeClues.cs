using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
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
        }
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
        }
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
        }

        /// <summary>
        /// Permet de remettre a 0 le dictionnaire d'iteration
        /// </summary>
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
        /// <summary>
        /// Permet de purger Une rangé
        /// </summary>
        /// <param name="coordCase">Coordonnée de la case a purger</param>
        /// <param name="itterationMode">Permet d'enclencher le mode itteration pour modifier la facon de purger la rangé</param>
        public void PurgeCluesRow(int[] coordCase, bool itterationMode)
        {
            if (!itterationMode)//En mode Non itteration on parcour la rangé a la recherche d du chiffre a purger si la case de depart contient un 6, a chaque case de la rangé il est verifié si un 6 est contenu et effacé si c'est le cas
            {
                int num = grid[coordCase[0]][coordCase[1]][coordCase[2]][coordCase[3]][0];



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
            else //En mode itteration On verifie pour chaque case et chaque chiffre si le chiffre est contenue qu'une fois dans la rangé et le place sur la case si c'est le cas
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
        /// <summary>
        /// Permet le placement d'un chiffre sur une case
        /// </summary>
        /// <param name="coordCase">Coordonnée de la case</param>
        /// <param name="num">chiffre à placé</param>
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
        /// <summary>
        /// Permet de purger Une Colonne
        /// </summary>
        /// <param name="coordCase">Coordonnée de la case a purger</param>
        /// <param name="itterationMode">Permet d'enclencher le mode itteration pour modifier la facon de purger la colonne</param>
        public void purgeCluesCol(int[] coordCase, bool itterationMode, int _num = 0)
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
        /// <summary>
        /// Permet de purger Une colonne
        /// </summary>
        /// <param name="coordCase">Coordonnée de la case a purger</param>
        /// <param name="itterationMode">Permet d'enclencher le mode itteration pour modifier la facon de purger la colonne</param>
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
        /// <summary>
        /// Permet de purger Un Block
        /// </summary>
        /// <param name="coordCase">Coordonnée de la case a purger</param>
        /// <param name="itterationMode">Permet d'enclencher le mode itteration pour modifier la facon de purger le block</param>
        public void purgeCluesBlock(int[] coordCase, bool itterationMode, int _num = 0)
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
        /// <summary>
        /// Permet de purger Un Block
        /// </summary>
        /// <param name="coordCase">Coordonnée de la case a purger</param>
        /// <param name="itterationMode">Permet d'enclencher le mode itteration pour modifier la facon de purger le block</param>
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

        /// <summary>
        /// Permet d'effacer le chiffre d'une Rangé/Colonne/Block Sauf sur la case Specifié
        /// </summary>
        /// <param name="coord">Coordonnée de la case du chiffre a purger</param>
        /// <param name="num">Chiffre a purger</param>
        public void EraseClues(int[] coord, int num)
        {
            int before = grid[coord[0]][coord[1]][coord[2]][coord[3]].Count;
            grid[coord[0]][coord[1]][coord[2]][coord[3]].Remove(num);
            if (before != grid[coord[0]][coord[1]][coord[2]][coord[3]].Count)
            {
                purgeAction = true;
            }

        }

        /// <summary>
        /// Permet de remettre a 0 le dictionnaire d'iteration
        /// </summary>
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
        }

        /// <summary>
        /// Permet de parcourrir toute la grille a la recherche de case a Purger
        /// </summary>
        /// <param name="itterationMode">Active ou desactive le mode itteration</param>
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
        public void PurgeCaseOneDigit(int[] coord, bool itterationMode)
        {
            PurgeCluesRow(coord, itterationMode);
            purgeCluesCol(coord, itterationMode);
            purgeCluesBlock(coord, itterationMode);
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
            ItterationInit();
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
        }

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
        }
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
        }



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
        }

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
        }
        /// <summary>
        /// Permet de changer l'algorythme de Purge Quand la resolution classique n'est pas suffisante
        /// <br/>On cherche les case avec les chiffre ayant le moins d'occurence, puis on cible les case ou ils sont avec d'autre chiffre
        /// <br/>Puis a tour de role on remplace la case par ce chiffre et on retente la resolution
        /// <br/>Puis si la resolution echoue on tente de remplacer ce chiffre sur la case d'apres
        /// </summary>
        /// <param name="essaie"></param>
        public bool ItterationMinResolve(int essaie) ////////////////A travailler <----- verifier son fonctionnement (possibilité d'optimiser)
        {
            List<List<int[]>> indexList = getIndexList();
            return ResolveAlgo2(indexList);
        }
        public bool ResolveAlgo2(List<List<int[]>> index)
        {
            int compteur = 0;
            if (index.Count == 2)
            {
                int counterA = 0;
                int counterB = 0;
                for (int a = 0; a < 1; a++)
                {
                    for (int b = 1; b < 2; b++)
                    {
                        if (a != b)
                        {
                            if (counterB < index[b].Count)
                            {
                                /////////////////////////////////
                                ItterationCount();
                                resolveAction = 0;
                                grid = new List<List<List<List<List<int>>>>>();
                                GridCluesDisposeAuto();
                                grid[index[a][counterA][0]]
                                    [index[a][counterA][1]]
                                    [index[a][counterA][2]]
                                    [index[a][counterA][3]] = new List<int>() { index[a][counterA][4] };
                                grid[index[b][counterB][0]]
                                    [index[b][counterB][1]]
                                    [index[b][counterB][2]]
                                    [index[b][counterB][3]] = new List<int>() { index[b][counterB][4] };
                                if (ResolveGrid(false))
                                {
                                    return true;
                                }
                                //Console.WriteLine(ToString() + "\n" + ++compteur + "\n" + a + " " + counterA + " " + b + " " + counterB);

                                /////////////////////////////////

                                counterB++;
                                b--;
                            }
                            else
                            {
                                counterB = 0;
                            }
                        }
                    }
                    if (counterA + 1 != index[a].Count)
                    {
                        counterA++;
                        a--;
                    }
                    else
                    {
                        counterA = 0;
                    }
                }
                return false;
            }
            else if (index.Count == 3)
            {
                int counterA = 0;
                int counterB = 0;
                int counterC = 0;
                for (int a = 0; a < 1; a++)
                {
                    for (int b = 1; b < 2; b++)
                    {

                        for (int c = 2; c < 3; c++)
                        {

                            if (b != c && a != c && b != a)
                            {
                                if (counterC < index[c].Count)
                                {
                                    /////////////////////////////////
                                    ItterationCount();
                                    resolveAction = 0;
                                    grid = new List<List<List<List<List<int>>>>>();
                                    GridCluesDisposeAuto();
                                    grid[index[a][counterA][0]]
                                        [index[a][counterA][1]]
                                        [index[a][counterA][2]]
                                        [index[a][counterA][3]] = new List<int>() { index[a][counterA][4] };
                                    grid[index[b][counterB][0]]
                                        [index[b][counterB][1]]
                                        [index[b][counterB][2]]
                                        [index[b][counterB][3]] = new List<int>() { index[b][counterB][4] };
                                    grid[index[c][counterC][0]]
                                        [index[c][counterC][1]]
                                        [index[c][counterC][2]]
                                        [index[c][counterC][3]] = new List<int>() { index[c][counterC][4] };
                                    if (ResolveGrid(false))
                                    {
                                        return true;
                                    }
                                    ResolveGrid(false);
                                    compteur++;
                                    Console.WriteLine(ToString() + "\n" + compteur + "\n" + a + " " + counterA + " " + b + " " + counterB + " " + c + " " + counterC);
                                    /////////////////////////////////

                                    counterC++;
                                    c--;
                                }
                                else
                                {
                                    counterC = 0;
                                }
                            }
                        }
                        if (counterB + 1 != index[b].Count)
                        {

                            counterB++;
                            b--;
                        }
                    }
                    if (counterA + 1 != index[a].Count)
                    {
                        counterA++;
                        a--;
                    }
                }
                return false;
            }
            else if (index.Count == 4)
            {
                int counterA = 0;
                int counterB = 0;
                int counterC = 0;
                int counterD = 0;
                for (int a = 0; a < 1; a++)
                {
                    for (int b = 1; b < 2; b++)
                    {
                        for (int c = 2; c < 3; c++)
                        {

                            for (int d = 3; d < 4; d++)
                            {

                                if (b != c && a != c && b != a && d != a && d != b && d != c)
                                {
                                    if (counterD < index[d].Count)
                                    {
                                        /////////////////////////////////
                                        ItterationCount();
                                        resolveAction = 0;
                                        grid = new List<List<List<List<List<int>>>>>();
                                        GridCluesDisposeAuto();
                                        grid[index[a][counterA][0]]
                                            [index[a][counterA][1]]
                                            [index[a][counterA][2]]
                                            [index[a][counterA][3]] = new List<int>() { index[a][counterA][4] };
                                        grid[index[b][counterB][0]]
                                            [index[b][counterB][1]]
                                            [index[b][counterB][2]]
                                            [index[b][counterB][3]] = new List<int>() { index[b][counterB][4] };
                                        grid[index[c][counterC][0]]
                                            [index[c][counterC][1]]
                                            [index[c][counterC][2]]
                                            [index[c][counterC][3]] = new List<int>() { index[c][counterC][4] };
                                        grid[index[d][counterD][0]]
                                            [index[d][counterD][1]]
                                            [index[d][counterD][2]]
                                            [index[d][counterD][3]] = new List<int>() { index[d][counterD][4] };
                                        if (ResolveGrid(false))
                                        {
                                            return true;
                                        }
                                        Console.WriteLine(ToString() + "\n" + ++compteur + "\n" + a + " " + counterA + " |" + b + " " + counterB + "  |" + c + " " + counterC + " |" + d + " " + counterD);
                                        /////////////////////////////////

                                        counterD++;
                                        d--;
                                    }
                                    else
                                    {
                                        counterD = 0;
                                    }
                                }
                            }
                            if (counterC + 1 != index[c].Count)
                            {

                                counterC++;
                                c--;
                            }
                        }
                        if (counterB + 1 != index[b].Count)
                        {
                            counterB++;
                            b--;
                        }
                    }
                    if (counterA + 1 != index[a].Count)
                    {
                        counterA++;
                        a--;
                    }
                }
                return false;
            }
            else if (index.Count == 5)
            {
                int counterA = 0;
                int counterB = 0;
                int counterC = 0;
                int counterD = 0;
                int counterE = 0;
                for (int a = 0; a < 1; a++)
                {
                    for (int b = 1; b < 2; b++)
                    {
                        for (int c = 2; c < 3; c++)
                        {

                            for (int d = 3; d < 4; d++)
                            {
                                for (int e = 4; e < 5; e++)
                                {

                                    if (b != c &&
                                        a != c && b != a &&
                                        d != a && d != b && d != c &&
                                        e != a && e != b && e != c && e != d)
                                    {
                                        if (counterE < index[e].Count)
                                        {
                                            /////////////////////////////////
                                            ItterationCount();
                                            resolveAction = 0;
                                            grid = new List<List<List<List<List<int>>>>>();
                                            GridCluesDisposeAuto();
                                            grid[index[a][counterA][0]]
                                                [index[a][counterA][1]]
                                                [index[a][counterA][2]]
                                                [index[a][counterA][3]] = new List<int>() { index[a][counterA][4] };
                                            grid[index[b][counterB][0]]
                                                [index[b][counterB][1]]
                                                [index[b][counterB][2]]
                                                [index[b][counterB][3]] = new List<int>() { index[b][counterB][4] };
                                            grid[index[c][counterC][0]]
                                                [index[c][counterC][1]]
                                                [index[c][counterC][2]]
                                                [index[c][counterC][3]] = new List<int>() { index[c][counterC][4] };
                                            grid[index[d][counterD][0]]
                                                [index[d][counterD][1]]
                                                [index[d][counterD][2]]
                                                [index[d][counterD][3]] = new List<int>() { index[d][counterD][4] };
                                            grid[index[e][counterE][0]]
                                                [index[e][counterE][1]]
                                                [index[e][counterE][2]]
                                                [index[e][counterE][3]] = new List<int>() { index[e][counterE][4] };
                                            if (ResolveGrid(false))
                                            {
                                                return true;
                                            }
                                            Console.WriteLine(ToString() + "\n" + ++compteur + "\n" + a + " " + counterA + " |" + b + " " + counterB + "  |" + c + " " + counterC + " |" + d + " " + counterD + " |" + e + " " + counterE);
                                            /////////////////////////////////

                                            counterE++;
                                            e--;
                                        }
                                        else
                                        {
                                            counterE = 0;
                                        }
                                    }

                                }
                                if (counterD + 1 != index[d].Count)
                                {

                                    counterD++;
                                    d--;
                                }

                            }
                            if (counterC + 1 != index[c].Count)
                            {

                                counterC++;
                                c--;
                            }
                        }
                        if (counterB + 1 != index[b].Count)
                        {
                            counterB++;
                            b--;
                        }
                    }
                    if (counterA + 1 != index[a].Count)
                    {
                        counterA++;
                        a--;
                    }
                }
                return false;
            }
            else if (index.Count == 6)
            {
                int counterA = 0;
                int counterB = 0;
                int counterC = 0;
                int counterD = 0;
                int counterE = 0;
                int counterF = 0;
                for (int a = 0; a < 1; a++)
                {
                    for (int b = 1; b < 2; b++)
                    {
                        for (int c = 2; c < 3; c++)
                        {

                            for (int d = 3; d < 4; d++)
                            {
                                for (int e = 4; e < 5; e++)
                                {
                                    for (int f = 5; f < 6; f++)
                                    {
                                        if (b != c &&
                                            a != c && b != a &&
                                            d != a && d != b && d != c &&
                                            e != a && e != b && e != c && e != d &&
                                            f != a && f != b && f != c && f != d && f != e)
                                        {
                                            if (counterF < index[f].Count)
                                            {
                                                /////////////////////////////////
                                                ItterationCount();
                                                resolveAction = 0;
                                                grid = new List<List<List<List<List<int>>>>>();
                                                GridCluesDisposeAuto();
                                                grid[index[a][counterA][0]]
                                                    [index[a][counterA][1]]
                                                    [index[a][counterA][2]]
                                                    [index[a][counterA][3]] = new List<int>() { index[a][counterA][4] };
                                                grid[index[b][counterB][0]]
                                                    [index[b][counterB][1]]
                                                    [index[b][counterB][2]]
                                                    [index[b][counterB][3]] = new List<int>() { index[b][counterB][4] };
                                                grid[index[c][counterC][0]]
                                                    [index[c][counterC][1]]
                                                    [index[c][counterC][2]]
                                                    [index[c][counterC][3]] = new List<int>() { index[c][counterC][4] };
                                                grid[index[d][counterD][0]]
                                                    [index[d][counterD][1]]
                                                    [index[d][counterD][2]]
                                                    [index[d][counterD][3]] = new List<int>() { index[d][counterD][4] };
                                                grid[index[e][counterE][0]]
                                                    [index[e][counterE][1]]
                                                    [index[e][counterE][2]]
                                                    [index[e][counterE][3]] = new List<int>() { index[e][counterE][4] };
                                                grid[index[f][counterF][0]]
                                                    [index[f][counterF][1]]
                                                    [index[f][counterF][2]]
                                                    [index[f][counterF][3]] = new List<int>() { index[f][counterF][4] };
                                                if (ResolveGrid(false))
                                                {
                                                    return true;
                                                }
                                                Console.WriteLine(ToString() + "\n" + ++compteur + "\n" + a + " " + counterA + " |" + b + " " + counterB + "  |" + c + " " + counterC + " |" + d + " " + counterD + " |" + e + " " + counterE + " |" + f + " " + counterF);
                                                /////////////////////////////////

                                                counterF++;
                                                f--;
                                            }
                                            else
                                            {
                                                counterF = 0;
                                            }
                                        }
                                    }
                                    if (counterE + 1 != index[e].Count)
                                    {

                                        counterE++;
                                        e--;
                                    }

                                }
                                if (counterD + 1 != index[d].Count)
                                {

                                    counterD++;
                                    d--;
                                }

                            }
                            if (counterC + 1 != index[c].Count)
                            {

                                counterC++;
                                c--;
                            }
                        }
                        if (counterB + 1 != index[b].Count)
                        {
                            counterB++;
                            b--;
                        }
                    }
                    if (counterA + 1 != index[a].Count)
                    {
                        counterA++;
                        a--;
                    }
                }
                return false;
            }
            else
            {
                return false;
            }
        }
        public List<List<int[]>> getIndexList()
        {
            int num = 0;
            ItterationCount();//Sans paramettre toute la grille sera compté

            //Création d'un tableau avec les chiffre trié par nombre d'aparition dans la grille
            List<int> array = new List<int>();
            foreach (KeyValuePair<int, int> i in itteration.OrderBy(key => key.Value))
            {
                if (i.Value != 9)
                {
                    array.Add(i.Key);
                }
            }
            int sortie = 0;
            List<List<int[]>> indexRetenu = new List<List<int[]>>();

            while (sortie < array.Count - 1)
            {
                //Liste des index a parcourrir
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
                                    if (grid[rb][r][cb][c].Contains(array[num]))
                                    {
                                        index.Add(new int[] { rb, r, cb, c, array[num] });
                                    }
                                }
                            }
                        }
                    }
                }
                if (index.Count != 0)
                {
                    indexRetenu.Add(index);
                }
                num++;
                sortie++;
            }

            indexRetenu = IndexSort(indexRetenu);//A paufinner (tester les diferente plage ou il est plus interessant d'utiliser moins d'index)
            int indexNum = 0;
            if (ItterationTotal()>300)
                indexNum = 6;
            else if(ItterationTotal()>270)
                indexNum = 5;
            else if (ItterationTotal()>240)
                indexNum = 4;
            else if (ItterationTotal() > 210)
                indexNum = 3;
            else
                indexNum = 2;
            while (indexRetenu.Count > indexNum)
            {
                //indexRetenu.Reverse();
                indexRetenu.Remove(indexRetenu[indexRetenu.Count - 1]);
            }
            return indexRetenu;
        }
        public List<List<int[]>> IndexSort(List<List<int[]>> indexRetenu)
        {
            int test = 0;
            int count = int.MaxValue;
            List<List<int[]>> listTemp = new List<List<int[]>>();
            listTemp.Add(indexRetenu[0]);
            for (int i = 1; i < indexRetenu.Count; i++)
            {
                for (int y = 0; y < listTemp.Count; y++)
                {
                    if (indexRetenu[i].Count <= listTemp[y].Count)
                    {
                        listTemp.Insert(y, indexRetenu[i]);
                        y = int.MaxValue - 1;
                    }
                }
                if (i == listTemp.Count)
                {
                    listTemp.Add(indexRetenu[i]);
                }
            }
            return listTemp;
        }
        public int ItterationTotal()
        {
            ItterationCount();
            int temp = 0;
            foreach (KeyValuePair<int,int> i in itteration)
            {
                temp += i.Value;
            }
            return temp;
        }
        public bool ResolveGrid(bool minResolveMode = true)
        {
            while (!CheckAllItteration() && resolveAction < 11 && essaieMinResolve < 5)
            {
                int compte=ItterationTotal();
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
                //Console.WriteLine(ToString());
            }
            if (CheckAllItteration())
            {
                resolveAction = int.MaxValue;
                return true;
            }
            else
            {
                return false;
            }

        }
    }


}
