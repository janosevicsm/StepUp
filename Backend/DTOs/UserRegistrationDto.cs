using System.ComponentModel.DataAnnotations;

namespace Backend.DTOs;

public class UserRegistrationDto
{
    [Required(ErrorMessage = "First name is required.")]
    public required string FirstName { get; set; }

    [Required(ErrorMessage = "Last name is required.")]
    public required string LastName { get; set; }
    
    [Required]
    [EmailAddress(ErrorMessage = "Invalid email format.")]
    public required string Email { get; set; }

    [Required]
    [MinLength(8, ErrorMessage = "Password must be at least 8 characters.")]
    public required string Password { get; set; }
}