using Microsoft.EntityFrameworkCore;
using online_shop.Models;
using online_shop.Models.Account;
using online_shop.Models.Product;

namespace online_shop.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductItem> ProductItems { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<ProductCategory> ProductCategory { get; set; }
    public DbSet<Buyer> Buyers { get; set; }

    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    /*protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>()
            .HasMany(p => p.Fields)
            .WithOne(f => f.Product)
            .HasForeignKey(p=>p.ProductId)
            .IsRequired();

        modelBuilder.Entity<Product>()
            .HasMany(p => p.Comments)
            .WithOne(c => c.Product)
            .HasForeignKey(c=>c.ProductId)
            .IsRequired();
    }*/
}