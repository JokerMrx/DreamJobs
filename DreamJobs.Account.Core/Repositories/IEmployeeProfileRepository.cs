using DreamJobs.Account.Core.Models;

namespace DreamJobs.Account.Core.Repositories;

public interface IEmployeeProfileRepository : IBaseRepository<EmployeeProfile, EmployeeProfile>
{
    public Task<EmployeeProfile> Create(EmployeeProfile employeeProfile);
    public Task<EmployeeProfile> GetByEmployeeId(Guid employeeId);
}