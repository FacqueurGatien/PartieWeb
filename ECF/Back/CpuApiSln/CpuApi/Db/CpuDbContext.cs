using CpuApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CpuApi.Db
{
    public class CpuDbContext : DbContext
    {
        public DbSet<CpuModel> Cpus { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=db_cpus");
        }
    }
}
