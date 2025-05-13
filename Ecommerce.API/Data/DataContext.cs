using System.Data.Common;
using Ecommerce.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Country> Countries { get; set; }
<<<<<<< HEAD
        public DbSet<City> Cities { get; set; }

        public DbSet<State> States { get; set; }

=======
>>>>>>> cb0bdcc138b7856e9375df06e0075ae12405c89e

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasIndex(x => x.Name).IsUnique();
<<<<<<< HEAD
            modelBuilder.Entity<State>().HasIndex("Name","CountryId").IsUnique();
            modelBuilder.Entity<City>().HasIndex("Name", "StateId").IsUnique();


=======
>>>>>>> cb0bdcc138b7856e9375df06e0075ae12405c89e

        }

    }
}
