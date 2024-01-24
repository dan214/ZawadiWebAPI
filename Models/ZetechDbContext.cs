using Microsoft.EntityFrameworkCore;

namespace ZetechWebAPI.Models
{
    public class ZetechDbContext : DbContext
    {
        public ZetechDbContext(DbContextOptions<ZetechDbContext> options): base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the one-to-many relationship
            modelBuilder.Entity<Batch>()
                .HasMany(b => b.Courses)
                .WithOne(c => c.Batch)
                .HasForeignKey(c => c.BatchId);
        }
        public DbSet<Pizza> Pizza { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Batch> Batch { get; set; }
    }
}
