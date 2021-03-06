namespace DataAccess.Concrete.EntityFramework
{
    using Entities.Concrete;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Defines the <see cref="ECommerceContext" />.
    /// </summary>
    public class ECommerceContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=DB_ECommerce;Trusted_Connection=true");
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<CarImage> CarImages { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Rental> Rentals { get; set; }


    }
}
