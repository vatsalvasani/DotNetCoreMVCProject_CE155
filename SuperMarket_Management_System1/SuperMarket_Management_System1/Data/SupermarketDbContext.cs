using Microsoft.EntityFrameworkCore;
using SuperMarket_Management_System1.Models;

namespace SuperMarket_Management_System1.Data
{
    public class SupermarketDbContext : DbContext
    {
        public SupermarketDbContext(DbContextOptions<SupermarketDbContext> options) : base(options)
        {
            
        
        }
        public DbSet<Avail_Product> Avail_Product { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<transaction1> transaction1 { get; set; }
        public DbSet<Customer> Customer { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("Admin");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
