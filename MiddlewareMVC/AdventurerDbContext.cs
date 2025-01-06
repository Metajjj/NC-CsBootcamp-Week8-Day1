using Microsoft.EntityFrameworkCore;
namespace MiddlewareMVC
{
    public class AdventurerDbContext : DbContext
    {
        public DbSet<Adventurer> Adventurers { get; set; }
        public AdventurerDbContext(DbContextOptions<AdventurerDbContext> options) : base(options) { }


    }
}
