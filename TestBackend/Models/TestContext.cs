using Microsoft.EntityFrameworkCore;

namespace TestBackend.Models
{
    public class TestContext : DbContext
    {
        public TestContext(DbContextOptions options)
             : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(t => t.Products)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Category>().HasData(
                new Category() { Id = 1, Name = "Fruit"},
                new Category() { Id = 2, Name = "Vegetable" },
                new Category() { Id = 3, Name = "Bakery" });
        }
    }
}
