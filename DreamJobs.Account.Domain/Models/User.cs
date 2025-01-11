using DreamJobs.Account.Domain.Enums;

namespace DreamJobs.Account.Domain.Models;

public class User : Base
{
    public required string Email { get; set; }

    public required string PasswordHash { get; set; }

    public bool IsConfirmEmail { get; set; }
    public bool IsActive { get; set; } = true;
    public RolesEnum RoleEnum { get; set; }

    public Employee? Employee { get; set; }
    public Employer? Employer { get; set; }
}