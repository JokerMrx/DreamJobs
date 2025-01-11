namespace DreamJobs.Account.Domain.Models;

public class Base
{
    public required Guid Id { get; set; }
    public required DateTime CreatedAt { get; set; }
    
    public Base()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;
    }
}