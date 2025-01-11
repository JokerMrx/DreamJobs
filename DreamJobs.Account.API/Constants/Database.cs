namespace DreamJobs.Account.API.Constants;

public static class Database
{
    public static readonly string? DatabaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL");
}