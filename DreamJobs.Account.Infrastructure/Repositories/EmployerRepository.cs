using AutoMapper;
using DreamJobs.Account.Domain.Interfaces.Repositories;
using DreamJobs.Account.Domain.Models;
using DreamJobs.Account.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace DreamJobs.Account.Infrastructure.Repositories;

public class EmployerRepository(AppDbContext appDbContext, IMapper mapper)
    : IEmployerRepository
{
    public async Task<Employer> CreateAsync(Employer employer)
    {
        var employerEntity = mapper.Map<Entities.Employer>(employer);
        var createdEmployer = await appDbContext.Employers.AddAsync(employerEntity);
        await appDbContext.SaveChangesAsync();

        return mapper.Map<Employer>(createdEmployer.Entity);
    }

    public async Task<Employer?> GetByIdAsync(Guid id)
    {
        var employer = await appDbContext.Employers.SingleOrDefaultAsync(e => e.Id == id);

        return mapper.Map<Employer>(employer);
    }

    public async Task<Employer> UpdateAsync(Employer employer)
    {
        var employerEntity = mapper.Map<Entities.Employer>(employer);
        var updatedEmployer = appDbContext.Employers.Update(employerEntity);
        await appDbContext.SaveChangesAsync();

        return mapper.Map<Employer>(updatedEmployer.Entity);
    }
}