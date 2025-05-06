using System.ComponentModel.DataAnnotations;

namespace Backend.DTOs;

public class LoginDto
{
    [Required]
    [EmailAddress(ErrorMessage = "Invalid email format.")]
    public required string Email { get; set; }

    [Required]
    public required string Password { get; set; }
}