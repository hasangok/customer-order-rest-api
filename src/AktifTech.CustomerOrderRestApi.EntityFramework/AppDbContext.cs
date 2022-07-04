using AktifTech.CustomerOrderRestApi.Model;
using Microsoft.EntityFrameworkCore;

namespace AktifTech.CustomerOrderRestApi.EntityFramework
{
    public class AppDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerAddress> CustomerAddresses { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CustomerOrder> CustomerOrders { get; set; }
        public DbSet<ProductInOrder> ProductsInOrders { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("aktiftech");

            modelBuilder.Entity<Customer>().Navigation(e => e.Addresses).AutoInclude();
            modelBuilder.Entity<ProductInOrder>().Navigation(e => e.Product).AutoInclude();
            modelBuilder.Entity<CustomerOrder>().Navigation(e => e.Products).AutoInclude();
            modelBuilder.Entity<CustomerOrder>().Navigation(e => e.Customer).AutoInclude();
            modelBuilder.Entity<CustomerOrder>().Navigation(e => e.Address).AutoInclude();

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            var now = DateTime.Now;

            // add creation times
            var addedEntries = ChangeTracker.Entries().Where(e => e.Entity is IHasCreationTime && e.State == EntityState.Added);
            foreach (var entityEntry in addedEntries)
            {
                if (((IHasCreationTime)entityEntry.Entity).Created == DateTime.MinValue)
                {
                    ((IHasCreationTime)entityEntry.Entity).Created = now;
                }
            }

            // add modification times
            var updatedEntries = ChangeTracker.Entries().Where(e => e.Entity is IHasModificationTime && e.State == EntityState.Modified);
            foreach (var entityEntry in updatedEntries)
            {
                ((IHasModificationTime)entityEntry.Entity).Modified = now;
            }

            return base.SaveChanges();
        }
    }
}