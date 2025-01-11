using DreamJobs.Account.Domain.Enums;
using DreamJobs.Account.Domain.Models;

namespace DreamJobs.Account.Application.DTOs;

public class UserDto : Base
{
    public required string Email { get; set; }

    public bool IsConfirmEmail { get; set; }
    public bool IsActive { get; set; } = true;
    public RolesEnum RoleEnum { get; set; }
}