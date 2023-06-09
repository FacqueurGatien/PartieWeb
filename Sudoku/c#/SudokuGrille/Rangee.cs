using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuGrille
{
    public class Rangee
    {
        public Case[] Cases { get; set; }
        public Rangee(Case[] _cases)
        {
            Cases = _cases;
        }
    }
}
