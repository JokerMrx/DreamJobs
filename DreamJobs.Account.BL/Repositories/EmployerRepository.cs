using AutoMapper;
using DreamJobs.Account.BL.Context;
using DreamJobs.Account.Core.Models;
using DreamJobs.Account.Core.Models.DTOs;
using DreamJobs.Account.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DreamJobs.Account.BL.Repositories;

public class EmployerRepository(AppDbContext appDbContext, IMapper mapper)
    : IEmployerRepository
{
    public async Task<Employer> CreateAsync(EmployerDto employerDto)
    {
        var employer = await appDbContext.Employers.AddAsync(new Employer()
        {
            Id = employerDto.Id,
            Name = employerDto.Name,
            CreatedAt = employerDto.CreatedAt,
            UserId = employerDto.UserId,
        });
        await appDbContext.SaveChangesAsync();

        return employer.Entity;
    }

    public async Task<Employer?> GetByIdAsync(Guid id)
    {
        var employer = await appDbContext.Employers.SingleOrDefaultAsync(e => e.Id == id);

        return employer;
    }

    public async Task<Employer> UpdateAsync(Employer employer)
    {
        var updatedEmployer = appDbContext.Employers.Update(employer);
        await appDbContext.SaveChangesAsync();

        return updatedEmployer.Entity;
    }
}