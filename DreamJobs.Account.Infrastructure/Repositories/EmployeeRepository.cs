using AutoMapper;
using DreamJobs.Account.Domain.Interfaces.Repositories;
using DreamJobs.Account.Domain.Models;
using DreamJobs.Account.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace DreamJobs.Account.Infrastructure.Repositories;

public class EmployeeRepository(
    AppDbContext appDbContext,
    IMapper mapper
) : IEmployeeRepository
{
    public async Task<Employee> CreateAsync(Employee entity)
    {
        var employeeEntity = mapper.Map<Entities.Employee>(entity);
        var employee = await appDbContext.Employees.AddAsync(employeeEntity);

        await appDbContext.SaveChangesAsync();

        return mapper.Map<Employee>(employee.Entity);
    }

    public async Task<Employee?> GetByIdAsync(Guid id)
    {
        var employee = await appDbContext.Employees.SingleOrDefaultAsync(u => Guid.Equals(u.Id, id));

        return mapper.Map<Employee>(employee);
    }

    public async Task<Employee> UpdateAsync(Employee entity)
    {
        var employee = mapper.Map<Entities.Employee>(entity);
        var updatedEmployee = appDbContext.Employees.Update(employee).Entity;
        await appDbContext.SaveChangesAsync();

        return mapper.Map<Employee>(updatedEmployee);
    }
}