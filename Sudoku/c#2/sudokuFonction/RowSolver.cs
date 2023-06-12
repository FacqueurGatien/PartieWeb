using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Reflection.Metadata.BlobBuilder;

namespace sudokuFonction
{
    public class RowSolver
    {
        public List<List<int>> array;
        public Dictionary<int, int> itteration;
        public int itterationMin;
        public int min;
        public List<int> index;
        /// <summary>
        /// Constructeur qui prend une rangée d'indice en parametre
        /// </summary>
        /// <param name="_array"></param>
        public RowSolver(List<List<int>> _array)
        {
            array = _array;
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

            min = int.MaxValue;
            itterationMin = int.MaxValue;
            index = new List<int>();
        }
        /// <summary>
        /// Permet de chercher quel est le nombre d'indice minimum present dans une case (a l'exception de 1)
        /// </summary>
        public void Min()
        {
            foreach (List<int> i in array)
            {
                if (i.Count >= 2)
                {
                    if (min > i.Count)
                    {
                        min = i.Count;
                    }
                }
            }
        }
        /// <summary>
        /// Initialise la liste d'index en y enregistrant toute les case ou le nombre d'indice est egale au minimum
        /// </summary>
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
        /// <summary>
        /// Tente de cibler l'(les) index qui cible la(les) case(s) avec  contenant le chiffre avec l'itteration minimal
        /// </summary>
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
        /// <summary>
        /// Permet de chercher le chiffre  qui aparait le moin dans la rangée d'indice et qui est dans la case parcouru.
        /// </summary>
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="numToTest"></param>
        /// <returns></returns>
        public bool ContainMin(int numToTest)
        {
            foreach (int i in index)
            {
                if (array[i].Contains(numToTest))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Tente de reduire la liste d'index si celle ci est superieur a 1
        /// en faisant la somme des itteration des chiffres present dans chaque case de la liste d'index et les compare entre elles
        /// </summary>
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
        /// <summary>
        /// Si la liste d'index est egale a 0 return false Sinon return true<br/>
        /// Si la liste d'index est egale a 1 : Selection d'un nombre aleatoire dans la case de l'index et apelle de la fonction de purge<br/>
        /// Si la liste d'index est supperieure a 1 : Selection d'un index aleatoire, puis d'un chiffre aleatoire dans l'index puis apelle de la fonction de purge 
        /// </summary>
        /// <param name="random">Permet d'activer la selection totalement aleatoire sur true, et semi aleatoire sur false</param>
        /// <returns></returns>
        public bool RandomizeChoice(bool random)
        {
            if (index.Count > 0)
            {
                int rand = 0;
                List<int> temp;
                int numToPurge = 0;
                int indice = 0;
                if (index.Count > 1)
                {
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
                    indice = SelectIndice(index[0]);
                    array[index[0]] = new List<int>() { indice };
                    numToPurge = indice;
                }
                PurgeArray(numToPurge);
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Permet de selectionner plus ou moins aleatoirement un chiffre dans la case cibler
        /// </summary>
        /// <param name="num">index d'une case du tableau d'inddices</param>
        /// <returns>le chiffre choisit par la fonction</returns>
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
        /// <summary>
        /// Permet de verifier si la purge est possible sur toute la rangee d'indices
        /// </summary>
        /// <returns>True si la purge c'est bien passé</returns>
        public bool PurgeCheck()
        {
            bool checkPurgeOK = true;
            int compteur = 10;
            while (checkPurgeOK && compteur > 0)
            {
                checkPurgeOK = false;
                Reset();
                ItterationInit();
                foreach (List<int> i in array)
                {
                    if (i.Count == 1 && itteration[i[0]] > 1)
                    {
                        PurgeArray(i[0]);
                        checkPurgeOK = true;
                    }
                }
                compteur--;
            }
            return !checkPurgeOK;
        }
        /// <summary>
        /// Permet d'initialiser (mettre a jours) la liste d'itteration des chiffre de la liste d'indices
        /// </summary>
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
        /// <summary>
        /// Permet de Purger un chiffre de la liste d'indice
        /// </summary>
        /// <param name="nb">chiffre a purger de la case</param>
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
        /// <summary>
        /// Permet la remise a plat de l'instance avant un nouveau tour de boucle
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

            min = int.MaxValue;
            itterationMin = int.MaxValue;
            index = new List<int>();
        }
        /// <summary>
        /// Verifie la presence de chaque chiffre de 1 a 9 dans la rangee
        /// Si chaque chiffre est present 1 fois, alors la rangee est resolu
        /// </summary>
        /// <returns>Renvoir true si la somme des itteration est egale a 9</returns>
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="random"></param>
        /// <returns></returns>
        public int[] Resolve(bool random = false)
        {
            int compteur = 0;
            while (!ItterationBool() && compteur < 9)
            {
                Min();
                IndexInit();
                ItterationMinIndex();
                ReduceIndex();
                CiblerIndex();
                if (RandomizeChoice(random))
                {
                    if (PurgeCheck())
                    {
                        Reset();
                        compteur++;
                    }
                    else
                    {
                        compteur=int.MaxValue;
                    }
                }
                else
                {
                    compteur = int.MaxValue;
                }
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

        public void EditArray(List<List<int>> _array)
        {
            array = _array;
            Reset();
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
        public override string ToString()
        {
            string result = "";
            result = $"{ShowIn(array[0])} - {ShowIn(array[1])} - {ShowIn(array[2])} | {ShowIn(array[3])} - {ShowIn(array[4])} - {ShowIn(array[5])} | {ShowIn(array[6])} - {ShowIn(array[7])} - {ShowIn(array[8])}";
            return result;
        }
    }

}
