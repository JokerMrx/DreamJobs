using System.ComponentModel.DataAnnotations;

namespace DreamJobs.Account.Core.Models;

public class Base
{
    [Key] public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
}