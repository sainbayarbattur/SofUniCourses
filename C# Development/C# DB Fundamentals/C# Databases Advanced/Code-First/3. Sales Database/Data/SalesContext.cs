namespace P03_SalesDatabase.Data
{
    using Microsoft.EntityFrameworkCore;
    using P03_SalesDatabase.Data.Models;

    public class SalesContext : DbContext
    {
        public SalesContext()
        {
        }

        public SalesContext(DbContextOptions<SalesContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=TEDDY\SQLEXPRESS02;Database=SaleDatabase;Integrated security=true");
            }
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Sale> Sales { get; set; }

        public DbSet<Store> Stores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(p =>
            {
                p.HasKey(p => p.ProductId);

                p.Property(c => c.Name)
                .HasMaxLength(50)
                .IsUnicode(true);

                p.HasMany(p => p.Sales)
                .WithOne(s => s.Product);
            });

            modelBuilder.Entity<Customer>(c => 
            {
                c.HasKey(c => c.CustomerId);

                c.Property(c => c.Name)
                .HasMaxLength(100)
                .IsUnicode(true);

                c.Property(c => c.Email)
                .HasMaxLength(80)
                .IsUnicode(false);

                c.HasMany(c => c.Sales)
                .WithOne(s => s.Customer);
            });

            modelBuilder.Entity<Sale>(s =>
            {
                s.HasKey(s => s.SaleId);

                s.HasOne(s => s.Product)
                .WithMany(s => s.Sales)
                .HasForeignKey(s => s.ProductId);

                s.HasOne(s => s.Customer)
                .WithMany(s => s.Sales)
                .HasForeignKey(s => s.CustomerId);

                s.HasOne(s => s.Store)
                .WithMany(s => s.Sales)
                .HasForeignKey(s => s.StoreId);
            });

            modelBuilder.Entity<Store>(s =>
            {
                s.HasKey(s => s.StoreId);

                s.Property(c => c.Name)
                .HasMaxLength(80)
                .IsUnicode(true);

                s.HasMany(s => s.Sales)
                .WithOne(s => s.Store);
            });
        }
    }
}