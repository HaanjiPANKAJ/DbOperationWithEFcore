using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DbOperationWithEFcore.Data
{
    public class appDbContext : DbContext
    {
        public appDbContext(DbContextOptions<appDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Currency>().HasData(
                new Currency() { ID = 1, Title = "USD", Description = "United States Dollar" },
                new Currency() { ID = 2, Title = "IND", Description = "IND" },
                new Currency() { ID = 3, Title = "Euro", Description = "Euro" },
                new Currency() { ID = 4, Title = "Dinar", Description = "Dinar" }

                );

            modelBuilder.Entity<Language>().HasData(
                new Language() { ID = 1, Title = "Hindi", Description = "Hindi" },
                new Language() { ID = 2, Title = "English", Description = "English" },
                new Language() { ID = 3, Title = "Bhojpuri", Description = "Bhojpuri" },
                new Language() { ID = 4, Title = "Marathi", Description = "Marathi" }

                );
        }
        public DbSet<Books> Books { get; set; }
        public DbSet<Language> Language { get; set; }
        public DbSet<Currency> Currency { get; set; }
        public DbSet<BookPrice> BookPrice
        {
            get; set;
        }
    }
}
