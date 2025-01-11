namespace DreamJobs.Account.Application.DTOs;

public class EmployerDto : UserDto
{
    public required string Name { get; set; }

    public string? Description { get; set; }

    public string? Address { get; set; }
    public string? LogoUrl { get; set; }
    public string? WebsiteUrl { get; set; }

    public Guid UserId { get; set; }
}