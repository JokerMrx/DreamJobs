using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DreamJobs.Account.BL.Options;
using DreamJobs.Account.Core.Enums;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace DreamJobs.Account.BL.Providers;

public class JwtProvider(IOptions<JwtOptions> jwtOptions) : IJwtProvider
{
    private readonly JwtOptions _jwtOptions = jwtOptions.Value;

    public string GenerateToken(Guid id, string email, Roles role)
    {
        Claim[] claims = [new("id", id.ToString()), new("email", email), new("role", role.ToString())];

        var signingCredentials =
            new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey)),
                SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(claims: claims, signingCredentials: signingCredentials,
            expires: DateTime.UtcNow.AddHours(_jwtOptions.ExpiresHours));

        var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

        return tokenString;
    }

    public bool IsValidateToken(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(_jwtOptions.SecretKey);

        try
        {
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key)
            }, out _);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public Tuple<Guid, string> DecodeToken(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        if (!tokenHandler.CanReadToken(token))
            throw new ArgumentException("Invalid token format");

        var jwtToken = tokenHandler.ReadJwtToken(token);

        var idClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "id")?.Value;
        var emailClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "email")?.Value;

        if (idClaim == null || emailClaim == null)
            throw new ArgumentException("Token does not contain required claims");

        if (!Guid.TryParse(idClaim, out Guid id))
            throw new ArgumentException("Invalid ID claim in token");

        return new Tuple<Guid, string>(id, emailClaim);
    }
}