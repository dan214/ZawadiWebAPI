using Microsoft.EntityFrameworkCore;

namespace ZetechWebAPI.Models
{
    public class ZetechDbContext : DbContext
    {
        public ZetechDbContext(DbContextOptions<ZetechDbContext> options): base(options)
        {
        }

        public DbSet<Pizza> Pizza { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Batch> Batch { get; set; }
    }
}
