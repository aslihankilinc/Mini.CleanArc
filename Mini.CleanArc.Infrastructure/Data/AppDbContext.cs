using Microsoft.EntityFrameworkCore;
using Mini.CleanArc.Core.Domain.Entity;
using Mini.CleanArc.Infrastructure.Extensions;

namespace Mini.CleanArc.Infrastructure.Persistence
{

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<User> Users => Set<User>();
        public DbSet<TaskItem> Tasks => Set<TaskItem>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed verilerini ekle
            modelBuilder.SeedFromJson();
        }
    }
}
