using CerealsApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CerealsApi.Db
{
    public class CerealsDbContext : DbContext
    {
        public DbSet<Cereal> Cereals {get; set;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=db_cereals");
        }
    }
}
