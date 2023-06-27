using Microsoft.EntityFrameworkCore;
using SudokuGrille;

namespace SudokuDB
{
    public class UserDbContext:DbContext
    {
        public DbSet<Grille> grille { get; set; }
        protected override void OnCofiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer();
        }
    }
}