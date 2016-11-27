using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Pedigree.Common.Models;

namespace Pedigree.Importer.Infrastructure
{
    public sealed class AppDbContext : DbContext
    {
        public DbSet<Dog> Dogs { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<CoatColor> CoatColors { get; set; }

        public AppDbContext() : base()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }
    }
}
