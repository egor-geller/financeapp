using fin.server.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace fin.server.Data;

public class FinContext(DbContextOptions<FinContext> options) : DbContext(options)
{
    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .Property(user => user.Role)
            .HasConversion<int>();
    }
}