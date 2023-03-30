using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data
{
    public class ApiDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductOption> ProductOptions { get; set; }
        public DbSet<ProductOptionValue> ProductOptionValues { get; set; }
        public DbSet<ProductSku> ProductSkus { get; set; }
        public DbSet<ProductSkuValue> ProductSkuValues { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<User> Users { get; set; }

        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder
               .Entity<ProductSku>()
               .HasKey(ps => new { ps.ProductId, ps.Id });

            modelBuilder
                .Entity<ProductSku>()
                .HasOne(ps => ps.Product)
                .WithMany(p => p.ProductSkus)
                .HasForeignKey(x => x.ProductId);

            modelBuilder
                .Entity<ProductSku>()
                .HasIndex(ps => ps.Sku);

            modelBuilder
                .Entity<ProductSku>()
                .Property(ps => ps.Id)
                .ValueGeneratedOnAdd();

            modelBuilder
                .Entity<ProductSkuValue>()
                .HasOne(psv => psv.ProductSku)
                .WithMany(ps => ps.ProductSkuValues)
                .HasForeignKey(x => new { x.ProductId, x.ProductSkuId })
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
                .Entity<ProductSkuValue>()
                .HasKey(psv => new { psv.ProductId, psv.ProductSkuId, psv.OptionId });

            modelBuilder
                .Entity<ProductSkuValue>()
                .HasOne(psv => psv.ProductOptionValue)
                .WithMany(pov => pov.ProductSkuValues)
                .HasForeignKey(x => new { x.ProductId, x.OptionId, x.ValueId })
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
                .Entity<ProductSkuValue>()
                .HasOne(psv => psv.ProductOption)
                .WithMany(po => po.ProductSkuValues)
                .HasForeignKey(x => new { x.ProductId, x.OptionId })
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
                .Entity<ProductOptionValue>()
                .HasKey(pov => new { pov.ProductId, pov.OptionId, pov.Id });

            modelBuilder
                .Entity<ProductOptionValue>()
                .HasOne(pov => pov.ProductOption)
                .WithMany(po => po.ProductOptionValues)
                .HasForeignKey(x => new { x.ProductId, x.OptionId })
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
                .Entity<ProductOptionValue>()
                .Property(pov => pov.Id)
                .ValueGeneratedOnAdd();

            modelBuilder
                .Entity<ProductOption>()
                .HasKey(po => new { po.ProductId, po.Id });

            modelBuilder
                .Entity<ProductOption>()
                .HasOne(po => po.Product)
                .WithMany(p => p.ProductOptions)
                .HasForeignKey(x => new { x.ProductId })
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
                .Entity<ProductOption>()
                .Property(po => po.Id)
                .ValueGeneratedOnAdd();

            modelBuilder
                .Entity<Product>()
                .HasOne(p => p.Brand)
                .WithMany(b => b.Products)
                .HasForeignKey(x => new { x.BrandId });

            modelBuilder
                .Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(x => new { x.CategoryId });


        }
    }
}
