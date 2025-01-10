namespace DreamJobs.Account.Core.Models.DTOs;

public class EmployeeDto : Base
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public string? Phone { get; set; }
    public bool IsConfirmEmail { get; set; }
    public required Guid UserId { get; set; }
}