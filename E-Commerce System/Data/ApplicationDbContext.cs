using E_Commerce_System.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_System.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Cart>(f => f.HasKey(p => new { p.ProductId, p.AppUserId }));

            builder.Entity<Cart>()
            .HasOne(u => u.Product)
            .WithMany(u => u.Carts)
            .HasForeignKey(u => u.ProductId);

            builder.Entity<Cart>()
            .HasOne(u => u.AppUser)
            .WithMany(u => u.Carts)
            .HasForeignKey(u => u.AppUserId);

            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = "33bc4ea6-3ddd-4987-aaa8-828f95b70bbf",
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Id = "e8548f30-f1e6-48f7-99fb-9b753a2ad020",
                    Name = "User",
                    NormalizedName = "USER"
                }
            };
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
