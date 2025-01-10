namespace DreamJobs.Account.BL.Options;

public class JwtOptions
{
    public required string SecretKey { get; set; }
    public int ExpiresHours { get; set; }
}