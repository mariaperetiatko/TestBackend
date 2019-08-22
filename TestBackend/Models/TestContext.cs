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

    }
}
