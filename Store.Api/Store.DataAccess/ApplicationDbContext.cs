using Microsoft.EntityFrameworkCore;
using Store.DataAccess.Entities;

namespace Store.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Type> Types { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Type>().HasIndex(x => x.Code).IsUnique();
            modelBuilder.Entity<Product>().HasIndex(x => x.Code).IsUnique();
            modelBuilder.Entity<Category>().HasIndex(x => x.Code).IsUnique();
            modelBuilder.Entity<Unit>().HasIndex(x => x.Code).IsUnique();

            modelBuilder.Entity<Product>()
                .HasMany(x => x.ProductCategory)
                .WithOne(pc => pc.Product)
                .HasForeignKey(pc => pc.ProductId);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Type);
        }
    }
}