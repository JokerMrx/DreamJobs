using AutoMapper;
using DreamJobs.Account.Domain.Interfaces.Repositories;
using DreamJobs.Account.Domain.Models;
using DreamJobs.Account.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace DreamJobs.Account.Infrastructure.Repositories;

public class EmployeeProfileRepository(
    AppDbContext appDbContext,
    IEmployeeRepository employeeRepository,
    IMapper mapper)
    : IEmployeeProfileRepository
{
    public async Task<EmployeeProfile> Create(EmployeeProfile employeeProfile)
    {
        var employeeProfileEntity = mapper.Map<Entities.EmployeeProfile>(employeeProfile);
        var employee = await appDbContext.EmployeeProfiles.AddAsync(employeeProfileEntity);
        await appDbContext.SaveChangesAsync();

        return mapper.Map<EmployeeProfile>(employeeProfileEntity);
    }

    public async Task<EmployeeProfile?> GetByIdAsync(Guid id)
    {
        var employeeProfile = await appDbContext.EmployeeProfiles.SingleOrDefaultAsync(e => Guid.Equals(e.Id, id));

        return mapper.Map<EmployeeProfile?>(employeeProfile);
    }

    public async Task<EmployeeProfile> UpdateAsync(EmployeeProfile employeeProfile)
    {
        var employeeProfileEntity = mapper.Map<Entities.EmployeeProfile>(employeeProfile);
        var employee = appDbContext.EmployeeProfiles.Update(employeeProfileEntity);
        await appDbContext.SaveChangesAsync();

        return mapper.Map<EmployeeProfile>(employeeProfileEntity);
    }

    public async Task<EmployeeProfile> GetByEmployeeId(Guid employeeId)
    {
        var employee = await appDbContext.EmployeeProfiles.SingleAsync(e => Guid.Equals(e.EmployeeId, employeeId));

        return mapper.Map<EmployeeProfile>(employee);
    }
}