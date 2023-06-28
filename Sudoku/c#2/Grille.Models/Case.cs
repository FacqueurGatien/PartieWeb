using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grilles.Models
{
    public class Case
    {
/*        public int id { get;  }*/
        public int contenu { get; set; }
        public int num_Rangee { get; set; }
        public int num_Colonne { get; set; }
        public int num_Block { get; set; }

        public Case(/*int _id,*/SudokuGrille.Case _case)
        {
/*            id = _id;*/
            contenu= _case.Contenu[0];
            num_Rangee= _case.NumRangee;
            num_Colonne= _case.NumColonne;
            num_Block= _case.NumBlock;
        }
    }
}
