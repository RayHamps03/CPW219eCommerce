using System.ComponentModel.DataAnnotations;

namespace eCommerce.Models;

public class Member
{
    /// <summary>
    /// Unique identifier for the member
    /// </summary>
    [Key]
    public int MemberId { get; set; }

    /// <summary>
    /// The user inputted username of the member
    /// </summary>
    [RegularExpression("^[a-zA-Z0-9]+$", 
        ErrorMessage = "Username must be alphanumeric.")]
    [StringLength(25)]
    public required string Username { get; set; }

    /// <summary>
    /// The email the user submitted for the member
    /// </summary>
    public required string Email { get; set; }

    /// <summary>
    /// The member's password
    /// </summary>
    [StringLength(50, MinimumLength = 6, 
        ErrorMessage = "Password must be between at least 6 to 50")]
    public required string Password { get; set; }

    /// <summary>
    /// The date of birth of the member
    /// </summary>
    
    public DateOnly DateOfBirth { get; set; }
}

public class RegistrationViewModel
{
    /// <summary>
    /// The user inputted username of the member
    /// </summary>
    [RegularExpression("^[a-zA-Z0-9]+$",
        ErrorMessage = "Username must be alphanumeric.")]
    [StringLength(25)]
    public required string Username { get; set; }

    /// <summary>
    /// The email the user submitted for the member
    /// </summary>
    [DataType(DataType.EmailAddress)]
    public required string Email { get; set; }

    /// <summary>
    /// The member's password
    /// </summary>
    [StringLength(50, MinimumLength = 6,
        ErrorMessage = "Password must be between at least 6 to 50")]
    [DataType(DataType.Password)]
    public required string Password { get; set; }

    [Compare(nameof(Password), ErrorMessage = "Passwords do not match.")]
    [DataType(DataType.Password)]
    public required string ConfirmPassword { get; set; }

    /// <summary>
    /// The date of birth of the member
    /// </summary>
    [DataType(DataType.Date)]
    public DateOnly DateOfBirth { get; set; }
}

public class LoginViewModel
{
    public required string UsernameOrEmail { get; set; }

    [DataType(DataType.Password)]
    public required string Password { get; set; }
}
