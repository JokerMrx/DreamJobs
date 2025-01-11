using DreamJobs.Account.Domain.Models;

namespace DreamJobs.Account.Domain.Interfaces.Repositories;

public interface IEmployeeProfileRepository : IBaseRepository<EmployeeProfile>
{
    public Task<EmployeeProfile> Create(EmployeeProfile employeeProfile);
    public Task<EmployeeProfile> GetByEmployeeId(Guid employeeId);
}