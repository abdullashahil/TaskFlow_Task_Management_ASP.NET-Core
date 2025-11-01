using Microsoft.EntityFrameworkCore;
using TaskFlow.Models;

namespace TaskFlow.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<TaskItem> Tasks { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Optional: configure default value here (not required)
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<TaskItem>().HasIndex(t => t.IsCompleted);
            base.OnModelCreating(mb);
        }
    }
}
