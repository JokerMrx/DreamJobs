using System.ComponentModel.DataAnnotations;

namespace DreamJobs.Account.Core.Models.DTOs;

public class EmployerRegisterDto
{
    [Required(ErrorMessage = "Employer name is required")]
    public required string Name { get; set; }

    [Required(ErrorMessage = "Employer email is required")]
    [EmailAddress(ErrorMessage = "Invalid email address")]
    public required string Email { get; set; }

    [Required(ErrorMessage = "Password is required")]
    public required string Password { get; set; }
}