using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuGrille
{
    public class Ligne
    {
        public List<Case> Cases { get; set; }
        public Dictionary<int, int> Itteration;
        public Ligne(List<Case> _cases)
        {
            Cases = _cases;
            ItterationInitialisation();
        }
        public Ligne():this(new List<Case>() {new Case(), new Case() , new Case(), new Case(), new Case(), new Case(), new Case(), new Case(), new Case() })
        {
            
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
                    if (c != 0)
                        Itteration[c]++;
                }
            }
        }
        public int CompterItterationLigne()
        {
            int total = 0;
            ItterationInitialisation();
            CompterItteration();
            foreach (KeyValuePair<int, int> i in Itteration)
            {
                total += i.Value;
            }
            return total;
        }
        public bool VerifierLigneComplette()
        {
            CompterItteration();
            foreach (Case ca in Cases)
            {
                if (ca.Contenu.Count == 0)
                {
                    return false;
                }
            }
            return true;
        }
        public bool VerifierDoublon(Case _case, int _chiffre)
        {
            /*            CompterItteration();
                        if (Itteration[_chiffre]>1)
                        {
                            return true;
                        }
                        return false;*/
            foreach (Case ca in Cases)
            {
                if (ca != _case && ca.Contenu.Count == 1 && ca.Contenu.Contains(_chiffre))
                {
                    return true;
                }
            }
            return false;
        }

        public void PurgerLigne(Case _case, int _chiffre, Grille _grille)
        {
            foreach (Case ca in Cases)
            {
                if (ca != _case && ca.Contenu.Contains(_chiffre))
                {
                    ca.Contenu.Remove(_chiffre);
                    _grille.PurgeRecomencer = true;
                }
            }
        }
        public void PurgerLigne(Case _case, int _chiffre)
        {
            foreach (Case ca in Cases)
            {
                if (ca != _case && ca.Contenu.Contains(_chiffre))
                {
                    ca.PurgerCase(_chiffre);
                }
            }
        }
        public bool VerifierPossibiliterPlacement(Case _case, int _chiffre)
        {
            CompterItteration();
            if (Itteration[_chiffre] > 1)
            {
                return true;
            }
            return false;
        }
        public bool VerifierLigneValide()
        {
            foreach (Case ca1 in Cases)
            {
                foreach (Case ca2 in Cases)
                {
                    if (ca1 != ca2 && ca1.Contenu.Count == 1)
                    {
                        if (ca1.Contenu[0] == ca2.Contenu[0])
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
    }
}
