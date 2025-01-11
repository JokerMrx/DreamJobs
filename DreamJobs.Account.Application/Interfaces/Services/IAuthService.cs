using DreamJobs.Account.Application.DTOs;

namespace DreamJobs.Account.Application.Interfaces.Services;

public interface IAuthService
{
    public Task<string> Login(string email, string password);
    public Task<string> EmployeeRegister(EmployeeRegisterDto employee);
    public Task<string> EmployerRegister(EmployerRegisterDto employer);
}