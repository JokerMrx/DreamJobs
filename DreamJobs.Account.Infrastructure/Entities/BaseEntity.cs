using System.ComponentModel.DataAnnotations;

namespace DreamJobs.Account.Infrastructure.Entities;

public class BaseEntity
{
    [Key] public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }

    public BaseEntity()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;
    }
}