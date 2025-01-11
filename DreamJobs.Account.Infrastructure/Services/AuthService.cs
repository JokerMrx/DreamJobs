using System.Security.Claims;
using DreamJobs.Account.Application.DTOs;
using DreamJobs.Account.Application.Interfaces.Services;
using DreamJobs.Account.Domain.Enums;
using DreamJobs.Account.Domain.Interfaces.Repositories;
using DreamJobs.Account.Domain.Models;
using DreamJobs.Account.Infrastructure.Options;
using DreamJobs.Account.Infrastructure.Providers;
using DreamJobs.Account.Infrastructure.Utils;

namespace DreamJobs.Account.Infrastructure.Services;

public class AuthService(
    IUserRepository userRepository,
    IEmployeeRepository employeeRepository,
    IEmployerRepository employerRepository,
    IPasswordHasher passwordHasher,
    IJwtProvider jwtProvider,
    JwtOptions jWtOptions) : IAuthService
{
    public async Task<AuthResponseDto> Login(string email, string password)
    {
        var user = await userRepository.GetByEmailAsync(email);

        if (user == null)
        {
            throw new Exception($"User with email: {email} does not exist");
        }

        var isPasswordMatched = passwordHasher.Verify(password, user.PasswordHash);

        if (!isPasswordMatched)
        {
            throw new Exception("Invalid email or password");
        }

        Claim[] accessClaims =
            [new("id", user.Id.ToString()), new("email", user.Email), new("role", user.RoleEnum.ToString())];
        Claim[] refreshClaims = [new("id", user.Id.ToString())];
        var accessToken = jwtProvider.GenerateToken(accessClaims, jWtOptions.AccessTokenExpiresInMinutes);
        var refreshToken = jwtProvider.GenerateToken(refreshClaims, jWtOptions.AccessTokenExpiresInMinutes);
        var authResponseDto = new AuthResponseDto()
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken,
        };

        return authResponseDto;
    }

    public async Task<AuthResponseDto> EmployeeRegister(EmployeeRegisterDto employeeRegisterDto)
    {
        var passwordHash = passwordHasher.Generate(employeeRegisterDto.Password);
        var user = new User
        {
            Id = Guid.NewGuid(),
            Email = employeeRegisterDto.Email,
            RoleEnum = RolesEnum.Employee,
            PasswordHash = passwordHash,
            CreatedAt = DateTime.UtcNow
        };
        var createdUser = await userRepository.CreateAsync(user);
        var employee = new Employee()
        {
            Id = createdUser.Id,
            CreatedAt = DateTime.UtcNow,
            FirstName = employeeRegisterDto.FirstName,
            LastName = employeeRegisterDto.LastName,
            Phone = employeeRegisterDto.Phone,
            UserId = createdUser.Id,
        };
        await employeeRepository.CreateAsync(employee);
        Claim[] accessClaims =
            [new("id", user.Id.ToString()), new("email", user.Email), new("role", user.RoleEnum.ToString())];
        Claim[] refreshClaims = [new("id", user.Id.ToString())];
        var accessToken = jwtProvider.GenerateToken(accessClaims, jWtOptions.AccessTokenExpiresInMinutes);
        var refreshToken = jwtProvider.GenerateToken(refreshClaims, jWtOptions.AccessTokenExpiresInMinutes);
        var authResponseDto = new AuthResponseDto()
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken,
        };

        return authResponseDto;
    }

    public async Task<AuthResponseDto> EmployerRegister(EmployerRegisterDto employerRegisterDto)
    {
        var passwordHash = passwordHasher.Generate(employerRegisterDto.Password);
        var user = new User()
        {
            Id = Guid.NewGuid(), Email = employerRegisterDto.Email, RoleEnum = RolesEnum.Employer,
            PasswordHash = passwordHash, CreatedAt = DateTime.UtcNow
        };
        var createdUser = await userRepository.CreateAsync(user);
        var employerDto = new Employer()
        {
            Id = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow,
            Name = employerRegisterDto.Name,
            UserId = createdUser.Id,
        };
        await employerRepository.CreateAsync(employerDto);
        Claim[] accessClaims =
            [new("id", user.Id.ToString()), new("email", user.Email), new("role", user.RoleEnum.ToString())];
        Claim[] refreshClaims = [new("id", user.Id.ToString())];
        var accessToken = jwtProvider.GenerateToken(accessClaims, jWtOptions.AccessTokenExpiresInMinutes);
        var refreshToken = jwtProvider.GenerateToken(refreshClaims, jWtOptions.AccessTokenExpiresInMinutes);
        var authResponseDto = new AuthResponseDto()
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken,
        };

        return authResponseDto;
    }
    
    public async Task<AuthResponseDto> RefreshTokens(string refreshToken)
    {
        var isValidRefreshToken = jwtProvider.IsValidateToken(refreshToken);

        if (!isValidRefreshToken)
        {
            throw new Exception("Refresh token is invalid");
        }
        
        var (userId, _) = jwtProvider.DecodeToken(refreshToken);
        var user = await userRepository.GetByIdAsync(userId);

        if (user == null)
        {
            throw new Exception($"User not found");
        }

        Claim[] accessClaims =
            [new("id", user.Id.ToString()), new("email", user.Email), new("role", user.RoleEnum.ToString())];
        Claim[] refreshClaims = [new("id", user.Id.ToString())];
        var accessToken = jwtProvider.GenerateToken(accessClaims, jWtOptions.AccessTokenExpiresInMinutes);
        var newRefreshToken = jwtProvider.GenerateToken(refreshClaims, jWtOptions.AccessTokenExpiresInMinutes);
        var authResponseDto = new AuthResponseDto()
        {
            AccessToken = accessToken,
            RefreshToken = newRefreshToken,
        };

        return authResponseDto;
    }
}