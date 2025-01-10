using DreamJobs.Account.Core.Enums;

namespace DreamJobs.Account.BL.Providers;

public interface IJwtProvider
{
    public string GenerateToken(Guid id, string email, Roles roles);
    public bool IsValidateToken(string token);
    public Tuple<Guid, string> DecodeToken(string token);
}