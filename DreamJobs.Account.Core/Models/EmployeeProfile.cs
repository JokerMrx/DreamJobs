using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DreamJobs.Account.Core.Models;

public class EmployeeProfile : Base
{
    [StringLength(maximumLength: 1500, MinimumLength = 50)]
    public string? Bio { get; set; }

    [Range(0, 80, ErrorMessage = "Employee age must be between 0 and 80")]
    public byte ExperienceYears { get; set; }

    public IEnumerable<string> Skills { get; set; } = new List<string>();
    public string? Education { get; set; }
    public string? Location { get; set; }
    public string? Telegram { get; set; }
    public string? LinkedIn { get; set; }

    [ForeignKey("Employee")] public Guid EmployeeId { get; set; }

    public Employee? Employee { get; set; }
}