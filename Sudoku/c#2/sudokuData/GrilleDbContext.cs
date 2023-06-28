using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grilles.Models.GrilleData;

namespace sudokuData
{
    public class GrilleDbContext:DbContext
    {
        public DbSet<Grille> Grille { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=sudoku_api");
        }
    }
}
