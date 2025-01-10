using DreamJobs.Account.Core.Models;
using DreamJobs.Account.Core.Models.DTOs;

namespace DreamJobs.Account.Core.Repositories;

public interface IEmployeeRepository : IBaseRepository<Employee, EmployeeDto>
{
    public Task<Employee> CreateAsync(EmployeeDto employeeDto);
    // public Task<IEnumerable<Employee>> GetAllAsync(uint page, uint pageSize); TODO get all with pagination, data should include user data
}