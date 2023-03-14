using EcommerceAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace EcommerceAPI.Data
{
    public class ProductDataContext: IdentityDbContext<IdentityUser>
    {
        public ProductDataContext(DbContextOptions<ProductDataContext> options):base(options)
        {
            
        }

        public DbSet<Product> products { get; set; }
        public DbSet<Catagory> categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Catagory)
                .WithMany(c => c.Products)
                .HasForeignKey(c => c.CategoryId);

            modelBuilder.Entity<Catagory>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Catagory);
        }
    }
}
