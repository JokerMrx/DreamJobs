using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DreamJobs.Account.Core.Models;

public class Employer : Base
{
    [Required(ErrorMessage = "Employer name is required")]

    public required string Name { get; set; }

    public string? Description { get; set; }

    public string? Address { get; set; }
    public string? LogoUrl { get; set; }
    public string? WebsiteUrl { get; set; }

    [ForeignKey("User")] public Guid UserId { get; set; }

    public User? User { get; set; }
}