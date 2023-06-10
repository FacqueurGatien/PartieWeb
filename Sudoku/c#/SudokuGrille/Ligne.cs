using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuGrille
{
    public abstract class Ligne
    {
        public Case[] Cases { get; set; }
        public Dictionary<int,int> Itteration;
        public Ligne(Case[] _cases)
        {
            Cases = _cases;
            ItterationInitialisation();
        }
        public void ItterationInitialisation()
        {
            Itteration = new Dictionary<int, int>()
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
        public void CompterItteration()
        {
            ItterationInitialisation();
            foreach (Case ca in Cases)
            {
                foreach (int c in ca.Contenu)
                {
                    if (c!=0)
                        Itteration[c]++;
                }
            }
        }
        public bool LigneComplette()
        {
            CompterItteration();
            foreach (KeyValuePair<int,int> i in Itteration)
            {
                if (i.Value!=1)
                {
                    return false;
                }
            }
            return true;
        }
        public bool VerifierDoublon(Case _case, int _chiffre)
        {
            CompterItteration();
            if (Itteration[_chiffre]<2)
            {
                return true;
            }
            return false;
        }

    }
}
