using Microsoft.EntityFrameworkCore;
using online_shop.Models.Product;
using online_shop.Models.Product.Digital;
using online_shop.Models.Product.Digital.DataStoring;
using online_shop.Models.Product.Stationery;
using online_shop.Models.Product.Vehicle;

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
        modelBuilder.Entity<Pencil>();
        modelBuilder.Entity<Pen>();
        modelBuilder.Entity<NoteBook>();
        modelBuilder.Entity<Automobile>();
        modelBuilder.Entity<Bicycle>();
    }
}