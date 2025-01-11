using DreamJobs.Account.Domain.Models;

namespace DreamJobs.Account.Domain.Interfaces.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    public Task<User> CreateAsync(User user);
    public Task<User?> GetByEmailAsync(string email);
    public Task<User> ChangePasswordAsync(Guid employerId, string oldPassword, string newPassword);
    public Task<User> DeleteAsync(Guid id);
}