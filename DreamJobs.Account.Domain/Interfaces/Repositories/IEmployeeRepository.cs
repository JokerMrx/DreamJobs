using DreamJobs.Account.Domain.Models;

namespace DreamJobs.Account.Domain.Interfaces.Repositories;

public interface IEmployeeRepository : IBaseRepository<Employee>
{
    public Task<Employee> CreateAsync(Employee employee);
    // public Task<IEnumerable<Employee>> GetAllAsync(uint page, uint pageSize); TODO get all with pagination, data should include user data
}