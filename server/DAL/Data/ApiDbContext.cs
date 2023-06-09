﻿using DAL.Entities;
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
        public DbSet<Session> Sessions { get; set; }

        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // modeling product variants
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

            // modeling others property of product 
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

            modelBuilder
                .Entity<Product>()
                .HasMany(p => p.OrderItems)
                .WithOne(oi => oi.Product)
                .HasForeignKey(x => new { x.ProductId });  // ??

            modelBuilder
                .Entity<Product>()
                .HasMany(p => p.CartItems)
                .WithOne(ci => ci.Product)
                .HasForeignKey(x => new { x.ProductId });

            modelBuilder
                .Entity<Product>()
                .HasMany(p => p.ProductDiscounts)
                .WithOne(pd => pd.Product)
                .HasForeignKey(x => new { x.ProductId });

            // modeling user relationship
            modelBuilder
                .Entity<User>()
                .HasMany(u => u.UserAddresses)
                .WithOne(ua => ua.User)
                .HasForeignKey(ua => new { ua.UserId });


            modelBuilder
                .Entity<User>()
                .HasMany(u => u.OrderDetails)
                .WithOne(od => od.User)
                .HasForeignKey(od => new { od.UserId });

            modelBuilder
                .Entity<User>()
                .HasMany(u => u.CartItems)
                .WithOne(ci => ci.User)
                .HasForeignKey(ci => new { ci.UserId });



            // modeling order relationship

            modelBuilder
                .Entity<OrderDetail>()
                .HasKey(od => new { od.Id });

            modelBuilder
                .Entity<OrderDetail>()
                .HasMany(od => od.OrderItems)
                .WithOne(oi => oi.OrderDetail)
                .HasForeignKey(oi => new { oi.OrderDatailId });

            modelBuilder
                .Entity<OrderDetail>()
                .HasOne(od => od.UserPayment)
                .WithOne(up => up.OrderDetail)
                .HasForeignKey<UserPayment>(x => new { x.OrderDetailId });

            modelBuilder
                .Entity<Session>()
                .HasOne(s => s.User)
                .WithMany(u => u.Sessions)
                .HasForeignKey(x => new { x.UserId });

        }
    }
}
