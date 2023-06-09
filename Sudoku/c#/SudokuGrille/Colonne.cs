using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuGrille
{
    public class Colonne
    {
        public Case[] Cases { get; set; }
        public Colonne(Case[] _cases)
        {
            Cases= _cases;
        }
    }
}
