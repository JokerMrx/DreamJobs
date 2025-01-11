using DreamJobs.Account.Domain.Models;

namespace DreamJobs.Account.Domain.Interfaces.Repositories;

public interface IEmployerRepository : IBaseRepository<Employer>
{
    public Task<Employer> CreateAsync(Employer employer);
}