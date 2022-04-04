using Microsoft.EntityFrameworkCore;
using UniqueWordHTML.Model;

namespace UniqueWordHTML.DB
{
    class ApplicationContext : DbContext
    {
        public DbSet<WordStat> WordStats => Set<WordStat>();
        public DbSet<Site> Sites => Set<Site>();
        public ApplicationContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=uniquewordhtml.db");
        }
    }
}
