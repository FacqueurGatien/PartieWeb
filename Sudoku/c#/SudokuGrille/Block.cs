using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuGrille
{
    public class Block
    {
        public Case[] Cases { get; set; }
        public Block(Case[] _cases)
        {
            Cases= _cases;
        }
    }
}
