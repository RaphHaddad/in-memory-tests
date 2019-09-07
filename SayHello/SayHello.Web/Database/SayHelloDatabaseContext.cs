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

        public DbSet<Hello> Hellos { get; set; }
    }
}
