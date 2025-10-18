using Microsoft.EntityFrameworkCore;

namespace SecondAPI.Model;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Books>().HasData(
            new Books { Id = 1, Title = "Helon", Author = "Helon_Xavier", YearPublished = 2025 },
            new Books { Id = 2, Title = "Learn C#", Author = "Microsoft", YearPublished = 2025 }
            );
    }

    public DbSet<Books> Books { get; set; }
        
}