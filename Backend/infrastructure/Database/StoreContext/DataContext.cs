using core.Entities;
using Microsoft.EntityFrameworkCore;


namespace infrastructure.Database.StoreContext
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext>options):base(options) {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CustomerAddress>()
                .HasOne( c => c.Customer)
                .WithMany( address => address.CustomerAddresses)
                .HasForeignKey ( c => c.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<Customer>()
                .HasOne( c => c.Country)
                .WithOne( country => country.Customer)
                .OnDelete(DeleteBehavior.Cascade);

        }
           
        
        public DbSet<Customer> Customers{get; set;}
        public DbSet<CustomerAddress> CustomerAddresses{get;set;}
        public DbSet<Country> Countries {get;set;}
        
    }
}