using Bible.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Bible.Database.Data
{
    public class BibleContext : DbContext
    {

        /* public BibleContext(DbContextOptions<BibleContext> options ) : base(options)
         {

         }*/
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer("Server=.;Database=Bible_DB;Trusted_Connection=True;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);

        }
        public DbSet<Language>? Languages { get; set; }
        public DbSet<Section>? Sections { get; set; }
        public DbSet<Book>? Books { get; set; }
        public DbSet<Chapter>? Chapters { get; set; }
        public DbSet<Verse>? Verses { get; set; }
        public DbSet<AudioVerse>? AudioVerses { get; set; }

    }
}
