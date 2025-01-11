using DreamJobs.Account.Application.DTOs;

namespace DreamJobs.Account.Application.Interfaces.Services;

public interface IAuthService
{
    public Task<AuthResponseDto> Login(string email, string password);
    public Task<AuthResponseDto> EmployeeRegister(EmployeeRegisterDto employee);
    public Task<AuthResponseDto> EmployerRegister(EmployerRegisterDto employer);
    public Task<AuthResponseDto> RefreshTokens(string refreshToken);
}