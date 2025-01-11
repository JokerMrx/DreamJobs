namespace DreamJobs.Account.Domain.Models;

public class Employer : Base
{
    public required string Name { get; set; }

    public string? Description { get; set; }

    public string? Address { get; set; }
    public string? LogoUrl { get; set; }
    public string? WebsiteUrl { get; set; }

    public Guid UserId { get; set; }

    public User? User { get; set; }
}