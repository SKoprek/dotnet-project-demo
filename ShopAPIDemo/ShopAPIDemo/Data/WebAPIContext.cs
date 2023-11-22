using Microsoft.EntityFrameworkCore;
using ShopAPIDemo.Models;

namespace ShopAPIDemo.Data
{
    public class WebAPIContext: DbContext
    {
        public WebAPIContext(DbContextOptions<WebAPIContext> options): base(options) { }  

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; } 
    }
    
}
