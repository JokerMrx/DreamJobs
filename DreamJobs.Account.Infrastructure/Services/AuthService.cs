using DreamJobs.Account.Application.DTOs;
using DreamJobs.Account.Application.Interfaces.Services;
using DreamJobs.Account.Domain.Enums;
using DreamJobs.Account.Domain.Interfaces.Repositories;
using DreamJobs.Account.Domain.Models;
using DreamJobs.Account.Infrastructure.Providers;
using DreamJobs.Account.Infrastructure.Utils;

namespace DreamJobs.Account.Infrastructure.Services;

public class AuthService(
    IUserRepository userRepository,
    IEmployeeRepository employeeRepository,
    IEmployerRepository employerRepository,
    IPasswordHasher passwordHasher,
    IJwtProvider jwtProvider) : IAuthService
{
    public async Task<string> Login(string email, string password)
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

        var token = jwtProvider.GenerateToken(user.Id, user.Email, user.RoleEnum);

        return token;
    }

    public async Task<string> EmployeeRegister(EmployeeRegisterDto employeeRegisterDto)
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
        var token = jwtProvider.GenerateToken(createdUser.Id, createdUser.Email, createdUser.RoleEnum);

        return token;
    }

    public async Task<string> EmployerRegister(EmployerRegisterDto employerRegisterDto)
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
        var token = jwtProvider.GenerateToken(createdUser.Id, createdUser.Email, createdUser.RoleEnum);

        return token;
    }
}