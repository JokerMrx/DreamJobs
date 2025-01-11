namespace DreamJobs.Account.Domain.Models;

public class Employee : Base
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }

    public string? Phone { get; set; }

    public EmployeeProfile? EmployeeProfile { get; set; }

    public required Guid UserId { get; set; }
    public User? User { get; set; }
}