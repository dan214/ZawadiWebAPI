using Microsoft.EntityFrameworkCore;

namespace ZawadiWholesaleWebAPI.Models
{
    public class ZawadiDbContext : DbContext
    {
        protected ZawadiDbContext(DbContextOptions<ZawadiDbContext> options): base(options)
        {
        }

        public DbSet<Pizza> Pizzas { get; set; }
    }
}
