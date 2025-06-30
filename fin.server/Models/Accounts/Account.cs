using fin.server.Models.Users;

namespace fin.server.Models.Accounts;

public class Account
{
    public int AccountId { get; set; }

    public string Name { get; set; } = string.Empty;

    public AccountType Type { get; set; }

    public decimal InitialBalance { get; set; } = 0;

    public decimal CurrentBalance { get; set; } = 0;

    public string? Currency { get; set; } = "USD";

    public bool IsActive { get; set; } = true;

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public string? Institution { get; set; }

    public string? Description { get; set; }
    public string? Iban { get; set; }

    // Foreign key to User, if multi-user system
    public string UserId { get; set; } = string.Empty;
    public User? User { get; set; }

    // public ICollection<Transaction>? Transactions { get; set; }
}