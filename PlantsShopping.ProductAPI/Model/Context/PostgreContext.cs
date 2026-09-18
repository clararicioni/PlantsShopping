using Microsoft.EntityFrameworkCore;

namespace PlantsShopping.ProductAPI.Model.Context
{
    public class PostgreContext : DbContext
    {
        public PostgreContext() {}
        public PostgreContext(DbContextOptions<PostgreContext> options)
            : base(options)
        {
        }

        public DbSet<Plant> Plants { get; set; }
    }
}