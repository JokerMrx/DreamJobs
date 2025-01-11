using DreamJobs.Account.Domain.Enums;

namespace DreamJobs.Account.Infrastructure.Providers;

public interface IJwtProvider
{
    public string GenerateToken(Guid id, string email, RolesEnum rolesEnum);
    public bool IsValidateToken(string token);
    public Tuple<Guid, string> DecodeToken(string token);
}