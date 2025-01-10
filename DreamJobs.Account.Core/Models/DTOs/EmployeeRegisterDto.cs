using System.ComponentModel.DataAnnotations;

namespace DreamJobs.Account.Core.Models.DTOs;

public class EmployeeRegisterDto
{
    [Required(ErrorMessage = "First name is required")]
    public required string FirstName { get; set; }

    [Required(ErrorMessage = "Last name is required")]
    public required string LastName { get; set; }

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email address")]
    public required string Email { get; set; }

    [Phone] public string? Phone { get; set; }

    [Required(ErrorMessage = "Password is required")]
    public required string Password { get; set; }
}