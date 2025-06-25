using fin.server.Models.Accounts;
using fin.server.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace fin.server.Data;

public class FinContext(DbContextOptions<FinContext> options) : DbContext(options)
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Account> Accounts => Set<Account>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .Property(user => user.Role)
            .HasConversion<int>();
        
        modelBuilder.Entity<Account>()
                    .Property(account => account.Type)
                    .HasConversion<int>();
    }
}