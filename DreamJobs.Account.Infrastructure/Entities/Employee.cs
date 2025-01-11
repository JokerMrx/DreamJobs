using System.ComponentModel.DataAnnotations.Schema;

namespace DreamJobs.Account.Infrastructure.Entities;

public class Employee : BaseEntity
{
    public required string FirstName { get; set; }

    public required string LastName { get; set; }

    public string? Phone { get; set; }

    public EmployeeProfile? EmployeeProfile { get; set; }

    [ForeignKey("User")] public required Guid UserId { get; set; }
    public User? User { get; set; }
}