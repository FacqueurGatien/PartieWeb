using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuGrille
{
    public static class ItterationGrille
    {

        public static Dictionary<int, int> Itteration { get => itteration; }
        private static Dictionary<int, int> itteration;

        public static void ItterationInitialisation()
        {
            itteration = new Dictionary<int, int>()
            {
                {1,0},
                {2,0},
                {3,0},
                {4,0},
                {5,0},
                {6,0},
                {7,0},
                {8,0},
                {9,0}
            };
        }
        public static void CompterItteration(Ligne _cases)
        {
            ItterationInitialisation();
            foreach (Case ca in _cases.Cases)
            {
                foreach (int c in ca.Contenu)
                {
                    if (c != 0)
                        Itteration[c]++;
                }
            }
        }
        public static int CompterItterationLigne(Ligne _cases)
        {
            int total = 0;
            ItterationInitialisation();
            CompterItteration(_cases);
            foreach (KeyValuePair<int, int> i in Itteration)
            {
                total += i.Value;
            }
            return total;
        }
    }
}
