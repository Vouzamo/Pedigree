using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Pedigree.Common.Models;

namespace Pedigree.App.Infrastructure
{
    public sealed class AppDbContext : DbContext
    {
        private IConfiguration Configuration { get; set; }

        public DbSet<Dog> Dogs { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<CoatColor> CoatColors { get; set; }

        public AppDbContext(IConfiguration configuration) : base()
        {
            Configuration = configuration;

            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
