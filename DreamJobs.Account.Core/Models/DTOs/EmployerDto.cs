namespace DreamJobs.Account.Core.Models.DTOs;

public class EmployerDto : Base
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public string? Address { get; set; }
    public string? LogoUrl { get; set; }
    public string? WebsiteUrl { get; set; }
    public required Guid  UserId { get; set; }

    public EmployerDto(EmployerRegisterDto employerRegisterDto, User user)
    {
        Id = Guid.NewGuid();
        Name = employerRegisterDto.Name;
        CreatedAt = DateTime.UtcNow;
        UserId = user.Id;
    }
}