using System.Security.Claims;

namespace DreamJobs.Account.Infrastructure.Providers;

public interface IJwtProvider
{
    public string GenerateToken(IEnumerable<Claim> claims, int expiresIn);
    public bool IsValidateToken(string token);
    public Tuple<Guid, string> DecodeToken(string token);
}