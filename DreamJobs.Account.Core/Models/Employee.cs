using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DreamJobs.Account.Core.Models;

public class Employee : Base
{
    [Required(ErrorMessage = "First name is required")]
    public required string FirstName { get; set; }

    [Required(ErrorMessage = "Last name is required")]
    public required string LastName { get; set; }

    [Phone] public string? Phone { get; set; }

    public EmployeeProfile? EmployeeProfile { get; set; }

    [Required(ErrorMessage = "User id is required")]
    [ForeignKey("User")]
    public required Guid UserId { get; set; }
    public User? User { get; set; }
}