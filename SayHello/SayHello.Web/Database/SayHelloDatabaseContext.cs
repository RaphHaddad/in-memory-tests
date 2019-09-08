using Microsoft.EntityFrameworkCore;

namespace SayHello.Web.Database
{
    public class SayHelloDatabaseContext : DbContext
    {
        public SayHelloDatabaseContext(DbContextOptions<SayHelloDatabaseContext> options)
            : base(options)
        {
            this.Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hello>().HasData(
                    new Hello { ISO639LanguageId = "eng", HelloText = "Hello", LanguageName = "English" },
                    new Hello { ISO639LanguageId = "spa", HelloText = "Hola", LanguageName = "Spanish" },
                    new Hello { ISO639LanguageId = "jpn", HelloText = "こんにちは", LanguageName = "Japanese" },
                    new Hello { ISO639LanguageId = "ara", HelloText = "مرحبا", LanguageName = "Arabic" }
                );
        }

        public DbSet<Hello> Hellos { get; set; }
    }
}
