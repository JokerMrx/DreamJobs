namespace DreamJobs.Account.Domain.Models;

public class EmployeeProfile : Base
{
    public string? Bio { get; set; }

    public byte ExperienceYears { get; set; }

    public IEnumerable<string> Skills { get; set; } = new List<string>();
    public string? Education { get; set; }
    public string? Location { get; set; }
    public string? Telegram { get; set; }
    public string? LinkedIn { get; set; }

    public Guid EmployeeId { get; set; }

    public Employee? Employee { get; set; }
}