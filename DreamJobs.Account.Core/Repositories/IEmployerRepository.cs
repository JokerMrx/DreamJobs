using DreamJobs.Account.Core.Models;
using DreamJobs.Account.Core.Models.DTOs;

namespace DreamJobs.Account.Core.Repositories;

public interface IEmployerRepository : IBaseRepository<Employer, Employer>
{
    public Task<Employer> CreateAsync(EmployerDto employerDto);
}