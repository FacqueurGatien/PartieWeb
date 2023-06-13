using SudokuGrille;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuAlgo.AlgoTraqueur
{
    public static class AlgoResolveur
    {
        public static Grille? Demarer(Grille _grille)
        {
            Grille grille = CopieGrille.Copie(_grille);//Copier la grille de depart a chaque itteration
            List<List<int[]>> listeIndex = RecupererListeIndex(_grille);
            Grille? grilleFinal = ResolveAlgo2(listeIndex, _grille);
            if (grilleFinal != null && grilleFinal.CompterItterationTotal() == 81)
            {
                return grilleFinal;
            }
            return _grille;
        }
        public static List<int> RecupererListeItterationTrie(Grille _grille)
        {
            Dictionary<int, int> itteration = _grille.RecupererItteration();
            List<int> listeChiffreTrie = new List<int>();
            foreach (KeyValuePair<int, int> i in itteration.OrderBy(key => key.Value))
            {
                if (i.Value != 9)
                {
                    listeChiffreTrie.Add(i.Key);
                }
            }
            return listeChiffreTrie;
        }
        public static List<List<int[]>> RecupererListeIndex(Grille _grille)
        {
            List<int> listeChiffreTrie = RecupererListeItterationTrie(_grille);
            List<List<int[]>> indexRetenu = new List<List<int[]>>();
            int sortie = 0;
            int num = 0;
            while (sortie < listeChiffreTrie.Count - 1)
            {
                List<int[]> listeIndex = new List<int[]>();

                foreach (Ligne ra in _grille.Rangees)
                {
                    foreach (Case ca in ra.Cases)
                    {
                        if (ca.Contenu.Count > 1)
                        {
                            if (ca.Contenu.Contains(listeChiffreTrie[num]))
                            {
                                listeIndex.Add(new int[] { ca.NumRangee, ca.NumPositionRangee, listeChiffreTrie[num] });
                            }
                        }
                    }
                }
                if (listeIndex.Count != 0)
                {
                    indexRetenu.Add(listeIndex);
                }
                num++;
                sortie++;
            }
            indexRetenu = IndexTrie(indexRetenu);
            int indexNum;
            int temp = _grille.CompterItterationTotal();
            if (temp > 300)
                indexNum = 6;
            else if (temp > 270)
                indexNum = 5;
            else if (temp > 240)
                indexNum = 4;
            else if (temp > 210)
                indexNum = 3;
            else
                indexNum = 2;
            while (indexRetenu.Count > indexNum)
            {
                indexRetenu.Remove(indexRetenu[indexRetenu.Count - 1]);
            }
            return indexRetenu;
        }
        public static List<List<int[]>> IndexTrie(List<List<int[]>> indexRetenu)
        {
            List<List<int[]>> listTemp = new List<List<int[]>> { indexRetenu[0] };
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
        public static Grille? ResolveAlgo2(List<List<int[]>> indexListe, Grille _grille)
        {
            if (indexListe.Count == 2)
            {
                int counterA = 0;
                int counterB = 0;
                for (int a = 0; a < 1; a++)
                {
                    for (int b = 1; b < 2; b++)
                    {
                        if (a != b)
                        {
                            if (counterB < indexListe[b].Count)
                            {
                                /////////////////////////////////
                                Grille grid = CopieGrille.Copie(_grille);
                                grid.Rangees
                                    [indexListe[a][counterA][0]].Cases
                                    [indexListe[a][counterA][1]].Contenu = new List<int>() { indexListe[a][counterA][2] };
                                grid.Rangees
                                    [indexListe[b][counterB][0]].Cases
                                    [indexListe[b][counterB][1]].Contenu = new List<int>() { indexListe[b][counterB][2] };
                                AlgoReductionIndices.Reduction(grid);
                                if (grid.EtatGrille == EnumEtatGrille.Complette)
                                {
                                    return grid;
                                }
                                counterB++;
                                b--;
                            }
                            else
                            {
                                counterB = 0;
                            }
                        }
                    }
                    if (counterA + 1 != indexListe[a].Count)
                    {
                        counterA++;
                        a--;
                    }
                    else
                    {
                        counterA = 0;
                    }
                }
                return null;
            }
            else if (indexListe.Count == 3)
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
                                if (counterC < indexListe[c].Count)
                                {
                                    /////////////////////////////////
                                    Grille grid = CopieGrille.Copie(_grille);
                                    grid.Rangees
                                        [indexListe[a][counterA][0]].Cases//dddddddddddddddddddddd
                                        [indexListe[a][counterA][1]].Contenu = new List<int>() { indexListe[a][counterA][2] };
                                    grid.Rangees
                                        [indexListe[b][counterB][0]].Cases
                                        [indexListe[b][counterB][1]].Contenu = new List<int>() { indexListe[b][counterB][2] };
                                    grid.Rangees
                                        [indexListe[c][counterC][0]].Cases
                                        [indexListe[c][counterC][1]].Contenu = new List<int>() { indexListe[c][counterC][2] };
                                    AlgoReductionIndices.Reduction(grid);
                                    if (grid.EtatGrille == EnumEtatGrille.Complette)
                                    {
                                        return grid;
                                    }
                                    counterC++;
                                    c--;
                                }
                                else
                                {
                                    counterC = 0;
                                }
                            }
                        }
                        if (counterB + 1 != indexListe[b].Count)
                        {

                            counterB++;
                            b--;
                        }
                    }
                    if (counterA + 1 != indexListe[a].Count)
                    {
                        counterA++;
                        a--;
                    }
                }
                return null;
            }
            else if (indexListe.Count == 4)
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
                                    if (counterD < indexListe[d].Count)
                                    {
                                        /////////////////////////////////
                                        Grille grid = CopieGrille.Copie(_grille);
                                        grid.Rangees
                                            [indexListe[a][counterA][0]].Cases
                                            [indexListe[a][counterA][1]].Contenu = new List<int>() { indexListe[a][counterA][2] };
                                        grid.Rangees
                                            [indexListe[b][counterB][0]].Cases
                                            [indexListe[b][counterB][1]].Contenu = new List<int>() { indexListe[b][counterB][2] };
                                        grid.Rangees
                                            [indexListe[c][counterC][0]].Cases
                                            [indexListe[c][counterC][1]].Contenu = new List<int>() { indexListe[c][counterC][2] };
                                        grid.Rangees
                                            [indexListe[d][counterD][0]].Cases
                                            [indexListe[d][counterD][1]].Contenu = new List<int>() { indexListe[d][counterD][2] };
                                        AlgoReductionIndices.Reduction(grid);
                                        if (grid.EtatGrille == EnumEtatGrille.Complette)
                                        {
                                            return grid;
                                        }
                                        counterD++;
                                        d--;
                                    }
                                    else
                                    {
                                        counterD = 0;
                                    }
                                }
                            }
                            if (counterC + 1 != indexListe[c].Count)
                            {

                                counterC++;
                                c--;
                            }
                        }
                        if (counterB + 1 != indexListe[b].Count)
                        {
                            counterB++;
                            b--;
                        }
                    }
                    if (counterA + 1 != indexListe[a].Count)
                    {
                        counterA++;
                        a--;
                    }
                }
                return null;
            }
            else if (indexListe.Count == 5)
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
                                        if (counterE < indexListe[e].Count)
                                        {
                                            /////////////////////////////////
                                            Grille grid = CopieGrille.Copie(_grille);
                                            grid.Rangees
                                                [indexListe[a][counterA][0]].Cases
                                                [indexListe[a][counterA][1]].Contenu = new List<int>() { indexListe[a][counterA][2] };
                                            grid.Rangees
                                                [indexListe[b][counterB][0]].Cases
                                                [indexListe[b][counterB][1]].Contenu = new List<int>() { indexListe[b][counterB][2] };
                                            grid.Rangees
                                                [indexListe[c][counterC][0]].Cases
                                                [indexListe[c][counterC][1]].Contenu = new List<int>() { indexListe[c][counterC][2] };
                                            grid.Rangees
                                                [indexListe[d][counterD][0]].Cases
                                                [indexListe[d][counterD][1]].Contenu = new List<int>() { indexListe[d][counterD][2] };
                                            grid.Rangees
                                                [indexListe[e][counterE][0]].Cases
                                                [indexListe[e][counterE][1]].Contenu = new List<int>() { indexListe[e][counterE][2] };
                                            AlgoReductionIndices.Reduction(grid);
                                            if (grid.EtatGrille == EnumEtatGrille.Complette)
                                            {
                                                return grid;
                                            }
                                            counterE++;
                                            e--;
                                        }
                                        else
                                        {
                                            counterE = 0;
                                        }
                                    }

                                }
                                if (counterD + 1 != indexListe[d].Count)
                                {

                                    counterD++;
                                    d--;
                                }

                            }
                            if (counterC + 1 != indexListe[c].Count)
                            {

                                counterC++;
                                c--;
                            }
                        }
                        if (counterB + 1 != indexListe[b].Count)
                        {
                            counterB++;
                            b--;
                        }
                    }
                    if (counterA + 1 != indexListe[a].Count)
                    {
                        counterA++;
                        a--;
                    }
                }
                return null;
            }
            else if (indexListe.Count == 6)
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
                                            if (counterF < indexListe[f].Count)
                                            {
                                                /////////////////////////////////
                                                Grille grid = CopieGrille.Copie(_grille);
                                                grid.Rangees
                                                    [indexListe[a][counterA][0]].Cases
                                                    [indexListe[a][counterA][1]].Contenu = new List<int>() { indexListe[a][counterA][2] };
                                                grid.Rangees
                                                    [indexListe[b][counterB][0]].Cases
                                                    [indexListe[b][counterB][1]].Contenu = new List<int>() { indexListe[b][counterB][2] };
                                                grid.Rangees
                                                    [indexListe[c][counterC][0]].Cases
                                                    [indexListe[c][counterC][1]].Contenu = new List<int>() { indexListe[c][counterC][2] };
                                                grid.Rangees
                                                    [indexListe[d][counterD][0]].Cases
                                                    [indexListe[d][counterD][1]].Contenu = new List<int>() { indexListe[d][counterD][2] };
                                                grid.Rangees
                                                    [indexListe[e][counterE][0]].Cases
                                                    [indexListe[e][counterE][1]].Contenu = new List<int>() { indexListe[e][counterE][2] };
                                                grid.Rangees
                                                    [indexListe[f][counterF][0]].Cases
                                                    [indexListe[f][counterF][1]].Contenu = new List<int>() { indexListe[f][counterF][2] };
                                                AlgoReductionIndices.Reduction(grid);
                                                if (grid.EtatGrille == EnumEtatGrille.Complette)
                                                {
                                                    return grid;
                                                }
                                                counterF++;
                                                f--;
                                            }
                                            else
                                            {
                                                counterF = 0;
                                            }
                                        }
                                    }
                                    if (counterE + 1 != indexListe[e].Count)
                                    {

                                        counterE++;
                                        e--;
                                    }

                                }
                                if (counterD + 1 != indexListe[d].Count)
                                {

                                    counterD++;
                                    d--;
                                }

                            }
                            if (counterC + 1 != indexListe[c].Count)
                            {

                                counterC++;
                                c--;
                            }
                        }
                        if (counterB + 1 != indexListe[b].Count)
                        {
                            counterB++;
                            b--;
                        }
                    }
                    if (counterA + 1 != indexListe[a].Count)
                    {
                        counterA++;
                        a--;
                    }
                }
                return null;
            }
            else
            {
                return null;
            }
        }
    }
}
