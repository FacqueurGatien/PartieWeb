using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace sudokuFonction
{
    public class RowSolver
    {
        public List<List<int>> array;
        public Dictionary<int, int> itteration;
        public int itterationMin;
        public int min;
        public int max;
        public List<int> index;
        public RowSolver(List<List<int>> _array)
        {
            array = _array;

            itteration = new Dictionary<int, int>();
            itteration.Add(1, 0);
            itteration.Add(2, 0);
            itteration.Add(3, 0);
            itteration.Add(4, 0);
            itteration.Add(5, 0);
            itteration.Add(6, 0);
            itteration.Add(7, 0);
            itteration.Add(8, 0);
            itteration.Add(9, 0);

            min = int.MaxValue;
            max = 0;
            itterationMin = int.MaxValue;
            index = new List<int>();
        }
        public void EditArray(List<List<int>> _array)
        {
            array = _array;
            Reset();
        }
        public override string ToString()
        {
            string result = "";
            result = $"{ShowIn(array[0])} - {ShowIn(array[1])} - {ShowIn(array[2])} | {ShowIn(array[3])} - {ShowIn(array[4])} - {ShowIn(array[5])} | {ShowIn(array[6])} - {ShowIn(array[7])} - {ShowIn(array[8])}";
            return result;
        }
        public string ShowIn(List<int> _array)
        {
            string result = "";
            foreach (int i in _array)
            {
                result += " " + i;
            }
            return result;
        }

        public void MinMax()
        {
            foreach (List<int> i in array)
            {
                if (i.Count >= 2)
                {
                    if (min > i.Count)
                    {
                        min = i.Count;
                    }
                    if (max < i.Count)
                    {
                        max = i.Count;
                    }
                }
            }
        }
        public void IndexInit()
        {
            for (int i = 0; i < array.Count; i++)
            {
                if (array[i].Count == min)
                {
                    index.Add(i);
                }
            }
        }
        public void CiblerIndex()
        {
            List<int> temp = new List<int>();
            for (int i = 0; i < index.Count; i++)
            {
                if (array[index[i]].Contains(itterationMin))
                {
                    temp.Add(index[i]);
                }
            }
            if (temp.Count > 0)
            {
                index = temp;
            }
        }
        public void ItterationMinIndex()
        {
            int temp = 0;
            for (int i = 0; i < index.Count; i++)
            {
                for (int y = 0; y < itteration.Count; y++)
                {
                    if (itteration[y + 1] < itterationMin && ContainMin(y + 1))
                    {
                        itterationMin = itteration[y + 1];
                        temp = y + 1;
                    }
                }
            }
            itterationMin = temp;
        }
        public bool ContainMin(int numToTest)
        {
            bool test = false;
            foreach (int i in index)
            {
                if (array[i].Contains(numToTest))
                {
                    return true;
                }
            }
            return false;
        }
        public void ReduceIndex()
        {
            if (index.Count > 1)
            {
                int tempIndeSum = int.MaxValue;
                List<int> temp = new List<int>();
                for (int i = 0; i < index.Count; i++)
                {
                    int count = 0;
                    foreach (int y in array[index[i]])
                    {
                        count += itteration[y];
                    }
                    if (count < tempIndeSum)
                    {
                        tempIndeSum = count;
                    }
                }
                for (int i = 0; i < index.Count; i++)
                {
                    int count = 0;
                    foreach (int y in array[index[i]])
                    {
                        count += itteration[y];
                    }
                    if (count == tempIndeSum)
                    {
                        temp.Add(index[i]);
                    }
                }
                index = temp;
            }
        }
        public void RandomizeChoice(bool random)
        {
            if (index.Count > 0)
            {
                int rand = 0;
                List<int> temp;
                int numToPurge = 0;
                int indice = 0;
                if (index.Count > 1)
                {
                    /*                    rand = index[new Random().Next(0, index.Count)];
                                        int randIn = new Random().Next(0, min);
                                        temp = new List<int>() { array[rand][randIn] };
                                        array[rand] = temp;
                                        numToPurge = array[rand][0];*/

                    rand = index[new Random().Next(0, index.Count)];
                    if (random)
                    {
                        indice = array[rand][new Random().Next(0, array[rand].Count)];
                        array[rand] = new List<int>() { indice };
                        numToPurge = indice;
                    }
                    else
                    {
                        indice = SelectIndice(rand);
                        array[index[0]] = new List<int>() { indice };
                        numToPurge = indice;
                    }
                }
                else
                {
                    /*                    rand = index[0];
                                        temp = new List<int>() { itterationMin };
                                        array[rand] = temp;
                                        numToPurge = itterationMin;*/
                    rand = index[0];
                    indice = SelectIndice(rand);
                    array[index[0]] = new List<int>() { indice };
                    numToPurge = indice;
                }
                PurgeArray(numToPurge);
            }
        }
        public int SelectIndice(int num)
        {
            int temp = 0;
            int tempToreturn = int.MaxValue;
            if (array[num].Count > 1)
            {
                bool trigger = false;
                temp = itteration[array[num][0]];
                foreach (int i in array[num])
                {
                    if (itteration[i] < temp && itteration[i] > 1)
                    {
                        tempToreturn = i;
                        trigger = true;
                    }
                }
                if (tempToreturn > 9)
                {
                    tempToreturn = array[num][new Random().Next(0, array[num].Count)];
                    trigger= true;
                }
                if (trigger)
                {
                    return tempToreturn;
                }
                else
                {
                    tempToreturn = array[num][new Random().Next(0, array[num].Count)];
                }
            }
            else
            {
                tempToreturn = array[num][0];
            }
            return tempToreturn;
        }
        public void PurgeCheck()
        {
            bool checkPurge = true;
            int compteur = 10;
            while (checkPurge && compteur > 0)
            {
                checkPurge = false;
                Reset();
                ItterationInit();
                foreach (List<int> i in array)
                {
                    if (i.Count == 1 && itteration[i[0]] > 1)
                    {
                        PurgeArray(i[0]);
                        checkPurge = true;
                    }
                }
                //                Console.WriteLine(ToString() + "-Purge");
                compteur--;
            }

        }
        public void ItterationInit()
        {
            foreach (List<int> it in array)
            {
                foreach (int i in it)
                {
                    itteration[i]++;
                }
            }
        }
        public void PurgeArray(int nb)
        {
            foreach (List<int> i in array)
            {
                if (i.Contains(nb) && i.Count > 1)
                {
                    i.Remove(nb);
                }
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

            min = int.MaxValue;
            max = 0;
            itterationMin = int.MaxValue;
            index = new List<int>();
        }
        public bool ItterationBool()
        {
            ItterationInit();
            int temp = 0;
            for (int i = 0; i < itteration.Count; i++)
            {
                if (itteration[i + 1] == 0)
                {
                    return false;
                }
                temp += itteration[i + 1];
            }

            return temp == 9;
        }
        public int[] Resolve(bool random = false)
        {
            int compteur = 0;
            while (!ItterationBool() && compteur < 9)
            {
                MinMax();
                IndexInit();
                ItterationMinIndex();
                ReduceIndex();
                CiblerIndex();
                RandomizeChoice(random);
                PurgeCheck();
                Reset();
                //                Console.WriteLine(ToString());
                compteur++;
            }
            int[] rowToReturn = new int[9];
            for (int i = 0; i < rowToReturn.Length; i++)
            {
                rowToReturn[i] = array[i][0];
            }
            Reset();
            if (!ItterationBool())
            {
                return null;
            }
            return rowToReturn;
        }
    }

}
