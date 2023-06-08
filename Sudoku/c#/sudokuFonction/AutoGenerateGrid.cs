using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudokuFonction
{
    public class AutoGenerateGrid
    {
        public GridInit grid;
        public AutoGenerateGrid():this(new GridInit())
        {
        }
        public AutoGenerateGrid(GridInit _grid)
        {
            grid = _grid;
        }
        /// <summary>
        /// Permet de recuperer une rangée d'indice
        /// </summary>
        /// <param name="numRow">Numero de la rangée ou l'on cherche les indices</param>
        /// <returns>Renvoie une rangée d'indice ou un null si la rangée d'indice comporte une case vide</returns>
        public List<List<int>>? GetRowClues(int numRow)
        {
            return new RowClueDispose(grid).SearchCluesRow(numRow);
        }
        /// <summary>
        /// Tente a chaque rangée de la remplir
        /// </summary>
        /// <returns>Si les 9 rangé on été remplie avec succes, true est renvoyé</returns>
        public bool Generate()
        {
            for (int i = 1; i < 10; i++)
            {
                List<List<int>> rowClues = GetRowClues(i);
                if (rowClues!=null)
                {
                    if (!grid.AddOneRow(i, rowClues))
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
    }
}
