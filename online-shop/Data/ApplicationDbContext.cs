using Microsoft.EntityFrameworkCore;
using online_shop.Models.Product;

namespace online_shop.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }


    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }
}