using AutoMapper;
using DreamJobs.Account.Domain.Interfaces.Repositories;
using DreamJobs.Account.Domain.Models;
using DreamJobs.Account.Infrastructure.Context;
using DreamJobs.Account.Infrastructure.Utils;
using Microsoft.EntityFrameworkCore;

namespace DreamJobs.Account.Infrastructure.Repositories;

public class UserRepository(AppDbContext appDbContext, IPasswordHasher passwordHasher, IMapper mapper) : IUserRepository
{
    public async Task<User> CreateAsync(User entity)
    {
        var candidate = await GetByEmailAsync(entity.Email);

        if (candidate != null)
        {
            throw new Exception($"Email {entity.Email} already exists");
        }

        var userEntity = mapper.Map<Entities.User>(entity);
        var createdUser = await appDbContext.Users.AddAsync(userEntity);
        await appDbContext.SaveChangesAsync();

        return mapper.Map<User>(createdUser.Entity);
    }

    public async Task<User?> GetByIdAsync(Guid id)
    {
        var user = await appDbContext.Users.SingleOrDefaultAsync(u => Guid.Equals(u.Id, id));

        return mapper.Map<User?>(user);
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        var user = await appDbContext.Users.SingleOrDefaultAsync(u => u.Email == email);

        return mapper.Map<User?>(user);
    }

    public async Task<User> UpdateAsync(User entity)
    {
        var user = await GetByIdAsync(entity.Id);

        if (user == null)
        {
            throw new NullReferenceException("User not found");
        }

        user.Email = entity.Email;
        await appDbContext.SaveChangesAsync();

        return user;
    }

    public async Task<User> ChangePasswordAsync(Guid id, string oldPassword, string newPassword)
    {
        var user = await GetByIdAsync(id);

        if (user == null)
        {
            throw new Exception($"User with id: {id} does not exist");
        }

        var oldPasswordHash = passwordHasher.Generate(oldPassword);
        var isPasswordMatch = passwordHasher.Verify(oldPasswordHash, user.PasswordHash);

        if (!isPasswordMatch)
        {
            throw new Exception("Invalid password");
        }

        var newPasswordHash = passwordHasher.Generate(newPassword);
        user.PasswordHash = newPasswordHash;
        await appDbContext.SaveChangesAsync();

        return user;
    }

    public async Task<User> DeleteAsync(Guid id)
    {
        var user = await GetByIdAsync(id);

        if (user == null)
        {
            throw new Exception($"Employee with id: {id} does not exist");
        }

        user.IsActive = false;
        await appDbContext.SaveChangesAsync();

        return user;
    }
}