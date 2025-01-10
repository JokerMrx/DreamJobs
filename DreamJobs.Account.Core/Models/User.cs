using System.ComponentModel.DataAnnotations;
using DreamJobs.Account.Core.Enums;
using Microsoft.EntityFrameworkCore;

namespace DreamJobs.Account.Core.Models;

[Index(nameof(Email), IsUnique = true)]
public class User : Base
{
    [Required(ErrorMessage = "Employer email is required")]
    [EmailAddress(ErrorMessage = "Invalid email address")]
    public required string Email { get; set; }

    public required string PasswordHash { get; set; }

    public bool IsConfirmEmail { get; set; }
    public bool IsActive { get; set; } = true;
    public Roles Role { get; set; }

    public Employee? Employee { get; set; }
    public Employer? Employer { get; set; }
}