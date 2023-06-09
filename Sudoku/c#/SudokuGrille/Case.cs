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

        public Case()
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

        public override string ToString()
        {
            string result = "";
            foreach (int i in Contenu)
            {
                result += i.ToString()+",";
            }
            result.Trim(',');
            return result;
        }
    }
}
