using E_CommerceAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceAPI.Data
{
    public class EcommerceDbcontext : DbContext
    {
        public EcommerceDbcontext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<eCategory>()
                .HasMany(c => c.SubCategories)
                .WithOne(sc => sc.Category)
                .HasForeignKey(sc => sc.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        public DbSet<eCategory> eCategory { get; set; }
        public DbSet<eSubCategory> eSubCategories { get; set; }
    }
}
