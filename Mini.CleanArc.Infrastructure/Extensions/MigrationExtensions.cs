using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Mini.CleanArc.Core.Domain.Entity;
using Mini.CleanArc.Infrastructure.Persistence;
using System.Text.Json;

namespace Mini.CleanArc.Infrastructure.Extensions
{
    public static class MigrationExtensions
    {
        public static void ApplyMigrations(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            if (db.Database.GetPendingMigrations().Any())
                db.Database.Migrate();
        }
        
        public static void SeedFromJson(this ModelBuilder modelBuilder)
        {
            var basePath = AppContext.BaseDirectory;
            var seedPath = Path.Combine(basePath, "Persistence", "Seed");


            var usersFile = Path.Combine(seedPath, "users.json");
            var tasksFile = Path.Combine(seedPath, "tasks.json");

            if (!File.Exists(usersFile) || !File.Exists(tasksFile))
                throw new FileNotFoundException("Seed data files not found. Check Copy to Output Directory setting.");

            var usersJson = File.ReadAllText(usersFile);
            var tasksJson = File.ReadAllText(tasksFile);

            var users = JsonSerializer.Deserialize<List<User>>(usersJson);
            var tasks = JsonSerializer.Deserialize<List<TaskItem>>(tasksJson);

            modelBuilder.Entity<User>().HasData(users!);
            modelBuilder.Entity<TaskItem>().HasData(tasks!);
        }
    }
}
