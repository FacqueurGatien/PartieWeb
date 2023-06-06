using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace sudokuFonction
{
    public enum EnumLine
    {
        Row,
        Column,
        Block
    }
    public class GridInit
    {
        public int[,,,] grid;
        public int essaie;

        public GridInit()
        {
            grid = new int[3, 3, 3, 3];
            DisposingArray();
            essaie = 0;
        }

        /// <summary>
        /// Dispose un tableau a personalisé
        /// </summary>
        public void DisposingArray()
        {  //    rb r cb  c

            //Rangé 1
            grid[0, 0, 0, 0] = 0;
            grid[0, 0, 0, 1] = 0;
            grid[0, 0, 0, 2] = 0;

            grid[0, 0, 1, 0] = 0;
            grid[0, 0, 1, 1] = 0;
            grid[0, 0, 1, 2] = 0;

            grid[0, 0, 2, 0] = 0;
            grid[0, 0, 2, 1] = 0;
            grid[0, 0, 2, 2] = 0;

            //Rangé2
            grid[0, 1, 0, 0] = 0;
            grid[0, 1, 0, 1] = 0;
            grid[0, 1, 0, 2] = 0;

            grid[0, 1, 1, 0] = 0;
            grid[0, 1, 1, 1] = 0;
            grid[0, 1, 1, 2] = 0;

            grid[0, 1, 2, 0] = 0;
            grid[0, 1, 2, 1] = 0;
            grid[0, 1, 2, 2] = 0;

            //Rangé3
            grid[0, 2, 0, 0] = 0;
            grid[0, 2, 0, 1] = 0;
            grid[0, 2, 0, 2] = 0;

            grid[0, 2, 1, 0] = 0;
            grid[0, 2, 1, 1] = 0;
            grid[0, 2, 1, 2] = 0;

            grid[0, 2, 2, 0] = 0;
            grid[0, 2, 2, 1] = 0;
            grid[0, 2, 2, 2] = 0;

            //Rangé 4
            grid[1, 0, 0, 0] = 0;
            grid[1, 0, 0, 1] = 0;
            grid[1, 0, 0, 2] = 0;

            grid[1, 0, 1, 0] = 0;
            grid[1, 0, 1, 1] = 0;
            grid[1, 0, 1, 2] = 0;

            grid[1, 0, 2, 0] = 0;
            grid[1, 0, 2, 1] = 0;
            grid[1, 0, 2, 2] = 0;

            //Rangé5
            grid[1, 1, 0, 0] = 0;
            grid[1, 1, 0, 1] = 0;
            grid[1, 1, 0, 2] = 0;

            grid[1, 1, 1, 0] = 0;
            grid[1, 1, 1, 1] = 0;
            grid[1, 1, 1, 2] = 0;

            grid[1, 1, 2, 0] = 0;
            grid[1, 1, 2, 1] = 0;
            grid[1, 1, 2, 2] = 0;

            //Rangé6
            grid[1, 2, 0, 0] = 0;
            grid[1, 2, 0, 1] = 0;
            grid[1, 2, 0, 2] = 0;

            grid[1, 2, 1, 0] = 0;
            grid[1, 2, 1, 1] = 0;
            grid[1, 2, 1, 2] = 0;

            grid[1, 2, 2, 0] = 0;
            grid[1, 2, 2, 1] = 0;
            grid[1, 2, 2, 2] = 0;

            //Rangé 7
            grid[2, 0, 0, 0] = 0;
            grid[2, 0, 0, 1] = 0;
            grid[2, 0, 0, 2] = 0;

            grid[2, 0, 1, 0] = 0;
            grid[2, 0, 1, 1] = 0;
            grid[2, 0, 1, 2] = 0;

            grid[2, 0, 2, 0] = 0;
            grid[2, 0, 2, 1] = 0;
            grid[2, 0, 2, 2] = 0;

            //Rangé8
            grid[2, 1, 0, 0] = 0;
            grid[2, 1, 0, 1] = 0;
            grid[2, 1, 0, 2] = 0;

            grid[2, 1, 1, 0] = 0;
            grid[2, 1, 1, 1] = 0;
            grid[2, 1, 1, 2] = 0;

            grid[2, 1, 2, 0] = 0;
            grid[2, 1, 2, 1] = 0;
            grid[2, 1, 2, 2] = 0;

            //Rangé9
            grid[2, 2, 0, 0] = 0;
            grid[2, 2, 0, 1] = 0;
            grid[2, 2, 0, 2] = 0;

            grid[2, 2, 1, 0] = 0;
            grid[2, 2, 1, 1] = 0;
            grid[2, 2, 1, 2] = 0;

            grid[2, 2, 2, 0] = 0;
            grid[2, 2, 2, 1] = 0;
            grid[2, 2, 2, 2] = 0;
        } //OK
        public void DisposingArray1()
        {  //    rb r cb  c

            //Rangé 1
            grid[0, 0, 0, 0] = 1;
            grid[0, 0, 0, 1] = 0;
            grid[0, 0, 0, 2] = 0;

            grid[0, 0, 1, 0] = 0;
            grid[0, 0, 1, 1] = 0;
            grid[0, 0, 1, 2] = 0;

            grid[0, 0, 2, 0] = 0;
            grid[0, 0, 2, 1] = 0;
            grid[0, 0, 2, 2] = 7;

            //Rangé2
            grid[0, 1, 0, 0] = 0;
            grid[0, 1, 0, 1] = 9;
            grid[0, 1, 0, 2] = 0;

            grid[0, 1, 1, 0] = 0;
            grid[0, 1, 1, 1] = 0;
            grid[0, 1, 1, 2] = 0;

            grid[0, 1, 2, 0] = 0;
            grid[0, 1, 2, 1] = 2;
            grid[0, 1, 2, 2] = 0;

            //Rangé3
            grid[0, 2, 0, 0] = 4;
            grid[0, 2, 0, 1] = 0;
            grid[0, 2, 0, 2] = 0;

            grid[0, 2, 1, 0] = 9;
            grid[0, 2, 1, 1] = 0;
            grid[0, 2, 1, 2] = 1;

            grid[0, 2, 2, 0] = 8;
            grid[0, 2, 2, 1] = 0;
            grid[0, 2, 2, 2] = 0;

            //Rangé 4
            grid[1, 0, 0, 0] = 0;
            grid[1, 0, 0, 1] = 0;
            grid[1, 0, 0, 2] = 0;

            grid[1, 0, 1, 0] = 0;
            grid[1, 0, 1, 1] = 0;
            grid[1, 0, 1, 2] = 0;

            grid[1, 0, 2, 0] = 0;
            grid[1, 0, 2, 1] = 0;
            grid[1, 0, 2, 2] = 0;

            //Rangé5
            grid[1, 1, 0, 0] = 5;
            grid[1, 1, 0, 1] = 0;
            grid[1, 1, 0, 2] = 0;

            grid[1, 1, 1, 0] = 0;
            grid[1, 1, 1, 1] = 0;
            grid[1, 1, 1, 2] = 2;

            grid[1, 1, 2, 0] = 0;
            grid[1, 1, 2, 1] = 9;
            grid[1, 1, 2, 2] = 8;

            //Rangé6
            grid[1, 2, 0, 0] = 0;
            grid[1, 2, 0, 1] = 0;
            grid[1, 2, 0, 2] = 2;

            grid[1, 2, 1, 0] = 1;
            grid[1, 2, 1, 1] = 0;
            grid[1, 2, 1, 2] = 0;

            grid[1, 2, 2, 0] = 6;
            grid[1, 2, 2, 1] = 0;
            grid[1, 2, 2, 2] = 0;

            //Rangé 7
            grid[2, 0, 0, 0] = 0;
            grid[2, 0, 0, 1] = 0;
            grid[2, 0, 0, 2] = 0;

            grid[2, 0, 1, 0] = 0;
            grid[2, 0, 1, 1] = 0;
            grid[2, 0, 1, 2] = 0;

            grid[2, 0, 2, 0] = 0;
            grid[2, 0, 2, 1] = 6;
            grid[2, 0, 2, 2] = 0;

            //Rangé8
            grid[2, 1, 0, 0] = 0;
            grid[2, 1, 0, 1] = 3;
            grid[2, 1, 0, 2] = 4;

            grid[2, 1, 1, 0] = 0;
            grid[2, 1, 1, 1] = 0;
            grid[2, 1, 1, 2] = 7;

            grid[2, 1, 2, 0] = 0;
            grid[2, 1, 2, 1] = 5;
            grid[2, 1, 2, 2] = 1;

            //Rangé9
            grid[2, 2, 0, 0] = 0;
            grid[2, 2, 0, 1] = 7;
            grid[2, 2, 0, 2] = 0;

            grid[2, 2, 1, 0] = 6;
            grid[2, 2, 1, 1] = 5;
            grid[2, 2, 1, 2] = 0;

            grid[2, 2, 2, 0] = 4;
            grid[2, 2, 2, 1] = 0;
            grid[2, 2, 2, 2] = 0;
        } //OK
        public void DisposingArray2()
        {  //    rb r cb  c

            //Rangé 1
            grid[0, 0, 0, 0] = 0;
            grid[0, 0, 0, 1] = 5;
            grid[0, 0, 0, 2] = 7;

            grid[0, 0, 1, 0] = 0;
            grid[0, 0, 1, 1] = 2;
            grid[0, 0, 1, 2] = 0;

            grid[0, 0, 2, 0] = 0;
            grid[0, 0, 2, 1] = 0;
            grid[0, 0, 2, 2] = 0;

            //Rangé2
            grid[0, 1, 0, 0] = 0;
            grid[0, 1, 0, 1] = 0;
            grid[0, 1, 0, 2] = 0;

            grid[0, 1, 1, 0] = 0;
            grid[0, 1, 1, 1] = 0;
            grid[0, 1, 1, 2] = 5;

            grid[0, 1, 2, 0] = 0;
            grid[0, 1, 2, 1] = 0;
            grid[0, 1, 2, 2] = 1;

            //Rangé3
            grid[0, 2, 0, 0] = 0;
            grid[0, 2, 0, 1] = 0;
            grid[0, 2, 0, 2] = 0;

            grid[0, 2, 1, 0] = 7;
            grid[0, 2, 1, 1] = 1;
            grid[0, 2, 1, 2] = 0;

            grid[0, 2, 2, 0] = 8;
            grid[0, 2, 2, 1] = 0;
            grid[0, 2, 2, 2] = 9;

            //Rangé 4
            grid[1, 0, 0, 0] = 0;
            grid[1, 0, 0, 1] = 0;
            grid[1, 0, 0, 2] = 0;

            grid[1, 0, 1, 0] = 0;
            grid[1, 0, 1, 1] = 0;
            grid[1, 0, 1, 2] = 0;

            grid[1, 0, 2, 0] = 0;
            grid[1, 0, 2, 1] = 0;
            grid[1, 0, 2, 2] = 0;

            //Rangé5
            grid[1, 1, 0, 0] = 0;
            grid[1, 1, 0, 1] = 6;
            grid[1, 1, 0, 2] = 0;

            grid[1, 1, 1, 0] = 8;
            grid[1, 1, 1, 1] = 0;
            grid[1, 1, 1, 2] = 2;

            grid[1, 1, 2, 0] = 0;
            grid[1, 1, 2, 1] = 1;
            grid[1, 1, 2, 2] = 0;

            //Rangé6
            grid[1, 2, 0, 0] = 0;
            grid[1, 2, 0, 1] = 0;
            grid[1, 2, 0, 2] = 0;

            grid[1, 2, 1, 0] = 0;
            grid[1, 2, 1, 1] = 7;
            grid[1, 2, 1, 2] = 0;

            grid[1, 2, 2, 0] = 9;
            grid[1, 2, 2, 1] = 0;
            grid[1, 2, 2, 2] = 0;

            //Rangé 7
            grid[2, 0, 0, 0] = 0;
            grid[2, 0, 0, 1] = 9;
            grid[2, 0, 0, 2] = 0;

            grid[2, 0, 1, 0] = 0;
            grid[2, 0, 1, 1] = 0;
            grid[2, 0, 1, 2] = 0;

            grid[2, 0, 2, 0] = 0;
            grid[2, 0, 2, 1] = 2;
            grid[2, 0, 2, 2] = 4;

            //Rangé8
            grid[2, 1, 0, 0] = 0;
            grid[2, 1, 0, 1] = 8;
            grid[2, 1, 0, 2] = 0;

            grid[2, 1, 1, 0] = 0;
            grid[2, 1, 1, 1] = 0;
            grid[2, 1, 1, 2] = 0;

            grid[2, 1, 2, 0] = 0;
            grid[2, 1, 2, 1] = 0;
            grid[2, 1, 2, 2] = 6;

            //Rangé9
            grid[2, 2, 0, 0] = 6;
            grid[2, 2, 0, 1] = 4;
            grid[2, 2, 0, 2] = 3;

            grid[2, 2, 1, 0] = 0;
            grid[2, 2, 1, 1] = 0;
            grid[2, 2, 1, 2] = 1;

            grid[2, 2, 2, 0] = 0;
            grid[2, 2, 2, 1] = 0;
            grid[2, 2, 2, 2] = 8;
        } //OK
        /// <summary>
        /// Dispose un tableau vierge
        /// </summary>
        public void DisposingArray3()
        {  //    rb r cb  c

            //Rangé 1
            grid[0, 0, 0, 0] = 0;
            grid[0, 0, 0, 1] = 0;
            grid[0, 0, 0, 2] = 2;

            grid[0, 0, 1, 0] = 7;
            grid[0, 0, 1, 1] = 0;
            grid[0, 0, 1, 2] = 0;

            grid[0, 0, 2, 0] = 0;
            grid[0, 0, 2, 1] = 0;
            grid[0, 0, 2, 2] = 0;

            //Rangé2
            grid[0, 1, 0, 0] = 0;
            grid[0, 1, 0, 1] = 8;
            grid[0, 1, 0, 2] = 9;

            grid[0, 1, 1, 0] = 0;
            grid[0, 1, 1, 1] = 0;
            grid[0, 1, 1, 2] = 0;

            grid[0, 1, 2, 0] = 0;
            grid[0, 1, 2, 1] = 0;
            grid[0, 1, 2, 2] = 1;

            //Rangé3
            grid[0, 2, 0, 0] = 5;
            grid[0, 2, 0, 1] = 0;
            grid[0, 2, 0, 2] = 0;

            grid[0, 2, 1, 0] = 0;
            grid[0, 2, 1, 1] = 0;
            grid[0, 2, 1, 2] = 0;

            grid[0, 2, 2, 0] = 0;
            grid[0, 2, 2, 1] = 0;
            grid[0, 2, 2, 2] = 0;

            //Rangé 4
            grid[1, 0, 0, 0] = 0;
            grid[1, 0, 0, 1] = 0;
            grid[1, 0, 0, 2] = 0;

            grid[1, 0, 1, 0] = 2;
            grid[1, 0, 1, 1] = 0;
            grid[1, 0, 1, 2] = 0;

            grid[1, 0, 2, 0] = 8;
            grid[1, 0, 2, 1] = 0;
            grid[1, 0, 2, 2] = 6;

            //Rangé5
            grid[1, 1, 0, 0] = 0;
            grid[1, 1, 0, 1] = 0;
            grid[1, 1, 0, 2] = 0;

            grid[1, 1, 1, 0] = 0;
            grid[1, 1, 1, 1] = 9;
            grid[1, 1, 1, 2] = 7;

            grid[1, 1, 2, 0] = 0;
            grid[1, 1, 2, 1] = 0;
            grid[1, 1, 2, 2] = 0;

            //Rangé6
            grid[1, 2, 0, 0] = 0;
            grid[1, 2, 0, 1] = 0;
            grid[1, 2, 0, 2] = 0;

            grid[1, 2, 1, 0] = 0;
            grid[1, 2, 1, 1] = 0;
            grid[1, 2, 1, 2] = 4;

            grid[1, 2, 2, 0] = 7;
            grid[1, 2, 2, 1] = 1;
            grid[1, 2, 2, 2] = 0;

            //Rangé 7
            grid[2, 0, 0, 0] = 0;
            grid[2, 0, 0, 1] = 2;
            grid[2, 0, 0, 2] = 6;

            grid[2, 0, 1, 0] = 3;
            grid[2, 0, 1, 1] = 0;
            grid[2, 0, 1, 2] = 0;

            grid[2, 0, 2, 0] = 0;
            grid[2, 0, 2, 1] = 5;
            grid[2, 0, 2, 2] = 0;

            //Rangé8
            grid[2, 1, 0, 0] = 3;
            grid[2, 1, 0, 1] = 0;
            grid[2, 1, 0, 2] = 0;

            grid[2, 1, 1, 0] = 0;
            grid[2, 1, 1, 1] = 8;
            grid[2, 1, 1, 2] = 0;

            grid[2, 1, 2, 0] = 0;
            grid[2, 1, 2, 1] = 4;
            grid[2, 1, 2, 2] = 9;

            //Rangé9
            grid[2, 2, 0, 0] = 0;
            grid[2, 2, 0, 1] = 9;
            grid[2, 2, 0, 2] = 0;

            grid[2, 2, 1, 0] = 0;
            grid[2, 2, 1, 1] = 5;
            grid[2, 2, 1, 2] = 0;

            grid[2, 2, 2, 0] = 0;
            grid[2, 2, 2, 1] = 2;
            grid[2, 2, 2, 2] = 0;
        } //OK
        public void DisposingArray4()
        {  //    rb r cb  c

            //Rangé 1
            grid[0, 0, 0, 0] = 3;
            grid[0, 0, 0, 1] = 8;
            grid[0, 0, 0, 2] = 0;

            grid[0, 0, 1, 0] = 7;
            grid[0, 0, 1, 1] = 0;
            grid[0, 0, 1, 2] = 0;

            grid[0, 0, 2, 0] = 2;
            grid[0, 0, 2, 1] = 6;
            grid[0, 0, 2, 2] = 0;

            //Rangé2
            grid[0, 1, 0, 0] = 0;
            grid[0, 1, 0, 1] = 0;
            grid[0, 1, 0, 2] = 0;

            grid[0, 1, 1, 0] = 0;
            grid[0, 1, 1, 1] = 0;
            grid[0, 1, 1, 2] = 8;

            grid[0, 1, 2, 0] = 0;
            grid[0, 1, 2, 1] = 7;
            grid[0, 1, 2, 2] = 1;

            //Rangé3
            grid[0, 2, 0, 0] = 0;
            grid[0, 2, 0, 1] = 9;
            grid[0, 2, 0, 2] = 0;

            grid[0, 2, 1, 0] = 0;
            grid[0, 2, 1, 1] = 0;
            grid[0, 2, 1, 2] = 0;

            grid[0, 2, 2, 0] = 3;
            grid[0, 2, 2, 1] = 8;
            grid[0, 2, 2, 2] = 4;

            //Rangé 4
            grid[1, 0, 0, 0] = 1;
            grid[1, 0, 0, 1] = 0;
            grid[1, 0, 0, 2] = 0;

            grid[1, 0, 1, 0] = 0;
            grid[1, 0, 1, 1] = 0;
            grid[1, 0, 1, 2] = 0;

            grid[1, 0, 2, 0] = 0;
            grid[1, 0, 2, 1] = 5;
            grid[1, 0, 2, 2] = 0;

            //Rangé5
            grid[1, 1, 0, 0] = 4;
            grid[1, 1, 0, 1] = 7;
            grid[1, 1, 0, 2] = 0;

            grid[1, 1, 1, 0] = 0;
            grid[1, 1, 1, 1] = 8;
            grid[1, 1, 1, 2] = 0;

            grid[1, 1, 2, 0] = 0;
            grid[1, 1, 2, 1] = 0;
            grid[1, 1, 2, 2] = 0;

            //Rangé6
            grid[1, 2, 0, 0] = 8;
            grid[1, 2, 0, 1] = 0;
            grid[1, 2, 0, 2] = 0;

            grid[1, 2, 1, 0] = 0;
            grid[1, 2, 1, 1] = 0;
            grid[1, 2, 1, 2] = 6;

            grid[1, 2, 2, 0] = 0;
            grid[1, 2, 2, 1] = 0;
            grid[1, 2, 2, 2] = 3;

            //Rangé 7
            grid[2, 0, 0, 0] = 0;
            grid[2, 0, 0, 1] = 0;
            grid[2, 0, 0, 2] = 0;

            grid[2, 0, 1, 0] = 9;
            grid[2, 0, 1, 1] = 4;
            grid[2, 0, 1, 2] = 0;

            grid[2, 0, 2, 0] = 0;
            grid[2, 0, 2, 1] = 0;
            grid[2, 0, 2, 2] = 0;

            //Rangé8
            grid[2, 1, 0, 0] = 5;
            grid[2, 1, 0, 1] = 0;//
            grid[2, 1, 0, 2] = 0;

            grid[2, 1, 1, 0] = 8;
            grid[2, 1, 1, 1] = 6;
            grid[2, 1, 1, 2] = 0;

            grid[2, 1, 2, 0] = 0;
            grid[2, 1, 2, 1] = 0;
            grid[2, 1, 2, 2] = 0;

            //Rangé9
            grid[2, 2, 0, 0] = 0;
            grid[2, 2, 0, 1] = 0;
            grid[2, 2, 0, 2] = 0;

            grid[2, 2, 1, 0] = 0;
            grid[2, 2, 1, 1] = 5;
            grid[2, 2, 1, 2] = 1;

            grid[2, 2, 2, 0] = 0;
            grid[2, 2, 2, 1] = 0;
            grid[2, 2, 2, 2] = 0;
        } //OK Algo2
        public void DisposingArray5()
        {  //    rb r cb  c

            //Rangé 1
            grid[0, 0, 0, 0] = 0;
            grid[0, 0, 0, 1] = 2;
            grid[0, 0, 0, 2] = 1;

            grid[0, 0, 1, 0] = 0;
            grid[0, 0, 1, 1] = 9;
            grid[0, 0, 1, 2] = 0;

            grid[0, 0, 2, 0] = 0;
            grid[0, 0, 2, 1] = 0;
            grid[0, 0, 2, 2] = 0;

            //Rangé2
            grid[0, 1, 0, 0] = 0;
            grid[0, 1, 0, 1] = 7;
            grid[0, 1, 0, 2] = 0;

            grid[0, 1, 1, 0] = 0;
            grid[0, 1, 1, 1] = 2;
            grid[0, 1, 1, 2] = 5;

            grid[0, 1, 2, 0] = 0;
            grid[0, 1, 2, 1] = 0;
            grid[0, 1, 2, 2] = 6;

            //Rangé3
            grid[0, 2, 0, 0] = 0;
            grid[0, 2, 0, 1] = 0;
            grid[0, 2, 0, 2] = 0;

            grid[0, 2, 1, 0] = 0;
            grid[0, 2, 1, 1] = 0;
            grid[0, 2, 1, 2] = 0;

            grid[0, 2, 2, 0] = 7;
            grid[0, 2, 2, 1] = 9;
            grid[0, 2, 2, 2] = 0;

            //Rangé 4
            grid[1, 0, 0, 0] = 0;
            grid[1, 0, 0, 1] = 0;
            grid[1, 0, 0, 2] = 5;

            grid[1, 0, 1, 0] = 0;
            grid[1, 0, 1, 1] = 0;
            grid[1, 0, 1, 2] = 0;

            grid[1, 0, 2, 0] = 0;
            grid[1, 0, 2, 1] = 0;
            grid[1, 0, 2, 2] = 1;

            //Rangé5
            grid[1, 1, 0, 0] = 0;
            grid[1, 1, 0, 1] = 0;
            grid[1, 1, 0, 2] = 0;

            grid[1, 1, 1, 0] = 0;
            grid[1, 1, 1, 1] = 0;
            grid[1, 1, 1, 2] = 8;

            grid[1, 1, 2, 0] = 5;
            grid[1, 1, 2, 1] = 4;
            grid[1, 1, 2, 2] = 0;

            //Rangé6
            grid[1, 2, 0, 0] = 8;
            grid[1, 2, 0, 1] = 1;
            grid[1, 2, 0, 2] = 0;

            grid[1, 2, 1, 0] = 0;
            grid[1, 2, 1, 1] = 0;
            grid[1, 2, 1, 2] = 0;

            grid[1, 2, 2, 0] = 0;
            grid[1, 2, 2, 1] = 0;
            grid[1, 2, 2, 2] = 0;

            //Rangé 7
            grid[2, 0, 0, 0] = 0;
            grid[2, 0, 0, 1] = 0;
            grid[2, 0, 0, 2] = 0;

            grid[2, 0, 1, 0] = 3;
            grid[2, 0, 1, 1] = 0;
            grid[2, 0, 1, 2] = 0;

            grid[2, 0, 2, 0] = 4;
            grid[2, 0, 2, 1] = 0;
            grid[2, 0, 2, 2] = 0;

            //Rangé8
            grid[2, 1, 0, 0] = 6;
            grid[2, 1, 0, 1] = 8;//
            grid[2, 1, 0, 2] = 0;

            grid[2, 1, 1, 0] = 0;
            grid[2, 1, 1, 1] = 0;
            grid[2, 1, 1, 2] = 0;

            grid[2, 1, 2, 0] = 0;
            grid[2, 1, 2, 1] = 0;
            grid[2, 1, 2, 2] = 0;

            //Rangé9
            grid[2, 2, 0, 0] = 2;
            grid[2, 2, 0, 1] = 4;
            grid[2, 2, 0, 2] = 9;

            grid[2, 2, 1, 0] = 0;
            grid[2, 2, 1, 1] = 0;
            grid[2, 2, 1, 2] = 0;

            grid[2, 2, 2, 0] = 6;
            grid[2, 2, 2, 1] = 0;
            grid[2, 2, 2, 2] = 8;
        } //OK
        public void DisposingArray6() 
        {  //    rb r cb  c

            //Rangé 1
            grid[0, 0, 0, 0] = 0;
            grid[0, 0, 0, 1] = 0;
            grid[0, 0, 0, 2] = 0;

            grid[0, 0, 1, 0] = 0;
            grid[0, 0, 1, 1] = 0;
            grid[0, 0, 1, 2] = 3;

            grid[0, 0, 2, 0] = 9;
            grid[0, 0, 2, 1] = 0;
            grid[0, 0, 2, 2] = 0;

            //Rangé2
            grid[0, 1, 0, 0] = 9;
            grid[0, 1, 0, 1] = 6;
            grid[0, 1, 0, 2] = 0;

            grid[0, 1, 1, 0] = 0;
            grid[0, 1, 1, 1] = 2;
            grid[0, 1, 1, 2] = 0;

            grid[0, 1, 2, 0] = 3;
            grid[0, 1, 2, 1] = 7;
            grid[0, 1, 2, 2] = 0;

            //Rangé3
            grid[0, 2, 0, 0] = 0;
            grid[0, 2, 0, 1] = 0;
            grid[0, 2, 0, 2] = 0;

            grid[0, 2, 1, 0] = 0;
            grid[0, 2, 1, 1] = 0;
            grid[0, 2, 1, 2] = 0;

            grid[0, 2, 2, 0] = 1;
            grid[0, 2, 2, 1] = 6;
            grid[0, 2, 2, 2] = 8;

            //Rangé 4
            grid[1, 0, 0, 0] = 7;
            grid[1, 0, 0, 1] = 0;
            grid[1, 0, 0, 2] = 3;

            grid[1, 0, 1, 0] = 0;
            grid[1, 0, 1, 1] = 0;
            grid[1, 0, 1, 2] = 0;

            grid[1, 0, 2, 0] = 4;
            grid[1, 0, 2, 1] = 0;
            grid[1, 0, 2, 2] = 0;

            //Rangé5
            grid[1, 1, 0, 0] = 0;
            grid[1, 1, 0, 1] = 9;
            grid[1, 1, 0, 2] = 0;

            grid[1, 1, 1, 0] = 7;
            grid[1, 1, 1, 1] = 0;
            grid[1, 1, 1, 2] = 0;

            grid[1, 1, 2, 0] = 0;
            grid[1, 1, 2, 1] = 0;
            grid[1, 1, 2, 2] = 0;

            //Rangé6
            grid[1, 2, 0, 0] = 0;
            grid[1, 2, 0, 1] = 2;
            grid[1, 2, 0, 2] = 0;

            grid[1, 2, 1, 0] = 0;
            grid[1, 2, 1, 1] = 6;
            grid[1, 2, 1, 2] = 0;

            grid[1, 2, 2, 0] = 0;
            grid[1, 2, 2, 1] = 0;
            grid[1, 2, 2, 2] = 7;

            //Rangé 7
            grid[2, 0, 0, 0] = 0;
            grid[2, 0, 0, 1] = 0;
            grid[2, 0, 0, 2] = 0;

            grid[2, 0, 1, 0] = 0;
            grid[2, 0, 1, 1] = 3;
            grid[2, 0, 1, 2] = 8;

            grid[2, 0, 2, 0] = 6;
            grid[2, 0, 2, 1] = 0;
            grid[2, 0, 2, 2] = 0;

            //Rangé8
            grid[2, 1, 0, 0] = 0;
            grid[2, 1, 0, 1] = 0;
            grid[2, 1, 0, 2] = 8;

            grid[2, 1, 1, 0] = 0;
            grid[2, 1, 1, 1] = 0;
            grid[2, 1, 1, 2] = 0;

            grid[2, 1, 2, 0] = 0;
            grid[2, 1, 2, 1] = 0;
            grid[2, 1, 2, 2] = 4;

            //Rangé9
            grid[2, 2, 0, 0] = 0;
            grid[2, 2, 0, 1] = 0;
            grid[2, 2, 0, 2] = 4;

            grid[2, 2, 1, 0] = 0;
            grid[2, 2, 1, 1] = 0;
            grid[2, 2, 1, 2] = 2;

            grid[2, 2, 2, 0] = 0;
            grid[2, 2, 2, 1] = 0;
            grid[2, 2, 2, 2] = 0;
        } //OK
        public void DisposingArray7()
        {  //    rb r cb  c

            //Rangé 1
            grid[0, 0, 0, 0] = 0;
            grid[0, 0, 0, 1] = 0;
            grid[0, 0, 0, 2] = 0;

            grid[0, 0, 1, 0] = 5;
            grid[0, 0, 1, 1] = 0;
            grid[0, 0, 1, 2] = 1;

            grid[0, 0, 2, 0] = 0;
            grid[0, 0, 2, 1] = 0;
            grid[0, 0, 2, 2] = 0;

            //Rangé2
            grid[0, 1, 0, 0] = 0;
            grid[0, 1, 0, 1] = 0;
            grid[0, 1, 0, 2] = 0;

            grid[0, 1, 1, 0] = 0;
            grid[0, 1, 1, 1] = 4;
            grid[0, 1, 1, 2] = 3;

            grid[0, 1, 2, 0] = 0;
            grid[0, 1, 2, 1] = 0;
            grid[0, 1, 2, 2] = 8;

            //Rangé3
            grid[0, 2, 0, 0] = 1;
            grid[0, 2, 0, 1] = 0;
            grid[0, 2, 0, 2] = 0;

            grid[0, 2, 1, 0] = 0;
            grid[0, 2, 1, 1] = 8;
            grid[0, 2, 1, 2] = 2;

            grid[0, 2, 2, 0] = 0;
            grid[0, 2, 2, 1] = 5;
            grid[0, 2, 2, 2] = 0;

            //Rangé 4
            grid[1, 0, 0, 0] = 6;
            grid[1, 0, 0, 1] = 8;
            grid[1, 0, 0, 2] = 0;

            grid[1, 0, 1, 0] = 0;
            grid[1, 0, 1, 1] = 0;
            grid[1, 0, 1, 2] = 0;

            grid[1, 0, 2, 0] = 0;
            grid[1, 0, 2, 1] = 0;
            grid[1, 0, 2, 2] = 0;

            //Rangé5
            grid[1, 1, 0, 0] = 0;
            grid[1, 1, 0, 1] = 7;
            grid[1, 1, 0, 2] = 5;

            grid[1, 1, 1, 0] = 0;
            grid[1, 1, 1, 1] = 0;
            grid[1, 1, 1, 2] = 0;

            grid[1, 1, 2, 0] = 0;
            grid[1, 1, 2, 1] = 3;
            grid[1, 1, 2, 2] = 9;

            //Rangé6
            grid[1, 2, 0, 0] = 0;
            grid[1, 2, 0, 1] = 3;
            grid[1, 2, 0, 2] = 0;

            grid[1, 2, 1, 0] = 0;
            grid[1, 2, 1, 1] = 0;
            grid[1, 2, 1, 2] = 0;

            grid[1, 2, 2, 0] = 0;
            grid[1, 2, 2, 1] = 0;
            grid[1, 2, 2, 2] = 0;

            //Rangé 7
            grid[2, 0, 0, 0] = 0;
            grid[2, 0, 0, 1] = 0;
            grid[2, 0, 0, 2] = 0;

            grid[2, 0, 1, 0] = 0;
            grid[2, 0, 1, 1] = 0;
            grid[2, 0, 1, 2] = 0;

            grid[2, 0, 2, 0] = 0;
            grid[2, 0, 2, 1] = 2;
            grid[2, 0, 2, 2] = 0;

            //Rangé8
            grid[2, 1, 0, 0] = 8;
            grid[2, 1, 0, 1] = 5;
            grid[2, 1, 0, 2] = 0;

            grid[2, 1, 1, 0] = 0;
            grid[2, 1, 1, 1] = 0;
            grid[2, 1, 1, 2] = 0;

            grid[2, 1, 2, 0] = 6;
            grid[2, 1, 2, 1] = 0;
            grid[2, 1, 2, 2] = 0;

            //Rangé9
            grid[2, 2, 0, 0] = 0;
            grid[2, 2, 0, 1] = 0;
            grid[2, 2, 0, 2] = 2;

            grid[2, 2, 1, 0] = 0;
            grid[2, 2, 1, 1] = 0;
            grid[2, 2, 1, 2] = 7;

            grid[2, 2, 2, 0] = 1;
            grid[2, 2, 2, 1] = 9;
            grid[2, 2, 2, 2] = 4;
        } //OK
        /// <summary>
        /// Dispose un tableau vierge
        /// </summary>
        public void DisposingArray8()
        {  //    rb r cb  c

            //Rangé 1
            grid[0, 0, 0, 0] = 0;
            grid[0, 0, 0, 1] = 0;
            grid[0, 0, 0, 2] = 0;

            grid[0, 0, 1, 0] = 0;
            grid[0, 0, 1, 1] = 7;
            grid[0, 0, 1, 2] = 9;

            grid[0, 0, 2, 0] = 0;
            grid[0, 0, 2, 1] = 0;
            grid[0, 0, 2, 2] = 0;

            //Rangé2
            grid[0, 1, 0, 0] = 0;
            grid[0, 1, 0, 1] = 0;
            grid[0, 1, 0, 2] = 4;

            grid[0, 1, 1, 0] = 0;
            grid[0, 1, 1, 1] = 0;
            grid[0, 1, 1, 2] = 0;

            grid[0, 1, 2, 0] = 0;
            grid[0, 1, 2, 1] = 0;
            grid[0, 1, 2, 2] = 3;

            //Rangé3
            grid[0, 2, 0, 0] = 0;
            grid[0, 2, 0, 1] = 0;
            grid[0, 2, 0, 2] = 5;

            grid[0, 2, 1, 0] = 0;
            grid[0, 2, 1, 1] = 0;
            grid[0, 2, 1, 2] = 4;

            grid[0, 2, 2, 0] = 9;
            grid[0, 2, 2, 1] = 0;
            grid[0, 2, 2, 2] = 6;

            //Rangé 4
            grid[1, 0, 0, 0] = 0;
            grid[1, 0, 0, 1] = 0;
            grid[1, 0, 0, 2] = 0;

            grid[1, 0, 1, 0] = 0;
            grid[1, 0, 1, 1] = 0;
            grid[1, 0, 1, 2] = 1;

            grid[1, 0, 2, 0] = 0;
            grid[1, 0, 2, 1] = 0;
            grid[1, 0, 2, 2] = 0;

            //Rangé5
            grid[1, 1, 0, 0] = 7;
            grid[1, 1, 0, 1] = 9;
            grid[1, 1, 0, 2] = 0;

            grid[1, 1, 1, 0] = 0;
            grid[1, 1, 1, 1] = 0;
            grid[1, 1, 1, 2] = 6;

            grid[1, 1, 2, 0] = 0;
            grid[1, 1, 2, 1] = 0;
            grid[1, 1, 2, 2] = 0;

            //Rangé6
            grid[1, 2, 0, 0] = 0;
            grid[1, 2, 0, 1] = 0;
            grid[1, 2, 0, 2] = 0;

            grid[1, 2, 1, 0] = 8;
            grid[1, 2, 1, 1] = 0;
            grid[1, 2, 1, 2] = 0;

            grid[1, 2, 2, 0] = 2;
            grid[1, 2, 2, 1] = 0;
            grid[1, 2, 2, 2] = 4;

            //Rangé 7
            grid[2, 0, 0, 0] = 0;
            grid[2, 0, 0, 1] = 1;
            grid[2, 0, 0, 2] = 0;

            grid[2, 0, 1, 0] = 0;
            grid[2, 0, 1, 1] = 0;
            grid[2, 0, 1, 2] = 0;

            grid[2, 0, 2, 0] = 0;
            grid[2, 0, 2, 1] = 4;
            grid[2, 0, 2, 2] = 9;

            //Rangé8
            grid[2, 1, 0, 0] = 0;
            grid[2, 1, 0, 1] = 8;
            grid[2, 1, 0, 2] = 0;

            grid[2, 1, 1, 0] = 0;
            grid[2, 1, 1, 1] = 0;
            grid[2, 1, 1, 2] = 5;

            grid[2, 1, 2, 0] = 1;
            grid[2, 1, 2, 1] = 6;
            grid[2, 1, 2, 2] = 0;

            //Rangé9
            grid[2, 2, 0, 0] = 0;
            grid[2, 2, 0, 1] = 2;
            grid[2, 2, 0, 2] = 0;

            grid[2, 2, 1, 0] = 0;
            grid[2, 2, 1, 1] = 0;
            grid[2, 2, 1, 2] = 0;

            grid[2, 2, 2, 0] = 0;
            grid[2, 2, 2, 1] = 8;
            grid[2, 2, 2, 2] = 7;
        } //OK

        public void DisposingArray9()
        {  //    rb r cb  c

            //Rangé 1
            grid[0, 0, 0, 0] = 0;
            grid[0, 0, 0, 1] = 8;
            grid[0, 0, 0, 2] = 0;

            grid[0, 0, 1, 0] = 7;
            grid[0, 0, 1, 1] = 0;
            grid[0, 0, 1, 2] = 0;

            grid[0, 0, 2, 0] = 2;
            grid[0, 0, 2, 1] = 6;
            grid[0, 0, 2, 2] = 0;

            //Rangé2
            grid[0, 1, 0, 0] = 0;
            grid[0, 1, 0, 1] = 0;
            grid[0, 1, 0, 2] = 0;

            grid[0, 1, 1, 0] = 0;
            grid[0, 1, 1, 1] = 0;
            grid[0, 1, 1, 2] = 8;

            grid[0, 1, 2, 0] = 0;
            grid[0, 1, 2, 1] = 0;
            grid[0, 1, 2, 2] = 1;

            //Rangé3
            grid[0, 2, 0, 0] = 0;
            grid[0, 2, 0, 1] = 9;
            grid[0, 2, 0, 2] = 0;

            grid[0, 2, 1, 0] = 0;
            grid[0, 2, 1, 1] = 0;
            grid[0, 2, 1, 2] = 0;

            grid[0, 2, 2, 0] = 0;
            grid[0, 2, 2, 1] = 8;
            grid[0, 2, 2, 2] = 0;

            //Rangé 4
            grid[1, 0, 0, 0] = 1;
            grid[1, 0, 0, 1] = 0;
            grid[1, 0, 0, 2] = 0;

            grid[1, 0, 1, 0] = 0;
            grid[1, 0, 1, 1] = 0;
            grid[1, 0, 1, 2] = 0;

            grid[1, 0, 2, 0] = 0;
            grid[1, 0, 2, 1] = 5;
            grid[1, 0, 2, 2] = 0;

            //Rangé5
            grid[1, 1, 0, 0] = 0;
            grid[1, 1, 0, 1] = 7;
            grid[1, 1, 0, 2] = 0;

            grid[1, 1, 1, 0] = 0;
            grid[1, 1, 1, 1] = 8;
            grid[1, 1, 1, 2] = 0;

            grid[1, 1, 2, 0] = 0;
            grid[1, 1, 2, 1] = 0;
            grid[1, 1, 2, 2] = 0;

            //Rangé6
            grid[1, 2, 0, 0] = 8;
            grid[1, 2, 0, 1] = 0;
            grid[1, 2, 0, 2] = 0;

            grid[1, 2, 1, 0] = 0;
            grid[1, 2, 1, 1] = 0;
            grid[1, 2, 1, 2] = 6;

            grid[1, 2, 2, 0] = 0;
            grid[1, 2, 2, 1] = 0;
            grid[1, 2, 2, 2] = 3;

            //Rangé 7
            grid[2, 0, 0, 0] = 0;
            grid[2, 0, 0, 1] = 0;
            grid[2, 0, 0, 2] = 0;

            grid[2, 0, 1, 0] = 0;
            grid[2, 0, 1, 1] = 4;
            grid[2, 0, 1, 2] = 0;

            grid[2, 0, 2, 0] = 0;
            grid[2, 0, 2, 1] = 0;
            grid[2, 0, 2, 2] = 0;

            //Rangé8
            grid[2, 1, 0, 0] = 5;
            grid[2, 1, 0, 1] = 0;
            grid[2, 1, 0, 2] = 0;

            grid[2, 1, 1, 0] = 0;
            grid[2, 1, 1, 1] = 6;
            grid[2, 1, 1, 2] = 0;

            grid[2, 1, 2, 0] = 0;
            grid[2, 1, 2, 1] = 0;
            grid[2, 1, 2, 2] = 0;

            //Rangé9
            grid[2, 2, 0, 0] = 0;
            grid[2, 2, 0, 1] = 0;
            grid[2, 2, 0, 2] = 0;

            grid[2, 2, 1, 0] = 0;
            grid[2, 2, 1, 1] = 5;
            grid[2, 2, 1, 2] = 0;

            grid[2, 2, 2, 0] = 0;
            grid[2, 2, 2, 1] = 0;
            grid[2, 2, 2, 2] = 0;
        } //OK Algo2

        public override string ToString()
        {
            string res = "";
            for (int rb = 0; rb < 3; rb++)
            {
                if (rb != 0)
                {
                    res += "\n _________  _________  _________\n";
                }
                for (int r = 0; r < 3; r++)
                {
                    res += "\n _________  _________  _________\n";
                    for (int cb = 0; cb < 3; cb++)
                    {
                        res += "| ";
                        for (int c = 0; c < 3; c++)
                        {
                            res += string.Format("{0,-2}|", grid[rb, r, cb, c]);
                        }
                    }
                }
            }
            res += "\n _________  _________  _________\n";
            return res;
        }

        /// <summary>
        /// Permet de cibler une colonne une ligne ou un block
        /// </summary>
        /// <param name="cursor">Numero de ligne colonne ou block</param>
        /// <returns>Renvoie les coordonné du block/ligne/colonne</returns>
        public int[] setLine(int cursor)
        {
            switch (cursor)
            {
                case 1:
                    return new int[] { 0, 0 };
                case 2:
                    return new int[] { 0, 1 };
                case 3:
                    return new int[] { 0, 2 };
                case 4:
                    return new int[] { 1, 0 };
                case 5:
                    return new int[] { 1, 1 };
                case 6:
                    return new int[] { 1, 2 };
                case 7:
                    return new int[] { 2, 0 };
                case 8:
                    return new int[] { 2, 1 };
                case 9:
                    return new int[] { 2, 2 };
                default:
                    return null;
            }
        }
        /// <summary>
        /// permet de recuperer le numero d'une ligne colonne ou block a partir de Coordonné
        /// </summary>
        /// <param name="coord">Coordonne de la ligne colonne ou block</param>
        /// <returns>Renvoie le numero de ligne/block/colonne</returns>
        public int setCursor(int[] coord)
        {
            if (coord[0] == 0 && coord[1] == 0)
            {
                return 1;
            }
            else if (coord[0] == 0 && coord[1] == 1)
            {
                return 2;
            }
            else if (coord[0] == 0 && coord[1] == 2)
            {
                return 3;
            }
            else if (coord[0] == 1 && coord[1] == 0)
            {
                return 4;
            }
            else if (coord[0] == 1 && coord[1] == 1)
            {
                return 5;
            }
            else if (coord[0] == 1 && coord[1] == 2)
            {
                return 6;
            }
            else if (coord[0] == 2 && coord[1] == 0)
            {
                return 7;
            }
            else if (coord[0] == 2 && coord[1] == 1)
            {
                return 8;
            }
            else
            {
                return 9;
            }
        }

        /// <summary>
        /// Permet de copier une rangé a partir de son numero 
        /// </summary>
        /// <param name="numRow"></param>
        /// <returns>Renvoie un tableau avec le contenue de la rangé</returns>
        public int[] CopyRow(int numRow)
        {
            int[] rowCursor = setLine(numRow);
            int[] row = new int[9];
            int compteur = 0;
            for (int rb = rowCursor[0]; rb < rowCursor[0] + 1; rb++)
            {
                for (int r = rowCursor[1]; r < rowCursor[1] + 1; r++)
                {
                    for (int cb = 0; cb < 3; cb++)
                    {
                        for (int c = 0; c < 3; c++)
                        {
                            row[compteur++] = grid[rb, r, cb, c];
                        }
                    }
                }
            }
            return row;
        }
        /// <summary>
        /// Permet de copier une rangé a partir de ses coordonnées 
        /// </summary>
        /// <param name="numRow"></param>
        /// <returns>Renvoie un tableau avec le contenue de la rangé</returns>
        public int[] CopyRow(int[] numRow)
        {
            int rowCase = setCursor(numRow);
            int[] rowCursor = setLine(rowCase);
            int[] row = new int[9];
            int compteur = 0;
            for (int rb = rowCursor[0]; rb < rowCursor[0] + 1; rb++)
            {
                for (int r = rowCursor[1]; r < rowCursor[1] + 1; r++)
                {
                    for (int cb = 0; cb < 3; cb++)
                    {
                        for (int c = 0; c < 3; c++)
                        {
                            row[compteur++] = grid[rb, r, cb, c];
                        }
                    }
                }
            }
            return row;
        }
        /// <summary>
        /// Permet de copier une colonne a partir de son numero 
        /// </summary>
        /// <param name="numRow"></param>
        /// <returns>Renvoie un tableau avec le contenue de la colonne</returns>
        public int[] CopyColumn(int numCol)
        {
            int[] columnCursor = setLine(numCol);
            int[] column = new int[9];
            int compteur = 0;
            for (int rb = 0; rb < 3; rb++)
            {
                for (int r = 0; r < 3; r++)
                {
                    for (int cb = columnCursor[0]; cb < columnCursor[0] + 1; cb++)
                    {
                        for (int c = columnCursor[1]; c < columnCursor[1] + 1; c++)
                        {
                            column[compteur++] = grid[rb, r, cb, c];
                        }
                    }
                }
            }
            return column;
        }
        /// <summary>
        /// Permet de copier une colonne a partir de ses coordonnées 
        /// </summary>
        /// <param name="numRow"></param>
        /// <returns>Renvoie un tableau avec le contenue de la colonne</returns>
        public int[] CopyColumn(int[] numCol)
        {
            int columnCase = setCursor(numCol);
            int[] columnCursor = setLine(columnCase);
            int[] column = new int[9];
            int compteur = 0;
            for (int rb = 0; rb < 3; rb++)
            {
                for (int r = 0; r < 3; r++)
                {
                    for (int cb = columnCursor[0]; cb < columnCursor[0] + 1; cb++)
                    {
                        for (int c = columnCursor[1]; c < columnCursor[1] + 1; c++)
                        {
                            column[compteur++] = grid[rb, r, cb, c];
                        }
                    }
                }
            }
            return column;
        }
        /// <summary>
        /// Permet de copier un block a partir de son numero 
        /// </summary>
        /// <param name="numRow"></param>
        /// <returns>Renvoie un tableau avec le contenue du block</returns>
        public int[] CopyBlock(int numBlock)
        {
            int[] blockCursor = setLine(numBlock);
            int[] column = new int[9];
            int compteur = 0;
            for (int rb = blockCursor[0]; rb < blockCursor[0] + 1; rb++)
            {
                for (int r = 0; r < 3; r++)
                {
                    for (int cb = blockCursor[1]; cb < blockCursor[1] + 1; cb++)
                    {
                        for (int c = 0; c < 3; c++)
                        {
                            column[compteur++] = grid[rb, r, cb, c];
                        }
                    }
                }
            }
            return column;
        }
        /// <summary>
        /// Permet de copier un block a partir de ses coordonnées 
        /// </summary>
        /// <param name="numRow"></param>
        /// <returns>Renvoie un tableau avec le contenue du block</returns>
        public int[] CopyBlock(int[] numBlock)
        {
            int blockCase = setCursor(numBlock);
            int[] blockCursor = setLine(blockCase);
            int[] column = new int[9];
            int compteur = 0;
            for (int rb = blockCursor[0]; rb < blockCursor[0] + 1; rb++)
            {
                for (int r = 0; r < 3; r++)
                {
                    for (int cb = blockCursor[1]; cb < blockCursor[1] + 1; cb++)
                    {
                        for (int c = 0; c < 3; c++)
                        {
                            column[compteur++] = grid[rb, r, cb, c];
                        }
                    }
                }
            }
            return column;
        }

        /// <summary>
        /// Permet de compter l'occurence d'un chiffre dans une colonne un block ou une ligne
        /// </summary>
        /// <param name="array">tableau a analysé</param>
        /// <param name="chiffre">Chiffre recherché</param>
        /// <returns>le nombre d'occurence du chiffre recherché</returns>
        public int CountOccurence(int[] array, int chiffre)
        {
            int counterChiffre = 0;
            foreach (int i in array)
            {
                if (i == chiffre)
                {
                    counterChiffre++;
                }
            }
            return counterChiffre;
        }
        /// <summary>
        /// Permet de verifier si une case est valide <br />
        /// Permet principalement verifier si il est possible d'ajouter un chiffre sur une case
        /// </summary>
        /// <param name="coord">Coordonnée de la case a verifier</param>
        /// <param name="chiffre">Chiffre a placer</param>
        /// <returns>Un booleen qui specifie si le chiffre est placable sur la case</returns>
        public bool CheckCaseValide(int[] coord, int chiffre)
        {

            int[] row = CopyRow(new int[] { coord[0], coord[1] });
            int[] col = CopyColumn(new int[] { coord[2], coord[3] });
            int[] block = CopyBlock(new int[] { coord[0], coord[2] });
            //Si le chiffre est deja placé
            if (grid[coord[0], coord[1], coord[2], coord[3]] == chiffre)
            {
                if (CountOccurence(row, chiffre) > 1 ||
                    CountOccurence(col, chiffre) > 1 ||
                    CountOccurence(block, chiffre) > 1)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            //Si la case n'est libre ou que le chiffre est deja present sur une ligne une colonne ou un block
            if (grid[coord[0], coord[1], coord[2], coord[3]] != 0 || (
                row.Contains(chiffre) ||
                col.Contains(chiffre) ||
                block.Contains(chiffre)))
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Verifie que la case est libre et valide 
        /// </summary>
        /// <param name="coord">coordonnée de la case</param>
        /// <param name="chiffre">chiffre a placé</param>
        /// <returns>Un booleen qui averti du succes de l'operation</returns>
        public bool AddChiffre(int[] coord, int chiffre)
        {
            if (CheckCaseValide(coord, chiffre))
            {
                grid[coord[0], coord[1], coord[2], coord[3]] = chiffre;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Verifie si chaque case d'une rangée est valide en fonction d'une rangée donnée en paramettre
        /// </summary>
        /// <param name="numRow">numero de rangée a tester</param>
        /// <param name="row">rangée a comparé</param>
        /// <returns>Un booléen qui specifie si le placement est possible</returns>
        public bool checkDisposingOneRow(int numRow, int[] row)
        {
            int[] coord = setLine(numRow);
            int counter = 0;
            if (row == null)
            {
                return false;
            }
            for (int rb = coord[0]; rb < coord[0] + 1; rb++)
            {
                for (int r = coord[1]; r < coord[1] + 1; r++)
                {
                    for (int cb = 0; cb < 3; cb++)
                    {
                        for (int c = 0; c < 3; c++)
                        {
                            if (!CheckCaseValide(new int[] { rb, r, cb, c }, row[counter]))
                            {
                                return false;
                            }
                            counter++;
                        }
                    }
                }
            }
            return true;
        }
        /// <summary>
        /// Verifie si chaque case d'une colonne est valide en fonction d'une colonne donnée en paramettre
        /// </summary>
        /// <param name="numRow">numero de colonne a tester</param>
        /// <param name="row">colonne a comparé</param>
        /// <returns>Un booléen qui specifie si le placement est possible</returns>
        public bool checkDisposingOneColonne(int numCol, int[] col)
        {
            int[] coord = setLine(numCol);
            int counter = 0;
            if (col == null)
            {
                return false;
            }
            for (int rb = 0; rb < 3; rb++)
            {
                for (int r = 0; r < 3; r++)
                {
                    for (int cb = coord[0]; cb < coord[0] + 1; cb++)
                    {
                        for (int c = coord[1]; c < coord[1] + 1; c++)
                        {
                            if (!CheckCaseValide(new int[] { rb, r, cb, c }, col[counter]))
                            {
                                return false;
                            }
                            counter++;
                        }
                    }
                }
            }
            return true;
        }
        /// <summary>
        /// Verifie si chaque case d'une block est valide en fonction d'une block donnée en paramettre
        /// </summary>
        /// <param name="numRow">numero de block a tester</param>
        /// <param name="row">block a comparé</param>
        /// <returns>Un booléen qui specifie si le placement est possible</returns>
        public bool checkDisposingOneBlock(int numBlock, int[] block)
        {
            int[] coord = setLine(numBlock);
            int counter = 0;
            if (block == null)
            {
                return false;
            }
            for (int rb = coord[0]; rb < coord[0] + 1; rb++)
            {
                for (int r = 0; r < 3; r++)
                {
                    for (int cb = coord[1]; cb < coord[1] + 1; cb++)
                    {
                        for (int c = 0; c < 3; c++)
                        {
                            if (!CheckCaseValide(new int[] { rb, r, cb, c }, block[counter]))
                            {
                                return false;
                            }
                            counter++;
                        }
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Permet de clonner une liste d'indice
        /// </summary>
        /// <param name="rowClues">liste d'indice a clonner</param>
        /// <returns>Une liste d'indice clonnée</returns>
        public List<List<int>> CopyClues(List<List<int>> rowClues)
        {
            List<List<int>> listToReturn = new();
            for (int i = 0; i < rowClues.Count; i++)
            {
                listToReturn.Add(new List<int>());
                for (int y = 0; y < rowClues[i].Count; y++)
                {
                    listToReturn[i].Add(rowClues[i][y]);
                }
            }
            return listToReturn;
        }

        /// <summary>
        /// Permet de suprimmer une rangée complette
        /// </summary>
        /// <param name="num">numero de rangée a suprimmer</param>
        public void EraseRow(int numRow)
        {
            int[] coord = setLine(numRow);
            for (int rb = coord[0]; rb < coord[0] + 1; rb++)
            {
                for (int r = coord[1]; r < coord[1] + 1; r++)
                {
                    for (int cb = 0; cb < 3; cb++)
                    {
                        for (int c = 0; c < 3; c++)
                        {
                            grid[rb, r, cb, c] = 0;
                        }
                    }
                }
            }

        }
        /// <summary>
        /// Permet de suprimmer une colonne complette
        /// </summary>
        /// <param name="num">numero de colonne a supprimer</param>
        public void EraseColumn(int numCol)
        {
            int[] coord = setLine(numCol);
            for (int rb = 0; rb < 3; rb++)
            {
                for (int r = 0; r < 3; r++)
                {
                    for (int cb = coord[0]; cb < coord[0] + 1; cb++)
                    {
                        for (int c = coord[1]; c < coord[1] + 1; c++)
                        {
                            grid[rb, r, cb, c] = 0;
                        }
                    }
                }
            }

        }
        /// <summary>
        /// Permet de suprimmer un block complette
        /// </summary>
        /// <param name="num">numero de block a supprimer</param>
        public void EraseBlock(int numBlock)
        {
            int[] coord = setLine(numBlock);
            for (int rb = coord[0]; rb < coord[0]+1; rb++)
            {
                for (int r = 0; r < 3; r++)
                {
                    for (int cb = coord[1]; cb < coord[1] + 1; cb++)
                    {
                        for (int c = 0; c < 3; c++)
                        {
                            grid[rb, r, cb, c] = 0;
                        }
                    }
                }
            }

        }

        /// <summary>
        /// Permet d'ajouter une ligne dans le tableau en placant plus ou moins aleatoirement selon les indice disponible
        /// </summary>
        /// <param name="numRow">Rangé a completer</param>
        /// <param name="rowClues">Liste d'indice permettant de completer la rangée</param>
        /// <returns>Un booleen qui notifie que l'action a eté réalisé</returns>
        public bool AddOneRow(int numRow, List<List<int>> rowClues)
        {
            List<List<int>> rowCluesStart;
            int[] coord = setLine(numRow);
            int[] row = new int[9];
            bool loopContinue = true;

            int tryCount = 0;
            do
            {
                rowCluesStart = CopyClues(rowClues);
                row = new RowSolver(rowCluesStart).Resolve();
                if (row == null)
                {
                    rowCluesStart = CopyClues(rowClues);
                    row = new RowSolver(rowCluesStart).Resolve(true);
                }
                tryCount++;
                rowCluesStart = CopyClues(rowClues);
                row = new RowSolver(rowCluesStart).Resolve(true);
                loopContinue = !checkDisposingOneRow(numRow, row);
            }
            while (loopContinue && tryCount < 5);
            if (tryCount >= 5)
            {
                return false;
            }
            int counter = 0;
            if (checkDisposingOneRow(numRow, row))
            {
                for (int rb = coord[0]; rb < coord[0] + 1; rb++)
                {
                    for (int r = coord[1]; r < coord[1] + 1; r++)
                    {
                        for (int cb = 0; cb < 3; cb++)
                        {
                            for (int c = 0; c < 3; c++)
                            {
                                if (!AddChiffre(new int[] { rb, r, cb, c }, row[counter]))
                                {
                                    return false;
                                }

                                counter++;
                            }
                        }
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public void HideCase(int number)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Permet de verifier si une ligne/colonne/block ne contient pas de doublon
        /// </summary>
        /// <param name="num">Numero de ligne colonne ou block a verifier</param>
        /// <param name="typeLine">Permet de cibler une ligne colonne ou block</param>
        /// <returns>Un booleen qui specifie si la ligne est valide</returns>
        public bool CheckLineValide(int num, EnumLine typeLine)
        {
            int[] line = new int[9];
            if (typeLine == EnumLine.Row)
            {
                line = CopyRow(num);
            }
            else if (typeLine == EnumLine.Column)
            {
                line = CopyColumn(num);
            }
            else
            {
                line = CopyBlock(num);
            }

            for (int i = 1; i < 10; i++)
            {
                int counter = 0;
                foreach (int item in line)
                {
                    if (i == item)
                    {
                        counter++;
                        if (counter > 1)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        /// <summary>
        /// Permet de verifier si une ligne/colonne/block est complette
        /// </summary>
        /// <param name="num">Numero de ligne colonne ou block a verifier</param>
        /// <param name="typeLine">Permet de cibler une ligne colonne ou block</param>
        /// <returns>Un booleen qui specifie si la ligne est complette</returns>
        public bool CheckLineComplete(int num, EnumLine typeLine)
        {
            int[] line = new int[9];
            if (typeLine == EnumLine.Row)
            {
                line = CopyRow(num);
            }
            else if (typeLine == EnumLine.Column)
            {
                line = CopyColumn(num);
            }
            else
            {
                line = CopyBlock(num);
            }
            int counter = 0;
            foreach (int item in line)
            {
                if (item != 0)
                {
                    counter++;
                }
            }
            if (counter != 9)
            {
                return false;
            }
            return true;
        }
    }
}
