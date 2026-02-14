namespace C4.WebApi.Models;

public class RegisterRequest
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    [MinLength(8)]
    public string Password { get; set; } = string.Empty;

    [Required]
    [Compare("Password")]
    public string ConfirmPassword { get; set; } = string.Empty;

    [Required]
    [MinLength(10)]
    [MaxLength(10)]
    public string PhoneNumber { get; set; } = string.Empty;
}