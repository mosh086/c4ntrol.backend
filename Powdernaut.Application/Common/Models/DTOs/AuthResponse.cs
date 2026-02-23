namespace Powdernaut.Application.Common.Models.DTOs;

public class AuthResponse
{
    public string RefreshToken { get; set; }
    public string Token { get; set; }
    public UserProfileDTO User { get; set; }
    public DateTime ExpiresIn { get; set; }
}
