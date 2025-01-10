using DreamJobs.Account.Core.Models.DTOs;

namespace DreamJobs.Account.Core.Repositories;

public interface IAuthRepository
{
    public Task<string> Login(string email, string password);
    public Task<string> EmployeeRegister(EmployeeRegisterDto employeeRegisterDto);
    public Task<string> EmployerRegister(EmployerRegisterDto employerRegisterDto);
}