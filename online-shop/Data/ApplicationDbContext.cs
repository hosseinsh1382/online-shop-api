using Microsoft.EntityFrameworkCore;
using online_shop.Models.Product;
using online_shop.Models.Product.Digital;
using online_shop.Models.Product.Digital.DataStoring;

namespace online_shop.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pc>();
        modelBuilder.Entity<Usb>();
        modelBuilder.Entity<Ssd>();
    }
}