using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuGrille
{
    public class Case
    {
        public List<int> Contenu { get; set; }
        public int NumRangee { get; set; }
        public int NumColonne { get; set; }
        public int NumBlock { get; set; }
        public int NumPositionRangee { get; set; }
        public Case():this(new List<int>())
        {
        }
        public Case(int _chiffre):this(new List<int>() {_chiffre})
        {
        }
        public Case(List<int> _Indices)
        {
            Contenu= _Indices;
        }
        public Case(Case _case) : this(new List<int>(_case.Contenu))
        {
        }

        public void PlacerChiffre(int _chiffre)
        {
            Contenu.Clear();
            Contenu.Add(_chiffre);
        }
        public void PlacerChiffre()
        {
            Contenu.Clear();
        }
        public void PlacerIndices(List<int> _indices)
        {
            Contenu.Clear();
            Contenu.AddRange(_indices);
        }
        public bool PurgerCase(int _chiffre)
        {
            if (Contenu.Count > 1 && Contenu.Contains(_chiffre))
            {
                Contenu.Remove(_chiffre);
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            string result = "";
            foreach (int i in Contenu)
            {
                result += i.ToString() + ",";
            }
            result.Trim(',');
            return result;
        }
    }
}
