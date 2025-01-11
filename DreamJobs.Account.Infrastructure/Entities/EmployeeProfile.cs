using System.ComponentModel.DataAnnotations.Schema;

namespace DreamJobs.Account.Infrastructure.Entities;

public class EmployeeProfile : BaseEntity
{
    public string? Bio { get; set; }

    public byte ExperienceYears { get; set; }

    public IEnumerable<string> Skills { get; set; } = new List<string>();
    public string? Education { get; set; }
    public string? Location { get; set; }
    public string? Telegram { get; set; }
    public string? LinkedIn { get; set; }

    [ForeignKey("Employee")] public Guid EmployeeId { get; set; }

    public Employee? Employee { get; set; }
}