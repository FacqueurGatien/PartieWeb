using Microsoft.EntityFrameworkCore;
using TPEntityBank.Models;

namespace TPEntityBank.DataBase
{
    public class BankDbContext : DbContext
    {
        public DbSet<Transaction> Transactions { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=bank_api");
        }
    }
}