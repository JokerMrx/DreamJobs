namespace DreamJobs.Account.Infrastructure.Options;

public class JwtOptions
{
    public required string SecretKey { get; set; }
    public int ExpiresHours { get; set; }
}