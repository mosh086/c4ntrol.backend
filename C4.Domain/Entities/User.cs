namespace C4.Domain.Entities;

using C4.Domain.Common;

public class User : Audit
{
    public long Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }

    public string Salt { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public DateTime? LastLogin { get; set; }
    public string? RefreshToken { get; set; }
    public string? RefreshTokenExpiryTime { get; set; }
}