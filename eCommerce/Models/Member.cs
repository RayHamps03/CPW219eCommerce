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
    public required string Username { get; set; }

    /// <summary>
    /// The email the user submitted for the member
    /// </summary>
    public required string Email { get; set; }

    /// <summary>
    /// The member's password
    /// </summary>
    public required string Password { get; set; }

    /// <summary>
    /// The date of birth of the member
    /// </summary>
    public DateOnly DateOfBirth { get; set; }
}
