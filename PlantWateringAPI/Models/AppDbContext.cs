using Microsoft.EntityFrameworkCore;

namespace PlantWateringAPI.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Plant> Plants { get; set; }
    }
}
