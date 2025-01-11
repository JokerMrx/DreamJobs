namespace DreamJobs.Account.Infrastructure.Options;

public class JwtOptions
{
    public required string SecretKey { get; set; }
    public int AccessTokenExpiresInMinutes { get; set; }
    public int RefreshTokenExpiresInMinutes { get; set; }
}