using Microsoft.EntityFrameworkCore;

namespace csharp_test_webapi_withdbsetup
{
    public class MediaContext : DbContext
    {
        public DbSet<Book> Books {get; set;}
        public DbSet<Magazine> Magazines {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=Media.db");
        }
    }
}