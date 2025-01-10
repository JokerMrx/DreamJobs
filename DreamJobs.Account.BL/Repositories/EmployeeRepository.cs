using AutoMapper;
using DreamJobs.Account.BL.Context;
using DreamJobs.Account.Core.Models;
using DreamJobs.Account.Core.Models.DTOs;
using DreamJobs.Account.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DreamJobs.Account.BL.Repositories;

public class EmployeeRepository(
    AppDbContext appDbContext,
    IMapper mapper
) : IEmployeeRepository
{
    public async Task<Employee> CreateAsync(EmployeeDto entity)
    {
        var employer = await appDbContext.Employees.AddAsync(new Employee()
        {
            Id = entity.Id,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            Phone = entity.Phone,
            UserId = entity.UserId,
            CreatedAt = entity.CreatedAt,
        });
        
        await appDbContext.SaveChangesAsync();

        return employer.Entity;
    }

    public async Task<Employee?> GetByIdAsync(Guid id)
    {
        var employee = await appDbContext.Employees.SingleOrDefaultAsync(u => Guid.Equals(u.Id, id));

        return employee;
    }

    public async Task<Employee> UpdateAsync(EmployeeDto entity)
    {
        var employee = mapper.Map<Employee>(entity);
        var updatedEmployee = appDbContext.Employees.Update(employee).Entity;
        await appDbContext.SaveChangesAsync();

        return updatedEmployee;
    }
}