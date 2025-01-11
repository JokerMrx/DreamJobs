using DreamJobs.Account.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace DreamJobs.Account.Infrastructure.Entities;

[Index(nameof(Email), IsUnique = true)]
public class User : BaseEntity
{
    public required string Email { get; set; }

    public required string PasswordHash { get; set; }

    public bool IsConfirmEmail { get; set; }
    public bool IsActive { get; set; } = true;
    public RolesEnum RoleEnum { get; set; }

    public Employee? Employee { get; set; }
    public Employer? Employer { get; set; }
}