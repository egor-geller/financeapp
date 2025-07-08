namespace fin.server.Models.Users;

public class User
{
    public Guid Id { get; set; }
    public required string Username { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public bool IsActive { get; set; }
    public Role Role { get; set; } = Role.Guest;
    public required int Ssn { get; set; }
    public DateTime Created { get; set; } = DateTime.UtcNow;
    public DateTime Updated { get; set; } = DateTime.UtcNow;

    public override string ToString()
    {
        return $"""
                    Username: {Username}
                    Email: {Email}
                    FirstName: {FirstName}
                    LastName: {LastName}
                    IsActive: {IsActive}
                    Role: {Role}
                """;
    }
}