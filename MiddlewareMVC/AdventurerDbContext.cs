using Microsoft.EntityFrameworkCore;

namespace MiddlewareMVC
{
    public class AdventurerDbContext : DbContext
    {
        private IWebHostEnvironment h;
        public DbSet<Adventurer> Adventurers { get; set; }
        
        public AdventurerDbContext(DbContextOptions<AdventurerDbContext> options) : base(options) { }
        public AdventurerDbContext(IWebHostEnvironment e)
        {
            h = e;
        }
        public AdventurerDbContext(DbContextOptions<AdventurerDbContext> options, IWebHostEnvironment e) : base(options)
        { h = e; }

        protected override void OnConfiguring(DbContextOptionsBuilder o)
        {
            if (h.IsDevelopment)
            {
                o.use
            }

            var conStr = $"Server={Secret.s};Database=AdventurersDb;User Id={Secret.u};Password={Secret.p};Trust Server Certificate=True";

            o.UseSqlServer(conStr);
        }

    }
}
