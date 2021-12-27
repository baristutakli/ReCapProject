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
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=DB_ECommerce;Trusted=true_Connection");
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<CarImage> CarImages { get; set; }

    }
}
