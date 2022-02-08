using database.Models;
using Microsoft.EntityFrameworkCore;

namespace database
{
    public class CoreContext : DbContext
    {
        public CoreContext(DbContextOptions<CoreContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<OrderPruducts>()
                .HasKey(t => new { t.OrderID, t.PruductID });

            modelBuilder.Entity<OrderPruducts>()
                .HasOne(pt => pt.Orders)
                .WithMany(p => p.OrderPruducts)
                .HasForeignKey(pt => pt.OrderID);

            modelBuilder.Entity<OrderPruducts>()
                .HasOne(pt => pt.Products)
                .WithMany(p => p.OrderPruducts)
                .HasForeignKey(pt => pt.PruductID);

        }

        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<OrderPruducts> OrderPruducts { get; set; }
        public virtual DbSet<Products> Products { get; set; }

    }
}