using Microsoft.EntityFrameworkCore;
using Pedigree.Common.Models;

namespace Pedigree.Importer.Infrastructure
{
    public sealed class AppDbContext : DbContext
    {
        public const string SqlConnectionString = "";

        public DbSet<Dog> Dogs { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<CoatColor> CoatColors { get; set; }

        public AppDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(SqlConnectionString);
        }
    }
}
