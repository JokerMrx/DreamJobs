using AutoMapper;
using DreamJobs.Account.BL.Providers;
using DreamJobs.Account.BL.Utils;
using DreamJobs.Account.Core.Enums;
using DreamJobs.Account.Core.Models;
using DreamJobs.Account.Core.Models.DTOs;
using DreamJobs.Account.Core.Repositories;

namespace DreamJobs.Account.BL.Repositories;

public class AuthRepository(
    IUserRepository userRepository,
    IEmployeeRepository employeeRepository,
    IEmployerRepository employerRepository,
    IPasswordHasher passwordHasher,
    IJwtProvider jwtProvider,
    IMapper mapper) : IAuthRepository
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

        var token = jwtProvider.GenerateToken(user.Id, user.Email, user.Role);

        return token;
    }

    public async Task<string> EmployeeRegister(EmployeeRegisterDto employeeRegisterDto)
    {
        var passwordHash = passwordHasher.Generate(employeeRegisterDto.Password);
        var user = new User()
        {
            Id = Guid.NewGuid(), Email = employeeRegisterDto.Email, Role = Roles.Employee, PasswordHash = passwordHash
        };
        var createdUser = await userRepository.CreateAsync(user);
        var employeeDto = new EmployeeDto(employeeRegisterDto, createdUser)
        {
            FirstName = employeeRegisterDto.FirstName,
            LastName = employeeRegisterDto.LastName,
            Email = employeeRegisterDto.Email,
            UserId = createdUser.Id,
        };
        await employeeRepository.CreateAsync(employeeDto);
        var token = jwtProvider.GenerateToken(createdUser.Id, createdUser.Email, createdUser.Role);

        return token;
    }

    public async Task<string> EmployerRegister(EmployerRegisterDto employerRegisterDto)
    {
        var passwordHash = passwordHasher.Generate(employerRegisterDto.Password);
        var user = new User()
        {
            Id = Guid.NewGuid(), Email = employerRegisterDto.Email, Role = Roles.Employer, PasswordHash = passwordHash, CreatedAt = DateTime.UtcNow
        };
        var createdUser = await userRepository.CreateAsync(user);
        var employerDto = new EmployerDto(employerRegisterDto, createdUser)
        {
            Name = employerRegisterDto.Name,
            UserId = createdUser.Id,
        };
        await employerRepository.CreateAsync(employerDto);
        var token = jwtProvider.GenerateToken(createdUser.Id, createdUser.Email, createdUser.Role);

        return token;
    }
}