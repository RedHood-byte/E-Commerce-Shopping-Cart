using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Team4CAProject.Models;

namespace Team4CAProject.DB
{
    public class CADb : DbContext
    {
        protected IConfiguration configuration;

        public CADb(DbContextOptions<CADb> options)
    : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder model)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Cart { set; get; }
        public DbSet<CartItem> CartItem { set; get; }
        public DbSet<PurchasedActivationCode> PurchasedActivationCode { set; get; }
    }
}
