namespace DreamJobs.Account.Core.Models.DTOs;

public class EmployeeDto : Base
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public string? Phone { get; set; }
    public bool IsConfirmEmail { get; set; } = default;
    public required Guid UserId { get; set; }

    public EmployeeDto(EmployeeRegisterDto employeeRegisterDto, User user)
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;
        FirstName = employeeRegisterDto.FirstName;
        LastName = employeeRegisterDto.LastName;
        Email = employeeRegisterDto.Email;
        Phone = employeeRegisterDto.Phone;
        UserId = user.Id;
    }
}