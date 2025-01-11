namespace DreamJobs.Account.Application.DTOs;

public class EmployeeDto : UserDto
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }

    public string? Phone { get; set; }

    public required Guid UserId { get; set; }
}