using DreamJobs.Account.Core.Enums;

namespace DreamJobs.Account.Core.Models.DTOs;

public class UserDto : Base
{
    public required string Email { get; set; }

    public bool IsConfirmEmail { get; set; }
    public bool IsActive { get; set; } = true;
    public Roles Role { get; set; }

    public Employee? Employee { get; set; }
    public Employer? Employer { get; set; }
}