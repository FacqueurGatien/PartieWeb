using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grilles.Models
{
    public class Ligne
    {
/*        public int id { get;  }*/
        public List<Case> cases { get; set; }

        public Ligne(/*int _id, */List<SudokuGrille.Case> _cases)
        {
/*            id = _id;
            int idCase = (_id * 9 - 9)+1;*/
            cases = new List<Case>();
            foreach (SudokuGrille.Case item in _cases)
            {
                cases.Add(new Case(/*idCase++,*/item));
            }
        }
    }
}
