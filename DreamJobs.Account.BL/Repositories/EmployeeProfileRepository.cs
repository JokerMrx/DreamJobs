using DreamJobs.Account.BL.Context;
using DreamJobs.Account.Core.Models;
using DreamJobs.Account.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DreamJobs.Account.BL.Repositories;

public class EmployeeProfileRepository(AppDbContext appDbContext, IEmployeeRepository employeeRepository)
    : IEmployeeProfileRepository
{
    public async Task<EmployeeProfile> Create(EmployeeProfile entity)
    {
        await employeeRepository.GetByIdAsync(entity.EmployeeId);
        var employee = await appDbContext.EmployeeProfiles.AddAsync(entity);
        await appDbContext.SaveChangesAsync();

        return employee.Entity;
    }

    public async Task<EmployeeProfile?> GetByIdAsync(Guid id)
    {
        var employee = await appDbContext.EmployeeProfiles.SingleOrDefaultAsync(e => Guid.Equals(e.Id, id));

        return employee;
    }

    public async Task<EmployeeProfile> UpdateAsync(EmployeeProfile entity)
    {
        await employeeRepository.GetByIdAsync(entity.EmployeeId);
        var employee = appDbContext.EmployeeProfiles.Update(entity);
        await appDbContext.SaveChangesAsync();

        return employee.Entity;
    }

    public async Task<EmployeeProfile> GetByEmployeeId(Guid employeeId)
    {
        var employee = await appDbContext.EmployeeProfiles.SingleAsync(e => Guid.Equals(e.EmployeeId, employeeId));

        return employee;
    }
}