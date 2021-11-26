using LINQExample.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LINQExample.DbOperations
{
    public class LinqDBContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "LINQDatabase");
        }
    }
}