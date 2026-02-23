using System.ComponentModel.DataAnnotations;

namespace Powdernaut.WebApi.Models;

public class LoginRequest
{
    [Required]
    public string Username { get; set; } = string.Empty;

    [Required]
    public string Password { get; set; } = string.Empty;

    public bool IsRemember { get; set; }
}